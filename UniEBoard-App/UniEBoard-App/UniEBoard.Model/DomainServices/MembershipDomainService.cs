// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MembershipDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for membership Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Model.Interfaces.Repository;

namespace UniEBoard.Model.DomainServices
{
    /// <summary>
    /// MembershipDomainService class definition - Contains Methods for membership Operations
    /// </summary>
    public class MembershipDomainService : BaseDomainService<Membership, IMembershipRepository>, IMembershipDomainService
    {
        #region Properties

        /// <summary>
        /// MembershipRepository instance
        /// </summary>
        public IMembershipRepository MembershipRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MembershipDomainService"/> class.
        /// </summary>
        /// <param name="membershipRepository">The membership repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public MembershipDomainService(IMembershipRepository membershipRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(membershipRepository, exceptionManager, loggingService)
        {
            MembershipRepository = membershipRepository;
        }

        #endregion
    }
}
