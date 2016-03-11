// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Base Application Service Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Service.Interfaces.ApplicationService;

namespace UniEBoard.Service.ApplicationServices
{
    /// <summary>
    /// Base Application Service Class - Contains Methods for Base Application Service Operations
    /// </summary>
    public class BaseAppService : IBaseAppService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the object mapper.
        /// </summary>
        /// <value>The object mapper.</value>
        public IObjectMapperAdapter ObjectMapper { get; set; }

        /// <summary>
        /// Gets or sets the event log service.
        /// </summary>
        /// <value>The event log service.</value>
        public ILoggingServiceAdapter LoggingService { get; set; }
        
        /// <summary>
        /// Gets or sets the cache service.
        /// </summary>
        /// <value>The cache service.</value>
        public ICacheAdapter CacheService { get; set; }

        /// <summary>
        /// Gets or sets the exception manager.
        /// </summary>
        /// <value>The exception manager.</value>
        public IExceptionManagerAdapter ExceptionManager { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAppService"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="cacheService">The cache service.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public BaseAppService(IObjectMapperAdapter objectMapper, ICacheAdapter cacheService, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
        {
            this.ObjectMapper = objectMapper;
            this.CacheService = cacheService;
            this.ExceptionManager = exceptionManager;
            this.LoggingService = loggingService;
        }

        #endregion
    }
}
