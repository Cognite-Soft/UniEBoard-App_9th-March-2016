// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Message related Application Service Operations
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
    /// Message Application Service Class - Contains Methods for Message related Application Service Operations
    /// </summary>
    public class MessageAppService : BaseAppService, IMessageAppService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the alert manager.
        /// </summary>
        /// <value>The alert manager.</value>
        public IMessageDomainService MessageManager { get; set; }

        /// <summary>
        /// Gets or sets the student viewed message manager.
        /// </summary>
        /// <value>The student viewed message manager.</value>
        public IStudentViewedMessageDomainService StudentViewedMessageManager { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageAppService"/> class.
        /// </summary>
        /// <param name="MessageManager">The message manager.</param>
        /// <param name="studentViewedMessageManager">The student viewed message manager.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="cacheService">The cache service.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public MessageAppService(
            IMessageDomainService messageManager,
            IStudentViewedMessageDomainService studentViewedMessageManager, 
            IObjectMapperAdapter objectMapper, 
            ICacheAdapter cacheService, 
            IExceptionManagerAdapter exceptionManager, 
            ILoggingServiceAdapter loggingService)
            : base(objectMapper, cacheService, exceptionManager, loggingService)
        {
            this.MessageManager = messageManager;
            this.StudentViewedMessageManager = studentViewedMessageManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all student alerts.
        /// </summary>
        /// <typeparam name="TAlertViewModel">The type of the alert view model.</typeparam>
        /// <param name="student">The student.</param>
        public List<MessageViewModel> GetAllStudentMessages(int studentId)
        {
            List<MessageViewModel> models = new List<MessageViewModel>();
            try
            {
                List<Message> messages = MessageManager.GetAllStudentMessages(studentId);
                models = ObjectMapper.Map<Model.Entities.Message, MessageViewModel>(messages);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets all not viewed student messages.
        /// </summary>
        /// <typeparam name="TAlertViewModel">The type of the alert view model.</typeparam>
        /// <param name="studentId">The student id.</param>
        /// <returns></returns>
        public List<MessageViewModel> GetAllNotViewedStudentMessages(int studentId)
        {
            List<MessageViewModel> models = new List<MessageViewModel>();
            try
            {
                List<Message> messages = MessageManager.GetAllNotViewedStudentMessages(studentId);
                models = ObjectMapper.Map<Model.Entities.Message, MessageViewModel>(messages);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Adds a student Viewed Message.
        /// </summary>
        /// <param name="alertId">The messageId.</param>
        /// <param name="studentId">The studentId.</param>
        /// <returns></returns>
        public void AddStudentViewedMessage(int messageId, int studentId)
        {
            try
            {
                ViewedMessage studentViewedMessage = ObjectMapper.Map<StudentViewedMessageViewModel, Model.Entities.ViewedMessage>(StudentMessageViewModelFactory.CreateStudentViewedMessageModel(messageId, studentId));
                StudentViewedMessageManager.Add(studentViewedMessage);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        /// <summary>
        /// Creates messages
        /// TODO - should be MessageViewModel instead of domain Message model
        /// </summary>
        /// <param name="messages">List of messsages</param>
        /// <returns>true if messages have been successfully created otherwise false</returns>
        public bool AddMessages(List<Message> messages)
        {
            try
            {
                return MessageManager.AddMessages(messages);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return false;
        }

        #endregion
    }
}
