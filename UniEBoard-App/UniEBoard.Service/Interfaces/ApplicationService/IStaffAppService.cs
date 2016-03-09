// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStaffAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for Staff Application Service Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Service.Models;

namespace UniEBoard.Service.Interfaces.ApplicationService
{
    /// <summary>
    /// IStaffAppService Interface - Contains Methods for Staff Application Service Operations
    /// </summary>
    public interface IStaffAppService : IBaseAppService
    {
        /// <summary>
        /// Gets or sets the staff manager.
        /// </summary>
        /// <value>The staff manager.</value>
        IStaffDomainService StaffManager { get; set; }

        /// <summary>
        /// Gets all the staff.
        /// </summary>
        /// <typeparam name="TStaffViewModel">The type of the staff view model.</typeparam>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        List<StaffViewModel> GetAllStaff();

        /// <summary>
        /// Gets the staff by member ship id.
        /// </summary>
        /// <typeparam name="TStaffViewModel">The type of the staff view model.</typeparam>
        /// <param name="membershipId">The membership id.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        StaffViewModel GetStaffByMemberShipId(int membershipId);

        /// <summary>
        /// Gets the staff by username.
        /// </summary>
        /// <typeparam name="TStaffViewModel">The type of the staff view model.</typeparam>
        /// <param name="membershipId">The membership id.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        StaffViewModel GetStaffByUserName(string username);

        /// <summary>
        /// Creates the staff user.
        /// </summary>
        /// <typeparam name="TRegisterStaffViewModel">The type of the register staff view model.</typeparam>
        /// <param name="membershipId">The membership id.</param>
        /// <param name="model">The model.</param>
        void CreateStaffUser(int membershipId, StaffViewModel model);
    }
}
