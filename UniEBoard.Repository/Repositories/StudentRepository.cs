// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StudentRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for Student Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Repository;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Repository.Factories;
using System.Data.Entity;
using System.Data.Objects.DataClasses;
using System.Data.Entity.Infrastructure;

using System.Data.Entity;

namespace UniEBoard.Repository.Repositories
{
    /// <summary>
    /// The Student Repository Class
    /// </summary>
    public class StudentRepository : BaseRepository<UniEBoardDbContext, Repository.Student, Model.Entities.Student>, IStudentRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        public StudentRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the student by member ship id.
        /// </summary>
        /// <param name="membershipId">The membership id.</param>
        /// <returns></returns>
        public Model.Entities.Student GetStudentByMemberShipId(int membershipId)
        {
            Model.Entities.Student student = null;
            try
            {
                IQueryable<Student> students = this.Context.Set<Student>().Where(p => p.Membership_Id == membershipId).Take(1);
                Student studentEntity = students.ToList().FirstOrDefault();
                student = ObjectMapper.Map<Student, Model.Entities.Student>(studentEntity);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return student;
        }

        /// <summary>
        /// Finds the users in the same class.
        /// </summary>
        /// <param name="userName">The username</param>
        /// <returns>A list of fellow users</returns>
        public List<Model.Entities.Student> FindFellowStudents(int studentId)
        {
            List<Model.Entities.Student> students = new List<Model.Entities.Student>();
            
            try
            {
                List<Student> studentEntities = new List<Student>();
                var entities = Context.Set<Course>()
                    .Include(s => s.CourseRegistrations.Select(cr => cr.Student))
                    .Where(cr => cr.CourseRegistrations.Any(c => c.Student_Id.Equals(studentId)));

                foreach (Course course in entities)
                {
                    var studentsPerCourse = from cr in course.CourseRegistrations
                                            where cr.Course_Id.Equals(course.Id)
                                            select cr.Student;
                                            
                    studentEntities.AddRange(studentsPerCourse);
                }
                students = ObjectMapper.Map<Student, Model.Entities.Student>(studentEntities);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return students;
        }

        /// <summary>
        /// Finds the users in the same class.
        /// </summary>
        /// <param name="userName">The username</param>
        /// <returns>A list of fellow users</returns>
        public List<Model.Entities.Staff> FindTeacherByStudent(int studentId)
        {
            List<Model.Entities.Staff> staffs = new List<Model.Entities.Staff>();

            try
            {
                List<Staff> staffEntities = new List<Staff>();
                var entities = Context.Set<Course>()
                    .Include(s => s.StaffCourses.Select(sc => sc.Staff))
                    .Include(s => s.CourseRegistrations.Select(cr => cr.Student))
                    .Where(cr => cr.CourseRegistrations.Any(c => c.Student_Id.Equals(studentId)));
                foreach (Course course in entities)
                {
                    var staffPerCourse = from cr in course.StaffCourses
                                            where cr.Course_Id.Equals(course.Id)
                                            select cr.Staff;

                    staffEntities.AddRange(staffPerCourse);
                }
                staffs = ObjectMapper.Map<Staff, Model.Entities.Staff>(staffEntities);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return staffs;
        }

        /// <summary>
        /// Finds the student by studentName.
        /// </summary>
        /// <param name="userName">The studentName</param>
        /// <returns>Student</returns>
        public Model.Entities.Student FindStudentByName(string studentName)
        {
            Model.Entities.Student student = null;

            try
            {
                Student studentEntity = this.Context.Set<Student>()
                    .Where(u => (u.FirstName + " " + u.LastName).ToLower().Contains(studentName.ToLower()))
                    .FirstOrDefault();
                student = UserEntityFactory.CreateFromDataModel(studentEntity, ObjectMapper) as Model.Entities.Student;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return student;
        }

        /// <summary>
        /// Finds a list of courses student is registered for.
        /// </summary>
        /// <param name="studentId">Student Id</param>
        /// <returns>A List of Courses</returns>
        public List<Model.Entities.Course> FindRegisteredCourses(int studentId)
        {
            List<Model.Entities.Course> courses = new List<Model.Entities.Course>();

            try
            {
                var entities = Context.Set<Course>()
                    .Include(s => s.StaffCourses.Select(sc => sc.Staff))
                    .Include(s => s.CourseRegistrations.Select(cr => cr.Student))
                    .Where(cr => cr.CourseRegistrations.Any(c => c.Student_Id.Equals(studentId)));

                courses = ObjectMapper.Map<Course, Model.Entities.Course>(entities.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return courses;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public List<Model.Entities.Student> GetStudentsForTeacher(int teacherId)
        {
            List<Model.Entities.Student> studentList = new List<Model.Entities.Student>();
            try
            {
                IQueryable<Student> students = (from c in this.Context.Set<Course>()
                                               join m in this.Context.Set<StaffCourse>()
                                                    .Where(m => m.Staff_Id.Equals(teacherId))
                                                    on c.Id equals m.Course_Id
                                               join cr in this.Context.Set<CourseRegistration>()
                                                    on c.Id equals cr.Course_Id
                                               join s in this.Context.Set<Student>()
                                                    on cr.Student_Id equals s.Id
                                               select s).Distinct();

                students = students.Include("CourseRegistrations")
                    .Include("CourseRegistrations.Course")
                    .Include("CourseRegistrations.Course.CourseModules")
                    .Include("CourseRegistrations.Course.CourseModules.Module")
                    .Include("CourseRegistrations.Course.CourseModules.Module.Assignments");
                
              
                // Return Studentes
                studentList = ObjectMapper.Map<Student, Model.Entities.Student>(students.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }

            return studentList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public List<Model.Entities.Student> GetStudentsForModule(int moduleId)
        {
            List<Model.Entities.Student> studentList = new List<Model.Entities.Student>();
            try
            {
                IQueryable<Student> students = from c in this.Context.Set<Course>()
                                               join cr in this.Context.Set<CourseRegistration>()
                                                    on c.Id equals cr.Course_Id
                                               join cm in this.Context.Set<CourseModule>()
                                                    on cr.Course_Id equals cm.Course_Id
                                                    where cm.Module_Id == moduleId
                                               select cr.Student;

                // Return Studentes
                studentList = ObjectMapper.Map<Student, Model.Entities.Student>(students.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }

            return studentList;
        }

        #endregion
    }
}
