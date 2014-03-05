// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaffDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Staff Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Factories;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Model.Interfaces.Repository;

namespace UniEBoard.Model.DomainServices
{
    /// <summary>
    /// StaffDomainService class definition - Contains Methods for Staff Operations
    /// </summary>
    public class StaffDomainService : BaseDomainService<Staff, IStaffRepository>, IStaffDomainService
    {
        #region Properties

        /// <summary>
        /// StaffRepository instance
        /// </summary>
        public IStaffRepository StaffRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StaffDomainService"/> class.
        /// </summary>
        /// <param name="staffRepository">The staff repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public StaffDomainService(IStaffRepository staffRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(staffRepository, exceptionManager, loggingService)
        {
            StaffRepository = staffRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the staff by member ship id.
        /// </summary>
        /// <param name="membershipId">The membership id.</param>
        /// <returns></returns>
        public Staff GetStaffByMemberShipId(int membershipId)
        {
            Staff staff = null;
            try
            {
                staff = StaffRepository.GetStaffByMemberShipId(membershipId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return staff;
        }

        #endregion
    }
}
