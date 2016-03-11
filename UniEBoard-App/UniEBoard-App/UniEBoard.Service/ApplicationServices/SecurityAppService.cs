// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SecurityAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//   Contains Methods for Security Service Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Service.Interfaces.ApplicationService;

namespace UniEBoard.Service.ApplicationServices
{
    /// <summary>
    /// SecurityAppService Service Class - Contains Methods for Security Service Operations
    /// </summary>
    public class SecurityAppService : BaseAppService, ISecurityAppService
    {
        #region Properties

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityAppService"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="cacheService">The cache service.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public SecurityAppService(
            IObjectMapperAdapter objectMapper,
            ICacheAdapter cacheService,
            IExceptionManagerAdapter exceptionManager,
            ILoggingServiceAdapter loggingService)
            : base(objectMapper, cacheService, exceptionManager, loggingService)
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the section roles.
        /// </summary>
        /// <param name="controllername">The controllername.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <returns></returns>
        public string GetSectionRoles(string controllername, string actionName = "Index")
        {
            try
            {
                switch (controllername)
                {
                    case "AdminController":
                        return "Administrator";
                    case "Teacher":
                        return "Administrator, Teacher";
                    default:
                        return string.Empty;
                }           
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
                return string.Empty;
            }
        }


        #endregion
    }
}
