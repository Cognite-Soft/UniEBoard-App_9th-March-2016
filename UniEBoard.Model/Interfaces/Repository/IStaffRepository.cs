// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStaffRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for Staff Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;

namespace UniEBoard.Model.Interfaces.Repository
{
    /// <summary>
    /// The Staff Repository Interface
    /// </summary>
    public interface IStaffRepository : IBaseRepository<Staff>
    {
        /// <summary>
        /// Gets the staff by member ship id.
        /// </summary>
        /// <param name="membershipId">The membership id.</param>
        /// <returns></returns>
        Staff GetStaffByMemberShipId(int membershipId);
    }
}
