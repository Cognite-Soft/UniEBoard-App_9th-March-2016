// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseModuleAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for all Course and module related operations
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
    /// Course And Module Application Service Class - Contains Methods for all Course and module related operations
    /// </summary>
    public class BaseQuestionTopicAppService : BaseAppService, IBaseQuestionTopicAppService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the course manager.
        /// </summary>
        /// <value>The course manager.</value>
        public IBaseQuestionTopicDomainService BaseQuestionTopicManager { get; set; }


        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseModuleAppService"/> class.
        /// </summary>
        /// <param name="courseManager">The course manager.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="cacheService">The cache service.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public BaseQuestionTopicAppService(
            IBaseQuestionTopicDomainService baseQuestionTopicManager,
            IObjectMapperAdapter objectMapper,
            ICacheAdapter cacheService,
            IExceptionManagerAdapter exceptionManager,
            ILoggingServiceAdapter loggingService)
            : base(objectMapper, cacheService, exceptionManager, loggingService)
        {
            this.BaseQuestionTopicManager = baseQuestionTopicManager;
        }

        #endregion

        #region Methods


        /// <summary>
        /// Gets all student BaseQuestionTopic and modules.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <returns></returns>
        public List<BaseQuestionTopicViewModel> GetAllByStudent(int studentId)
        {
            List<BaseQuestionTopicViewModel> models = new List<BaseQuestionTopicViewModel>();
            try
            {
                List<BaseQuestionTopic> questions = BaseQuestionTopicManager.GetAllByStudent(studentId);
                models = ObjectMapper.Map<Model.Entities.BaseQuestionTopic, BaseQuestionTopicViewModel>(questions);
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
