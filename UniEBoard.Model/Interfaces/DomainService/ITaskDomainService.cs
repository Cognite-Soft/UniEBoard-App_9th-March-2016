// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITaskDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Task Operations
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
    /// ITaskDomainService Interface definition - Contains Methods for Task Operations
    /// </summary>
    public interface ITaskDomainService : IBaseDomainService<Task>
    {
        /// <summary>
        /// Gets the filtered tasks by user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        List<Task> GetAllTasksByUser(int userId, TaskFilterType filter = TaskFilterType.All);

        /// <summary>
        /// Gets the tasks with upcoming deadlines.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        List<Task> GetTasksWithUpcomingDeadlinesByUser(int userId);
    }
}
