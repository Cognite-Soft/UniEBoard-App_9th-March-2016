// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IScheduleDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for Schedule Operations
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
    /// IScheduleDomainService interface definition - Contains Methods for Schedule Operations
    /// </summary>
    public interface IScheduleDomainService : IBaseDomainService<Schedule>
    {
        /// <summary>
        /// Gets the schedules with units and modules by course.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        List<Schedule> GetSchedulesWithUnitsAndModulesByCourse(int courseId);

        /// <summary>
        /// Gets the schedules with units and modules by student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <returns></returns>
        List<Schedule> GetSchedulesWithUnitsAndModulesByStudent(int studentId);
    }
}
