// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISubmissionDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for Submission Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;

namespace UniEBoard.Model.Interfaces.DomainService
{
    /// <summary>
    /// ISubmissionDomainService interface definition - Contains Methods for Submission Operations
    /// </summary>
    public interface ISubmissionDomainService : IBaseDomainService<Submission>
    {
        /// <summary>
        /// Checks if Submissions for assignment already exists.
        /// </summary>
        /// <param name="newSubmission">The new submission.</param>
        /// <returns></returns>
        bool SubmissionForAssignmentAlreadyExists(ref Submission newSubmission);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        List<Model.Entities.Submission> GetSubmissionsForTeacher(int teacherId);
    }
}
