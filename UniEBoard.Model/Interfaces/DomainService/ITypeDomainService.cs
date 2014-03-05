// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITypeDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains generic Interface Methods for Converting Enum Types to Dictionary Lists
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Interfaces.DomainService
{
    /// <summary>
    /// ITypeDomainService Interface definition - Contains generic Methods for Converting Enum Types to Dictionary Lists
    /// </summary>
    public interface ITypeDomainService
    {
        /// <summary>
        /// Gets all login types.
        /// </summary>
        /// <returns></returns>
        Dictionary<int, string> GetAllLoginTypes();

        /// <summary>
        /// Gets all gender types.
        /// </summary>
        /// <returns></returns>
        Dictionary<int, string> GetAllGenderTypes();

        /// <summary>
        /// Gets all message types.
        /// </summary>
        /// <returns></returns>
        Dictionary<int, string> GetAllMessageTypes();
    }
}
