// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Course Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Factories;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Model.Interfaces.Repository;

namespace UniEBoard.Model.DomainServices
{
    /// <summary>
    /// CourseDomainService class definition - Contains Methods for Course Operations
    /// </summary>
    public class CourseDomainService : BaseDomainService<Course, ICourseRepository>, ICourseDomainService
    {
        #region Properties

        /// <summary>
        /// Course Repository Instance
        /// </summary>
        public ICourseRepository CourseRepository;

        public IModuleRepository ModuleRepository;

        public ICourseModuleRepository CourseModuleRepository;

        public IStaffCourseRepository StaffCourseRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseDomainService"/> class.
        /// </summary>
        /// <param name="courseRepository">The course repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public CourseDomainService(
            ICourseRepository courseRepository,
            IModuleRepository moduleRepository, 
            ICourseModuleRepository courseModuleRepository, 
            IStaffCourseRepository staffCourseRepository,  
            IExceptionManagerAdapter exceptionManager, 
            ILoggingServiceAdapter loggingService)
            : base(courseRepository, exceptionManager, loggingService)
        {
            CourseRepository = courseRepository;
            ModuleRepository = moduleRepository;
            this.CourseModuleRepository = courseModuleRepository;
            this.StaffCourseRepository = staffCourseRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all courses and modules by student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="includeModules">if set to <c>true</c> [include modules].</param>
        /// <returns></returns>
        public List<Course> GetAllCoursesByStudent(int studentId, bool includeModules = true)
        {
            List<Course> courses = new List<Course>();
            try
            {
                courses = includeModules 
                    ? CourseRepository.FindCoursesWithModulesByStudent(studentId) 
                    : CourseRepository.FindCoursesByStudent(studentId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return courses;
        }

        /// <summary>
        /// Gets the courses by staff.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        /// <returns></returns>
        public List<Model.Entities.Course> GetCoursesByStaff(int staffId)
        {
            List<Course> courses = new List<Course>();
            try
            {
                courses = CourseRepository.FindCoursesByStaff(staffId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return courses;
        }

        /// <summary>
        /// Get all the modules belong to a course
        /// </summary>
        /// <param name="courseId">The course Id</param>
        /// <returns>Course</returns>
        public Course FindCourseWithModulebyCourseId(int courseId)
        {
            Course courses = new Course();
            try
            {
                //List<string> associations = base.GetpropertyAssociations<C.NavigationalProperties.Course>(m => m.CourseModules, m => m.Modules);
                courses = CourseRepository.FindCourseByCourseId(courseId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return courses;
        }

        /// <summary>
        /// Finds the courseby course id.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        public Course FindCoursebyCourseId(int courseId)
        {
            Course course = new Course();
            try
            {
                course = CourseRepository.FindCourseByCourseId(courseId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return course;
        }

        /// <summary>
        /// Get the module by Id
        /// </summary>
        /// <param name="moduleId">The module Id</param>
        /// <returns>Module</returns>
        public Module FindModulebyId(int moduleId)
        {
            Module modules = new Module();
            try
            {
                modules = ModuleRepository.GetModuleById(moduleId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return modules;
        }

        /// <summary>
        /// Gets the modules by teacher.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <returns></returns>
        public List<Module> GetModulesByTeacher(int teacherId, int view = 0)
        {
            List<Module> modules = new List<Module>();
            try
            {
                modules = ModuleRepository.GetModulesByTeacher(teacherId, view);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return modules;
        }

        /// <summary>
        /// Gets the modules created by teacher.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <returns></returns>
        public List<Module> GetModulesCreatedByTeacher(int teacherId, int view = 0)
        {
            List<Module> modules = new List<Module>();
            try
            {
                modules = ModuleRepository.GetModulesCreatedByTeacher(teacherId, view);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return modules;
        }

        /// <summary>
        /// Gets the modules by student.
        /// </summary>
        /// <param name="teacherId">The student id.</param>
        /// <returns></returns>
        public List<Module> GetModulesByStudent(int studentId, int view = 0)
        {
            List<Module> modules = new List<Module>();
            try
            {
                modules = ModuleRepository.GetModulesByStudent(studentId, view);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return modules;
        }

        /// <summary>
        /// Finds the courses with department by staff id.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        /// <param name="view"></param>
        /// <returns></returns>
        public List<Course> FindCoursesWithDepartmentByStaffId(int staffId, int view)
        {
            List<Course> courseList = new List<Course>();
            courseList = CourseRepository.FindCoursesWithDepartmentByStaffId(staffId, view);

            return courseList;
        }

        /// <summary>
        /// Finds the courses with department by staff id.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        /// <param name="view"></param>
        /// <returns></returns>
        public List<Course> FindCoursesWithDepartmentByStaffId(int staffId, string filter)
        {
            List<Course> courseList = new List<Course>();
            courseList = CourseRepository.FindCoursesWithDepartmentByStaffId(staffId, filter);

            return courseList;
        }


        /// <summary>
        /// Add a course by staff
        /// </summary>
        /// <param name="studentId">The staff id.</param>
        /// <param name="course">course assigned to staffId</param>
        /// <returns></returns>
        public Course AddCourseByStaff(Course course, int staffId)
        {
            Course c = CourseRepository.AddCourseByStaff(course, staffId);
            return c;
        }


        /// <summary>
        /// Remove Course From Module by courseId. 
        /// </summary>
        /// <param name="courseId">Course ID.</param>
        public void RemoveCourseFromModule(int courseId)
        {
            try
            {
                var CourseModuleList = CourseModuleRepository.FindAll().Where(x => x.Course_Id == courseId);
                foreach (var courseModule in CourseModuleList)
                {
                    CourseModuleRepository.Remove(courseModule.Id);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
        }

        /// <summary>
        /// Removes the StaffCourse associative relationship associated with the speicied by courseId
        /// </summary>
        /// <param name="courseId">Course Id</param>
        /// <returns>true if deletion was successfull otherwise returns false</returns>
        public bool RemoveStaffForCourse(int courseId)
        {
            return StaffCourseRepository.RemoveStaffForCourse(courseId);
        }

        /// <summary>
        /// Removes the course and it's associated records
        /// </summary>
        /// <param name="courseId">The course id</param>
        /// <returns>true if deletion is successful otherwise returns false</returns>
        public bool RemoveCourse(int courseId)
        {
            try
            {
                CourseRepository.RemoveCourse(courseId);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseModuleId"></param>
        public void RemoveCourseModule(int courseModuleId)
        {
            try
            {
                CourseRepository.RemoveCourseFromModule(courseModuleId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<CourseModule> GetCourseModulesByModule(int moduleId)
        {
            List<CourseModule> courseModuleList = new List<CourseModule>();
            try
            {
                courseModuleList = CourseRepository.GetCourseModulesByModule(moduleId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }

            return courseModuleList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        public Course GetCourseByName(string courseName)
        {
            Course course = new Course();
            try
            {
                course = CourseRepository.GetCourseByName(courseName);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return course;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseModuleViewModel"></param>
        public void AddCourseModule(CourseModule courseModule)
        {
            try
            {
                CourseRepository.AddCourseModule(courseModule);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public Course GetCourseByIdWithStudents(int courseId)
        {
            Course course = new Course();
            try
            {
                course = CourseRepository.GetCourseByIdWithStudents(courseId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return course;
        }

        #endregion
    }
}
