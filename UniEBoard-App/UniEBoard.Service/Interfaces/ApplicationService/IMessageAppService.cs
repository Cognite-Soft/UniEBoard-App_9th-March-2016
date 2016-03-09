// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for Message related Application Service Operations
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
    /// IMessageAppService Interface - Contains Methods for Message related Application Service Operations
    /// </summary>
    public interface IMessageAppService : IBaseAppService
    {
        /// <summary>
        /// Gets or sets the student viewed message manager.
        /// </summary>
        /// <value>The student viewed message manager.</value>
        IStudentViewedMessageDomainService StudentViewedMessageManager { get; set; }

        /// <summary>
        /// Gets or sets the alert manager.
        /// </summary>
        /// <value>The alert manager.</value>
        IMessageDomainService MessageManager { get; set; }

        /// <summary>
        /// Adds a student Viewed Message.
        /// </summary>
        /// <param name="alertId">The messageId.</param>
        /// <param name="studentId">The studentId.</param>
        /// <returns></returns>
        void AddStudentViewedMessage(int messageId, int studentId);

        /// <summary>
        /// Gets all student messages.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        List<MessageViewModel> GetAllStudentMessages(int studentId);

        /// <summary>
        /// Gets all not viewed student messages.
        /// </summary>
        /// <typeparam name="TAlertViewModel">The type of the alert view model.</typeparam>
        /// <param name="studentId">The student id.</param>
        /// <returns></returns>
        List<MessageViewModel> GetAllNotViewedStudentMessages(int studentId);

        /// <summary>
        /// Creates messages
        /// TODO - should be MessageViewModel instead of domain Message model
        /// </summary>
        /// <param name="messages">List of messsages</param>
        /// <returns>true if messages have been successfully created otherwise false</returns>
        bool AddMessages(List<Message> messages);
    }
}
