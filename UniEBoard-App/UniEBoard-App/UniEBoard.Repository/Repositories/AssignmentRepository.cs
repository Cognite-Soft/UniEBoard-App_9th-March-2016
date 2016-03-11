// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssignmentRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for Assignment Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Repository;
using UniEBoard.Model.Interfaces.Adapter;
using System.Data.Entity;
using System.Data.Objects.DataClasses;

namespace UniEBoard.Repository.Repositories
{
    /// <summary>
    /// The Assignment Repository Class
    /// </summary>
    public class AssignmentRepository : BaseRepository<UniEBoardDbContext, Repository.Assignment, Model.Entities.Assignment>, IAssignmentRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignmentRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        public AssignmentRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Finds the assignments by student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        public List<Model.Entities.Assignment> FindAssignmentsByStudentAndCourse(int studentId, int courseId = 0)
        {
            List<Model.Entities.Assignment> assignmentList = new List<Model.Entities.Assignment>();
            try
            {
                IQueryable<Course> course = this.Context.Set<Course>();
                if(courseId > 0)
                {
                    course = course.Where(c => c.Id == courseId);
                }
                IQueryable<Assignment> assignments = from s in this.Context.Set<Student>().Where(s => s.Id == studentId)
                                                     join cr in this.Context.Set<CourseRegistration>() on s.Id equals cr.Student_Id
                                                     join c in course on cr.Course_Id equals c.Id
                                                     join a in this.Context.Set<Assignment>() on c.Id equals a.CourseId
                                                     select a;
                IQueryable<BaseFile> fileUploads = assignments.SelectMany(a => a.FileUploads).Where(f => f.SubmissionId == null);
                IQueryable<Submission> submissions = assignments.SelectMany(a => a.Submissions).Include("FileUploads").Where(s => s.StudentId == studentId);
                List<Assignment> assignmentEntityList = assignments.ToList();
                fileUploads.ToList();
                submissions.ToList();

                // Return Assignments
                assignmentList = ObjectMapper.Map<Assignment, Model.Entities.Assignment>(assignmentEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return assignmentList;
        }

        /// <summary>
        /// Finds the assignment for student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="assignmentId">The assignment id.</param>
        /// <returns></returns>
        public Model.Entities.Assignment FindAssignmentForStudent(int studentId, int assignmentId)
        {
            Model.Entities.Assignment assignment = null;
            try
            {
                IQueryable<Assignment> assignments = (from s in this.Context.Set<Student>().Where(s => s.Id == studentId)
                                                     join cr in this.Context.Set<CourseRegistration>() on s.Id equals cr.Student_Id
                                                     join c in this.Context.Set<Course>() on cr.Course_Id equals c.Id
                                                     join a in this.Context.Set<Assignment>().Where(a => a.Id == assignmentId) on c.Id equals a.CourseId
                                                     select a).Take(1);
                IQueryable<BaseFile> fileUploads = assignments.SelectMany(a => a.FileUploads).Where(f => f.SubmissionId == null);
                IQueryable<Submission> submissions = assignments.SelectMany(a => a.Submissions).Include("FileUploads").Where(s => s.StudentId == studentId);
                List<Assignment> assignmentEntityList = assignments.ToList();
                submissions.ToList();
                fileUploads.ToList();

                // get Assignment
                Assignment assignmentEntity = assignmentEntityList.FirstOrDefault();

                assignment = ObjectMapper.Map<Assignment, Model.Entities.Assignment>(assignmentEntity);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return assignment;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public List<Model.Entities.Assignment> GetAssignmentForTeacher(int teacherId, bool includeSubmissions = false)
        {
            List<Model.Entities.Assignment> assignmentList = new List<Model.Entities.Assignment>();
            try
            {
                IQueryable<Course> course = this.Context.Set<Course>();


                IQueryable<Assignment> assignments = from a in this.Context.Set<Assignment>() 
                                                     join c in course on a.CourseId equals c.Id
                                                     join m in this.Context.Set<StaffCourse>()
                                                         .Where(m => m.Staff_Id.Equals(teacherId))
                                                         on c.Id equals m.Course_Id
                                                     select a;

                if(includeSubmissions)
                {
                    assignments = assignments.Include("Submissions");
                    assignments = assignments.Include("Submissions.Student");
                    assignments = assignments.Include("Course");
                    assignments = assignments.Include("Module");
                    assignments = assignments.Include("Module.CourseModules");
                }
                
                //IQueryable<Assignment> assignments = from a in this.Context.Set<Assignment>()
                //                                     join m in this.Context.Set<Module>() on a.ModuleId equals m.Id
                //                                     join cm in this.Context.Set<CourseModule>() on m.Id equals cm.Module_Id
                //                                     join c in course on cm.Course_Id equals c.Id
                //                                     select a;
                
               

                // Return Assignments
                assignmentList = ObjectMapper.Map<Assignment, Model.Entities.Assignment>(assignments.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }

            return assignmentList;
        }
        #endregion

    }
}
