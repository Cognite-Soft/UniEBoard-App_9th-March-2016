// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for Task Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Repository;
using UniEBoard.Model.Interfaces.Adapter;

namespace UniEBoard.Repository.Repositories
{
    /// <summary>
    /// The Task Repository Class
    /// </summary>
    public class TaskRepository : BaseRepository<UniEBoardDbContext, Repository.Task, Model.Entities.Task>, ITaskRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        public TaskRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Finds the active tasks by user.
        /// </summary>
        /// <param name="userId">The student id.</param>
        /// <returns></returns>
        public List<Model.Entities.Task> FindActiveTasksByUser(int userId)
        {
            List<Model.Entities.Task> taskModelList = new List<Model.Entities.Task>();
            try
            {
                // Fetch Active Tasks
                List<Task> taskEntityList = this.Context.Set<Task>().Where(p => p.UserId == userId && p.IsCompleted == false && (p.Deadline >= DateTime.Today || !p.Deadline.HasValue)).ToList();

                // Return Tasks
                taskModelList = ObjectMapper.Map<Task, Model.Entities.Task>(taskEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return taskModelList;
        }

        /// <summary>
        /// Finds tasks by user and filter.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public List<Model.Entities.Task> FindAllTasksByUser(int userId, TaskFilterType filter = TaskFilterType.All)
        {
            List<Model.Entities.Task> taskModelList = new List<Model.Entities.Task>();
            try
            {
                List<Task> taskEntityList;
                switch (filter)
                {
                    case TaskFilterType.All:
                        taskEntityList = this.Context.Set<Task>().Where(p => p.UserId == userId).ToList();
                        break;
                    case TaskFilterType.Active:
                        taskEntityList = this.Context.Set<Task>().Where(p => p.UserId == userId && p.IsCompleted == false).ToList();
                        break;
                    case TaskFilterType.ActiveWithDeadlines:
                        taskEntityList = this.Context.Set<Task>().Where(p => p.UserId == userId && p.IsCompleted == false && p.Deadline.HasValue).ToList();
                        break;
                    case TaskFilterType.Completed:
                        taskEntityList = this.Context.Set<Task>().Where(p => p.UserId == userId && p.IsCompleted == true).ToList();
                        break;
                    default:
                        taskEntityList = new List<Task>();
                        break;
                }

                // Return Tasks
                taskModelList = ObjectMapper.Map<Task, Model.Entities.Task>(taskEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return taskModelList;
        }

        #endregion
    }
}
