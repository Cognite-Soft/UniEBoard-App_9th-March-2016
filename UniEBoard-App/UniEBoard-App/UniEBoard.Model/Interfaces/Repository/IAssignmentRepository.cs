// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAssignmentRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for Assignment Repository CRUD operations.
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
    /// The Assignment Repository Interface
    /// </summary>
    public interface IAssignmentRepository : IBaseRepository<Assignment>
    {
        /// <summary>
        /// Finds the assignments by student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        List<Model.Entities.Assignment> FindAssignmentsByStudentAndCourse(int studentId, int courseId = 0);

        /// <summary>
        /// Finds the assignment for student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="assignmentId">The assignment id.</param>
        /// <returns></returns>
        Assignment FindAssignmentForStudent(int studentId, int assignmentId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        List<Assignment> GetAssignmentForTeacher(int teacherId, bool includeSubmissions = false);
    }
}
