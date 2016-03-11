// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubmissionDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Submission Operations
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
    /// SubmissionDomainService class definition - Contains Methods for Submission Operations
    /// </summary>
    public class SubmissionDomainService : BaseDomainService<Submission, ISubmissionRepository>, ISubmissionDomainService
    {
        #region Properties

        /// <summary>
        /// Submission Repository Instance
        /// </summary>
        public ISubmissionRepository SubmissionRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SubmissionDomainService"/> class.
        /// </summary>
        /// <param name="submissionRepository">The submission repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public SubmissionDomainService(ISubmissionRepository submissionRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(submissionRepository, exceptionManager, loggingService)
        {
            SubmissionRepository = submissionRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks if Submissions for assignment already exists.
        /// </summary>
        /// <param name="newSubmission">The new submission.</param>
        /// <returns></returns>
        public bool SubmissionForAssignmentAlreadyExists(ref Submission newSubmission)
        {
            bool exists = false;
            try
            {           
                if (newSubmission != null && newSubmission.Id == 0)
                {
                    Submission existingSubmission = SubmissionRepository.FindStudentSubmissionForAssignment(newSubmission.StudentId, newSubmission.AssignmentId);
                    if (existingSubmission != null)
                    {
                        exists = true;
                        newSubmission.Id = existingSubmission.Id;
                    }
                }       
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return exists;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        public List<Submission> GetSubmissionsForTeacher(int teacherId)
        {
            List<Submission> submissions = new List<Submission>();
            
            try
            {
                submissions = SubmissionRepository.GetSubmissionsForTeacher(teacherId);
            }           
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }

            return submissions;
        }


        #endregion


       
    }
}
