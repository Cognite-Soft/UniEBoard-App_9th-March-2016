// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for Message Repository CRUD operations.
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
    /// The Message Repository Interface
    /// </summary>
    public interface IMessageRepository : IBaseRepository<Message>
    {

        /// <summary>
        /// Gets all student messages.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="associations">The associations.</param>
        /// <returns></returns>
        List<Message> GetAllStudentMessages(int studentId);

        /// <summary>
        /// Add a list of messages to the data source
        /// </summary>
        /// <param name="messages">List of Messsages</param>
        void AddMessages(List<Message> messages);
    }
}
