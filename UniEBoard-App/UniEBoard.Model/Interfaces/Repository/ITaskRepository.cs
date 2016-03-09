// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITaskRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for Task Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;

namespace UniEBoard.Model.Interfaces.Repository
{
    /// <summary>
    /// The Task Repository Interface
    /// </summary>
    public interface ITaskRepository : IBaseRepository<Task>
    {
        /// <summary>
        /// Finds the active tasks by user.
        /// </summary>
        /// <param name="studentId">The user id.</param>
        /// <returns></returns>
        List<Model.Entities.Task> FindActiveTasksByUser(int userId);

        /// <summary>
        /// Finds tasks by user and filter.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        List<Model.Entities.Task> FindAllTasksByUser(int userId, TaskFilterType filter = TaskFilterType.All);
    }
}
