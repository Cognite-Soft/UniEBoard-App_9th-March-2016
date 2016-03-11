// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAssignmentDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for Assignment Operations
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
    /// IAssignmentDomainService interface definition - Contains Methods for Assignment Operations
    /// </summary>
    public interface IAssignmentDomainService : IBaseDomainService<Assignment>
    {
        /// <summary>
        /// Gets all assignments by student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        List<Assignment> GetAllAssignmentsByStudentAndCourse(int studentId, StudentAssignmentFilterType filter = StudentAssignmentFilterType.Active, int courseId = 0);

        /// <summary>
        /// Gets the assignment for student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="assignmentId">The assignment id.</param>
        /// <returns></returns>
        Assignment GetAssignmentForStudent(int studentId, int assignmentId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        List<Assignment> GetAssignmentForTeacher(int teacherId, bool includeSubmissions = false);
    }
}
