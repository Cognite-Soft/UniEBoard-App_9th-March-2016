// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IScheduleRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for Schedule Repository CRUD operations.
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
    /// The Schedule Repository Interface
    /// </summary>
    public interface IScheduleRepository : IBaseRepository<Schedule>
    {
        /// <summary>
        /// Finds the schedules by course.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        List<Model.Entities.Schedule> FindSchedulesByCourse(int courseId, List<string> includeAssociations);

        /// <summary>
        /// Finds the schedules by student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="includeAssociations">The include associations.</param>
        /// <returns></returns>
        List<Model.Entities.Schedule> FindSchedulesByStudent(int studentId, List<string> includeAssociations);
    }
}
