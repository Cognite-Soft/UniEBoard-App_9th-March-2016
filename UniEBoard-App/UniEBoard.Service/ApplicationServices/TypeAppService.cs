// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for returning Dictionaries of Types
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

namespace UniEBoard.Service.ApplicationServices
{
    /// <summary>
    /// Type Application Service Class - Contains Methods for returning Dictionaries of Types
    /// </summary>
    public class TypeAppService : BaseAppService, ITypeAppService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the type service manager.
        /// </summary>
        /// <value>The type service manager.</value>
        public ITypeDomainService TypeServiceManager { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeAppService"/> class.
        /// </summary>
        /// <param name="typeServiceManager">The type service manager.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="cacheService">The cache service.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public TypeAppService(ITypeDomainService typeServiceManager, IObjectMapperAdapter objectMapper, ICacheAdapter cacheService, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(objectMapper, cacheService, exceptionManager, loggingService)
        {
            this.TypeServiceManager = typeServiceManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all login types.
        /// </summary>
        /// <returns>A Dictionary of all login types</returns>
        public Dictionary<int, string> GetAllLoginTypes()
        {
            
            Dictionary<int, string> loginTypes = null;
            try
            {
                loginTypes = CacheService.Retrieve<Dictionary<int, string>>(C.CacheKeys.LoginTypes);
                if (loginTypes == null)
                {
                    loginTypes = TypeServiceManager.GetAllLoginTypes();
                    CacheService.Store(C.CacheKeys.LoginTypes, loginTypes);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return loginTypes ?? new Dictionary<int, string>();
        }

        /// <summary>
        /// Gets all gender types.
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetAllGenderTypes()
        {

            Dictionary<int, string> genderTypes = null;
            try
            {
                genderTypes = CacheService.Retrieve<Dictionary<int, string>>(C.CacheKeys.GenderTypes);
                if (genderTypes == null)
                {
                    genderTypes = TypeServiceManager.GetAllGenderTypes();
                    CacheService.Store(C.CacheKeys.GenderTypes, genderTypes);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return genderTypes ?? new Dictionary<int, string>();
        }

        /// <summary>
        /// Gets all message types.
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetAllMessageTypes()
        {

            Dictionary<int, string> messageTypes = null;
            try
            {
                messageTypes = CacheService.Retrieve<Dictionary<int, string>>(C.CacheKeys.MessageTypes);
                if (messageTypes == null)
                {
                    messageTypes = TypeServiceManager.GetAllMessageTypes();
                    CacheService.Store(C.CacheKeys.MessageTypes, messageTypes);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return messageTypes ?? new Dictionary<int, string>();
        }

        #endregion
    }
}
