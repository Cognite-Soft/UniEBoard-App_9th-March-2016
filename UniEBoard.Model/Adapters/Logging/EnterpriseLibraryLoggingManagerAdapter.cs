// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnterpriseLibraryLoggingManagerAdapter.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for logging.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using EntLog = Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UniEBoard.Model.Interfaces.Adapter;

namespace UniEBoard.Model.Adapters.Logging
{
    /// <summary>
    /// Enterprise Library Logging Manager Adapter class
    /// </summary>
    public class EnterpriseLibraryLoggingManagerAdapter : ILoggingServiceAdapter
    {
        #region Members

        /// <summary>
        /// Enterprise Log writer instance
        /// </summary>
        private EntLog.LogWriter _loggingManager;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether [logging enabled].
        /// </summary>
        /// <value><c>true</c> if [logging enabled]; otherwise, <c>false</c>.</value>
        public bool LoggingEnabled { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EnterpriseLibraryLoggingManagerAdapter"/> class.
        /// </summary>
        public EnterpriseLibraryLoggingManagerAdapter()
        {
            _loggingManager = EnterpriseLibraryContainer.Current.GetInstance<EntLog.LogWriter>();
            LoggingEnabled = _loggingManager.IsLoggingEnabled();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Writes the specified log.
        /// </summary>
        /// <param name="log">The log.</param>
        public void Write(object message)
        {
            if (LoggingEnabled)
            {
                _loggingManager.Write(message);
            }
        }

        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="category">The category.</param>
        public void Write(object message, string category)
        {
            if (LoggingEnabled)
            {
                _loggingManager.Write(message, category);
            }
        }

        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="category">The category.</param>
        /// <param name="priority">The priority.</param>
        public void Write(object message, string category, int priority)
        {
            if (LoggingEnabled)
            {
                _loggingManager.Write(message, category, priority);
            }
        }

        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="category">The category.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="eventId">The event id.</param>
        public void Write(object message, string category, int priority, int eventId)
        {
            if (LoggingEnabled)
            {
                _loggingManager.Write(message, category, priority, eventId);
            }
        }

        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="category">The category.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="eventId">The event id.</param>
        /// <param name="severity">The severity.</param>
        public void Write(object message, string category, int priority, int eventId, TraceEventType severity)
        {
            if (LoggingEnabled)
            {
                _loggingManager.Write(message, category, priority, eventId, severity);
            }
        }

        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="category">The category.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="eventId">The event id.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="title">The title.</param>
        public void Write(object message, string category, int priority, int eventId, TraceEventType severity, string title)
        {
            if (LoggingEnabled)
            {
                _loggingManager.Write(message, category, priority, eventId, severity, title);
            }
        }

        #endregion
    }
}
