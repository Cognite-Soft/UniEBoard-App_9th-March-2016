// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssignmentDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Assignment Operations
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
    /// AssignmentDomainService class definition - Contains Methods for Assignment Operations
    /// </summary>
    public class AssignmentDomainService : BaseDomainService<Assignment, IAssignmentRepository>, IAssignmentDomainService
    {
        #region Properties

        /// <summary>
        /// Assignment Repository Instance
        /// </summary>
        public IAssignmentRepository AssignmentRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignmentDomainService"/> class.
        /// </summary>
        /// <param name="assignmentRepository">The assignment repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public AssignmentDomainService(IAssignmentRepository assignmentRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(assignmentRepository, exceptionManager, loggingService)
        {
            AssignmentRepository = assignmentRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all assignments by student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        public List<Assignment> GetAllAssignmentsByStudentAndCourse(int studentId, StudentAssignmentFilterType filter = StudentAssignmentFilterType.Active, int courseId = 0)
        {
            List<Assignment> assignments = new List<Assignment>();
            try
            {
                assignments = AssignmentRepository.FindAssignmentsByStudentAndCourse(studentId,courseId);
                switch (filter)
                {
                    case StudentAssignmentFilterType.Active:
                        assignments.RemoveAll(SubmittedAssignmentMatches);
                        break;
                    case StudentAssignmentFilterType.Submitted:
                        assignments.RemoveAll(ActiveAssignmentMatches);
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return assignments;
        }

        /// <summary>
        /// Gets the assignment for student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="assignmentId">The assignment id.</param>
        /// <returns></returns>
        public Assignment GetAssignmentForStudent(int studentId, int assignmentId)
        {
            Assignment assignment = null;
            try
            {
                assignment = AssignmentRepository.FindAssignmentForStudent(studentId, assignmentId);
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
        /// <returns></returns>
        public List<Assignment> GetAssignmentForTeacher(int teacherId, bool includeSubmissions = false) 
        {
            List<Assignment> assignments = new List<Assignment>();

            try
            {
                assignments = AssignmentRepository.GetAssignmentForTeacher(teacherId, includeSubmissions);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }


            return assignments;
        }




        #endregion

        #region Predicates

        /// <summary>
        /// Match any Assigments with Submissions
        /// </summary>
        private Predicate<Assignment> SubmittedAssignmentMatches = delegate(Assignment assignmentItem)
        {
            bool match = false;
            if (assignmentItem.Submissions != null)
            {
                foreach (Submission submission in assignmentItem.Submissions)
                {
                    if (!(submission.Status == (int)SubmissionStatusType.New || submission.Status == 0))
                    {
                        match = true;
                    }
                    break;
                }
            }
            return match;
        };

        /// <summary>
        /// Match any Assigments with Submissions
        /// </summary>
        private Predicate<Assignment> ActiveAssignmentMatches = delegate(Assignment assignmentItem)
        {
            bool match = true;
            if (assignmentItem.Submissions != null)
            {
                foreach (Submission submission in assignmentItem.Submissions)
                {
                    if (!(submission.Status == (int)SubmissionStatusType.New || submission.Status == 0))
                    {
                        match = false;
                    }
                    break;
                }
            }
            return match;
        };

        #endregion
    }
}
