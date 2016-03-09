// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains generic Methods for Converting Enum Types to Dictionary Lists
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Cognite.Utility.Helpers.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Model.Interfaces.Repository;

namespace UniEBoard.Model.DomainServices
{
    /// <summary>
    /// TypeDomainService class definition - Contains generic Methods for Converting Enum Types to Dictionary Lists
    /// </summary>
    public class TypeDomainService : ITypeDomainService
    {
        #region Properties

        /// <summary>
        /// Exception Manager Adapter
        /// </summary>
        public IExceptionManagerAdapter ExceptionManager;

        /// <summary>
        /// Logging Service Adapter
        /// </summary>
        public ILoggingServiceAdapter LoggingService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeDomainService"/> class.
        /// </summary>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public TypeDomainService(IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
        {
            this.ExceptionManager = exceptionManager;
            this.LoggingService = loggingService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all login types.
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetAllLoginTypes()
        {
            return GetAllTypeValues<LoginType>();
        }

        /// <summary>
        /// Gets all gender types.
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetAllGenderTypes()
        {
            return GetAllTypeValues<GenderType>();
        }

        /// <summary>
        /// Gets all message types.
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetAllMessageTypes()
        {
            return GetAllTypeValues<MessageType>();
        }

        /// <summary>
        /// Gets the types.
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, string> GetAllTypeValues<TEnumType>()
        {
            Dictionary<int, string> types = new Dictionary<int, string>();
            try
            {
                types = EnumHelper.DictionaryOf<TEnumType>();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return types;
        }

        #endregion
    }
}
