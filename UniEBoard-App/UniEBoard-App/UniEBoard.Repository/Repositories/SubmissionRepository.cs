// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubmissionRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for Submission Repository CRUD operations.
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
    /// The Submission Repository Class
    /// </summary>
    public class SubmissionRepository : BaseRepository<UniEBoardDbContext, Repository.Submission, Model.Entities.Submission>, ISubmissionRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SubmissionRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        public SubmissionRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Finds the student submission for assignment.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="assignmentId">The assignment id.</param>
        /// <returns></returns>
        public Model.Entities.Submission FindStudentSubmissionForAssignment(int studentId, int assignmentId)
        {
            Model.Entities.Submission submission = null;
            try
            {
                IQueryable<Submission> submissions = this.Context.Set<Submission>().Include("FileUploads").Where(s => s.StudentId == studentId && s.AssignmentId == assignmentId).Take(1);
                
                // get Submission
                Submission submissionEntity = submissions.FirstOrDefault();

                submission = ObjectMapper.Map<Submission, Model.Entities.Submission>(submissionEntity);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return submission;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public List<Model.Entities.Submission> GetSubmissionsForStudent(int studentId, int courseId)
        {
            List<Model.Entities.Submission> submissionList = new List<Model.Entities.Submission>();
            try
            {
                // Fetch Active Tasks

                IQueryable<Submission> submissionss = from sub in this.Context.Set<Submission>()
                                                          .Include("Assignment")
                                                          .Include("Assignment.Module")
                                                      where (sub.StudentId == studentId && sub.Assignment.CourseId == courseId)
                                                      select sub;

                // Return Tasks
                submissionList = ObjectMapper.Map<Submission, Model.Entities.Submission>(submissionss.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return submissionList;
        }

       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        public List<Model.Entities.Submission> GetSubmissionsForTeacher(int teacherId)
        {
            List<Model.Entities.Submission> submissionList = new List<Model.Entities.Submission>();
            try
            {
                // Fetch Active Tasks

                IQueryable<Submission> submissions = from a in this.Context.Set<Assignment>()
                                                     join c in this.Context.Set<Course>() 
                                                        on a.CourseId equals c.Id
                                                     join m in this.Context.Set<StaffCourse>()
                                                         .Where(m => m.Staff_Id.Equals(teacherId))
                                                         on c.Id equals m.Course_Id
                                                     join s in this.Context.Set<Submission>()
                                                        on a.Id equals s.AssignmentId
                                                     select s;

                // Return Tasks
                submissionList = ObjectMapper.Map<Submission, Model.Entities.Submission>(submissions.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return submissionList;
        }

        #endregion
    }
}
