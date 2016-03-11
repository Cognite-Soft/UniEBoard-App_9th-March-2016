// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseQuestionTopicDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for BaseQuestionTopic Operations
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
    /// BaseQuestionTopicDomainService class definition - Contains Methods for BaseQuestionTopic Operations
    /// </summary>
    public class BaseQuestionTopicDomainService : BaseDomainService<BaseQuestionTopic, IBaseQuestionTopicRepository>, IBaseQuestionTopicDomainService
    {
        #region Properties

        /// <summary>
        /// BaseQuestion Repository Instance
        /// </summary>
        public IBaseQuestionTopicRepository BaseQuestionTopicRepository;


        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseDomainService"/> class.
        /// </summary>
        /// <param name="courseRepository">The course repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public BaseQuestionTopicDomainService(IBaseQuestionTopicRepository baseQuestionTopicRepository, IModuleRepository moduleRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(baseQuestionTopicRepository, exceptionManager, loggingService)
        {
            BaseQuestionTopicRepository = baseQuestionTopicRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get all the questionsTopic by studentId
        /// </summary>
        /// <param name="studentId">The Student Id</param>
        /// <returns>list of BasequestionTopics</returns>
        public List<BaseQuestionTopic> GetAllByStudent(int studentId)
        {
            List<BaseQuestionTopic> questions = new List<BaseQuestionTopic>();
            try
            {
                questions = BaseQuestionTopicRepository.FindByStudentId(studentId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return questions;
        }

        #endregion





    }
}
