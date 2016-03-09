// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnterpriseLibraryExceptionManagerAdapter.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Exception management using Microsoft Enterprise 5.0 Framework
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using EntEx = Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using EntExLog = Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace UniEBoard.Model.Adapters.ExceptionHandling
{
    /// <summary>
    /// Enterprise Library Exception Manager Adapter class
    /// </summary>
    public class EnterpriseLibraryExceptionManagerAdapter : IExceptionManagerAdapter
    {
        #region Members

        /// <summary>
        /// Enterprise ExceptionManager instance
        /// </summary>
        private EntEx.ExceptionManager _exceptionManager;

        private ILog logger;

        #endregion

        #region Properties 
        protected ILog Logger
        {
            get
            {
                if (logger == null)
                {
                    return log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                }
                return logger;
            }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EnterpriseLibraryExceptionManagerAdapter"/> class.
        /// </summary>
        public EnterpriseLibraryExceptionManagerAdapter()
        {
            _exceptionManager = EnterpriseLibraryContainer.Current.GetInstance<EntEx.ExceptionManager>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exceptionToHandle">The exception to handle.</param>
        /// <param name="policyName">Name of the policy.</param>
        public void HandleException(Exception exceptionToHandle, PolicyNameType policyName = PolicyNameType.ExceptionShielding)
        {
            Exception newException;
            Logger.Error("An error occurred while processing your request: ", exceptionToHandle);
            bool reThrow = _exceptionManager.HandleException(exceptionToHandle, GetPolicyName(policyName), out newException);
            if (reThrow)
            {
                throw newException;
            }
        }

        /// <summary>
        /// Processes the specified action.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="action">The action.</param>
        /// <param name="policyName">Name of the policy.</param>
        /// <returns></returns>
        public TResult Process<TResult>(Func<TResult> action, PolicyNameType policyName = PolicyNameType.ExceptionShielding)
        {
            return _exceptionManager.Process<TResult>(action, GetPolicyName(policyName));
        }

        /// <summary>
        /// Processes the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="policyName">Name of the policy.</param>
        public void Process(Action action, PolicyNameType policyName = PolicyNameType.ExceptionShielding)
        {
            _exceptionManager.Process(action, GetPolicyName(policyName));
        }

        /// <summary>
        /// Gets the name of the policy.
        /// </summary>
        /// <param name="policyName">Name of the policy.</param>
        /// <returns></returns>
        private string GetPolicyName(PolicyNameType policyName)
        {
            string returnedPolicyName;
            switch (policyName)
            {
                case PolicyNameType.ExceptionShielding:
                    returnedPolicyName = C.ExceptionPolicy.Names.ExceptionShielding;
                    break;
                default:
                    returnedPolicyName = C.ExceptionPolicy.Names.ExceptionReplacing;
                    break;
            }
            return returnedPolicyName;
        }

        #endregion
    }
}
