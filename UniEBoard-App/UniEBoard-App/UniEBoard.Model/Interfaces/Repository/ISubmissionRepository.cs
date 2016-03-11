// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISubmissionRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for Submission Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;

namespace UniEBoard.Model.Interfaces.Repository
{
    /// <summary>
    /// The Submission Repository Interface
    /// </summary>
    public interface ISubmissionRepository : IBaseRepository<Submission>
    {
        /// <summary>
        /// Finds the student submission for assignment.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="assignmentId">The assignment id.</param>
        /// <returns></returns>
        Submission FindStudentSubmissionForAssignment(int studentId, int assignmentId);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        List<Model.Entities.Submission> GetSubmissionsForStudent(int studentId, int courseId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        List<Model.Entities.Submission> GetSubmissionsForTeacher(int teacherId);
    }
}
