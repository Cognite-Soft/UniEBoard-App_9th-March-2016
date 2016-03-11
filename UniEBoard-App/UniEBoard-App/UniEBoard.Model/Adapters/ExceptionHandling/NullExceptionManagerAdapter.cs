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

namespace UniEBoard.Model.Adapters.ExceptionHandling
{
    /// <summary>
    /// Null Exception Manager Adapter class. Used when no exception handling is required
    /// </summary>
    public class NullExceptionManagerAdapter : IExceptionManagerAdapter
    {
        #region Members

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EnterpriseLibraryExceptionManagerAdapter"/> class.
        /// </summary>
        public NullExceptionManagerAdapter()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Does not Handle the exception.
        /// Method has no implementation.
        /// </summary>
        /// <param name="exceptionToHandle">The exception to handle.</param>
        /// <param name="policyName">Name of the policy.</param>
        public void HandleException(Exception exceptionToHandle, PolicyNameType policyName = PolicyNameType.ExceptionShielding)
        {
            // Do nothing
        }

        /// <summary>
        /// Does not process the specified action.
        /// Method has no implementation.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="action">The action.</param>
        /// <param name="policyName">Name of the policy.</param>
        /// <returns>default(TResult)</returns>
        public TResult Process<TResult>(Func<TResult> action, PolicyNameType policyName = PolicyNameType.ExceptionShielding)
        {
            return default(TResult);
        }

        /// <summary>
        /// Does not process the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="policyName">Name of the policy.</param>
        public void Process(Action action, PolicyNameType policyName = PolicyNameType.ExceptionShielding)
        {
            // Do nothing
        }

        #endregion
    }
}
