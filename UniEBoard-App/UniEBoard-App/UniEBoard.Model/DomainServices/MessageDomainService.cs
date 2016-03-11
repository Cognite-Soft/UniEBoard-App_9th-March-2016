// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Message Operations
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
    /// MessageDomainService class definition - Contains Methods for Message Operations
    /// </summary>
    public class MessageDomainService : BaseDomainService<Message, IMessageRepository>, IMessageDomainService
    {
        #region Properties

        /// <summary>
        /// Message Repository Instance
        /// </summary>
        public IMessageRepository MessageRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageDomainService"/> class.
        /// </summary>
        /// <param name="messageRepository">The message repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public MessageDomainService(IMessageRepository messageRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(messageRepository, exceptionManager, loggingService)
        {
            MessageRepository = messageRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all student messages.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public List<Message> GetAllStudentMessages(int studentId)
        {
            List<Message> messages = new List<Message>();
            try
            {
                messages = MessageRepository.GetAllStudentMessages(studentId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return messages;
        }


        /// <summary>
        /// Gets all not viewed alerts by student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public List<Message> GetAllNotViewedStudentMessages(int studentId)
        {
            List<Message> messages = new List<Message>();
            try
            {
               messages = GetAllStudentMessages(studentId);
               messages.RemoveAll(delegate(Message m){
                    return m.ViewedMessages.Count > 0;
               });
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return messages;
        }

        #endregion


        public bool AddMessages(List<Message> messages)
        {
            try
            {
                MessageRepository.AddMessages(messages);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
                return false;
            }
        }
    }
}
