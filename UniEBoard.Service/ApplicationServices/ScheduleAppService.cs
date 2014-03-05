// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScheduleAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for all Schedule related operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Service.Interfaces.ApplicationService;
using UniEBoard.Service.Models;
using UniEBoard.Service.Factories;
using UniEBoard.Model.Adapters.Logging;

namespace UniEBoard.Service.ApplicationServices
{
    /// <summary>
    /// Schedule Application Service Class - Contains Methods for all Schedule related operations
    /// </summary>
    public class ScheduleAppService : BaseAppService, IScheduleAppService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Schedule manager.
        /// </summary>
        /// <value>The Schedule manager.</value>
        public IScheduleDomainService ScheduleManager { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleModuleAppService"/> class.
        /// </summary>
        /// <param name="ScheduleManager">The Schedule manager.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="cacheService">The cache service.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public ScheduleAppService(
            IScheduleDomainService ScheduleManager,
            IObjectMapperAdapter objectMapper,
            ICacheAdapter cacheService,
            IExceptionManagerAdapter exceptionManager,
            ILoggingServiceAdapter loggingService)
            : base(objectMapper, cacheService, exceptionManager, loggingService)
        {
            this.ScheduleManager = ScheduleManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the schedules by course.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        public List<ScheduleViewModel> GetSchedulesWithUnitsAndModulesByCourse(int courseId)
        {
            List<ScheduleViewModel> models = new List<ScheduleViewModel>();
            try
            {
                List<Schedule> Schedules = ScheduleManager.GetSchedulesWithUnitsAndModulesByCourse(courseId);
                models = ObjectMapper.Map<Model.Entities.Schedule, ScheduleViewModel>(Schedules);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets the schedules with units and modules by student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <returns></returns>
        public List<ScheduleViewModel> GetSchedulesWithUnitsAndModulesByStudent(int studentId)
        {
            List<ScheduleViewModel> models = new List<ScheduleViewModel>();
            try
            {
                List<Schedule> Schedules = ScheduleManager.GetSchedulesWithUnitsAndModulesByStudent(studentId);
                models = ObjectMapper.Map<Model.Entities.Schedule, ScheduleViewModel>(Schedules);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        #endregion
    }
}
