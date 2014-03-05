// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IScheduleAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for all Schedule related operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Service.Models;

namespace UniEBoard.Service.Interfaces.ApplicationService
{
    /// <summary>
    /// IScheduleAppService Interface - Contains Methods for all Schedule related operations
    /// </summary>
    public interface IScheduleAppService : IBaseAppService
    {
        /// <summary>
        /// Gets or sets the Schedule manager.
        /// </summary>
        /// <value>The Schedule manager.</value>
        IScheduleDomainService ScheduleManager { get; set; }

        /// <summary>
        /// Gets the schedules with units and modules by course.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        List<ScheduleViewModel> GetSchedulesWithUnitsAndModulesByCourse(int courseId);

        /// <summary>
        /// Gets the schedules with units and modules by student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <returns></returns>
        List<ScheduleViewModel> GetSchedulesWithUnitsAndModulesByStudent(int studentId);
    }
}
