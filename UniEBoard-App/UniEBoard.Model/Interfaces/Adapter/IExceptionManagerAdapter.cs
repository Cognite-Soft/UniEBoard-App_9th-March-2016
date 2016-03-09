// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IExceptionManager.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for managing exceptions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;

namespace UniEBoard.Model.Interfaces.Adapter
{
    /// <summary>
    /// Exception Manager Sevice Interface
    /// </summary>
    public interface IExceptionManagerAdapter
    {
        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exceptionToHandle">The exception to handle.</param>
        /// <param name="policyName">Name of the policy.</param>
        void HandleException(Exception exceptionToHandle, PolicyNameType policyName = PolicyNameType.ExceptionShielding);

        /// <summary>
        /// Processes the specified action.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="action">The action.</param>
        /// <param name="policyName">Name of the policy.</param>
        /// <returns></returns>
        TResult Process<TResult>(Func<TResult> action, PolicyNameType policyName = PolicyNameType.ExceptionShielding);

        /// <summary>
        /// Processes the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="policyName">Name of the policy.</param>
        void Process(Action action, PolicyNameType policyName = PolicyNameType.ExceptionShielding);
    }
}
