// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskDomainService.cs" company="Cognite Ltd">
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
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Factories;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Model.Interfaces.Repository;

namespace UniEBoard.Model.DomainServices
{
    /// <summary>
    /// TaskDomainService class definition - Contains Methods for Task Operations
    /// </summary>
    public class TaskDomainService : BaseDomainService<Task, ITaskRepository>, ITaskDomainService
    {
        #region Properties

        /// <summary>
        /// StudentRepository instance
        /// </summary>
        public ITaskRepository TaskRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Students the domain service.
        /// </summary>
        /// <param name="taskRepository">The task repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public TaskDomainService(ITaskRepository taskRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(taskRepository, exceptionManager, loggingService)
        {
            TaskRepository = taskRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the tasks with upcoming deadlines.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        public List<Task> GetTasksWithUpcomingDeadlinesByUser(int userId)
        {
            List<Task> tasks = new List<Task>();
            try
            {
                tasks = GetAllTasksByUser(userId, TaskFilterType.ActiveWithDeadlines);
                tasks.RemoveAll(delegate(Task task)
                {
                    return task.Deadline.HasValue && task.Deadline.Value < DateTime.Today;
                });
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return tasks;
        }

        /// <summary>
        /// Gets the filtered tasks by user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public List<Task> GetAllTasksByUser(int userId, TaskFilterType filter = TaskFilterType.All)
        {
            List<Task> tasks = new List<Task>();
            try
            {
                tasks = TaskRepository.FindAllTasksByUser(userId, filter);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return tasks;
        }

        #endregion
    }
}
