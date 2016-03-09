// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for Message Operations
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
    /// IMessageDomainService Interface definition - Contains Methods for Message Operations
    /// </summary>
    public interface IMessageDomainService : IBaseDomainService<Message>
    {
        /// <summary>
        /// Gets all student messages.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        List<Message> GetAllStudentMessages(int studentId);

        /// <summary>
        /// Gets all not viewed alerts by student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        List<Message> GetAllNotViewedStudentMessages(int studentId);

        /// <summary>
        /// Add a list of messages to the data source
        /// </summary>
        /// <param name="messages">List of Messsages</param>
        /// <returns>true if successfully added all messages otherwise false</returns>
        bool AddMessages(List<Message> messages);
    }
}
