// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStaffDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for Staff Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;

namespace UniEBoard.Model.Interfaces.DomainService
{
    /// <summary>
    /// IStaffDomainService Interface definition - Contains Methods for Staff Operations
    /// </summary>
    public interface IStaffDomainService : IBaseDomainService<Staff>
    {
        /// <summary>
        /// Gets the staff by member ship id.
        /// </summary>
        /// <param name="membershipId">The membership id.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        Staff GetStaffByMemberShipId(int membershipId);
    }
}
