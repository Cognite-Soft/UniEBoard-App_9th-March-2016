// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBaseAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for Base Application Service Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Interfaces.Adapter;

namespace UniEBoard.Service.Interfaces.ApplicationService
{
    /// <summary>
    /// IBaseAppService Interface - Contains Methods for Base Application Service Operations
    /// </summary>
    public interface IBaseAppService
    {
        /// <summary>
        /// Gets or sets the event log service.
        /// </summary>
        /// <value>
        /// The event log service.
        /// </value>
        ILoggingServiceAdapter LoggingService { get; set; }

        /// <summary>
        /// Gets or sets the object mapper.
        /// </summary>
        /// <value>The object mapper.</value>
        IObjectMapperAdapter ObjectMapper { get; set; }

        /// <summary>
        /// Gets or sets the cache service.
        /// </summary>
        /// <value>The cache service.</value>
        ICacheAdapter CacheService { get; set; }

        /// <summary>
        /// Gets or sets the exception manager.
        /// </summary>
        /// <value>The exception manager.</value>
        IExceptionManagerAdapter ExceptionManager { get; set; }
    }
}
