// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITypeAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for returning Dictionaries of Types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Service.Interfaces.ApplicationService
{
    /// <summary>
    /// Type Service Interface - Contains Interface Methods for returning Dictionaries of Types
    /// </summary>
    public interface ITypeAppService
    {
        /// <summary>
        /// Gets all login types.
        /// </summary>
        /// <returns></returns>
        Dictionary<int, string> GetAllLoginTypes();

        /// <summary>
        /// Gets all login types.
        /// </summary>
        /// <returns></returns>
        Dictionary<int, string> GetAllGenderTypes();
    }
}
