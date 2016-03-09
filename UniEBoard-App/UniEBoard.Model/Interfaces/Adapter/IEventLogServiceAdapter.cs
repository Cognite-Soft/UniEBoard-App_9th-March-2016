// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEventLogService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for Logging operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Interfaces.Adapter
{
    /// <summary>
    /// The Event Log Service Interface
    /// </summary>
    public interface ILoggingServiceAdapter
    {
        /// <summary>
        /// Gets or sets a value indicating whether [logging enabled].
        /// </summary>
        /// <value><c>true</c> if [logging enabled]; otherwise, <c>false</c>.</value>
        bool LoggingEnabled { get; set; }

        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Write(object message);

        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="category">The category.</param>
        void Write(object message, string category);

        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="category">The category.</param>
        /// <param name="priority">The priority.</param>
        void Write(object message, string category, int priority);

        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="category">The category.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="eventId">The event id.</param>
        void Write(object message, string category, int priority, int eventId);

        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="category">The category.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="eventId">The event id.</param>
        /// <param name="severity">The severity.</param>
        void Write(object message, string category, int priority, int eventId, System.Diagnostics.TraceEventType severity);

        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="category">The category.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="eventId">The event id.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="title">The title.</param>
        void Write(object message, string category, int priority, int eventId, System.Diagnostics.TraceEventType severity, string title);
    }
}
