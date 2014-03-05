// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaffRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for Staff Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Repository;
using UniEBoard.Model.Interfaces.Adapter;

namespace UniEBoard.Repository.Repositories
{
    /// <summary>
    /// The Staff Repository Class
    /// </summary>
    public class StaffRepository : BaseRepository<UniEBoardDbContext, Repository.Staff, Model.Entities.Staff>, IStaffRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StaffRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        public StaffRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the staff by member ship id.
        /// </summary>
        /// <param name="membershipId">The membership id.</param>
        /// <returns></returns>
        public Model.Entities.Staff GetStaffByMemberShipId(int membershipId)
        {
            Model.Entities.Staff staff = null;
            try
            {
                IQueryable<Staff> staffQuery = this.Context.Set<Staff>().Where(p => p.Membership_Id == membershipId).Take(1);
                Staff staffEntity = staffQuery.ToList().FirstOrDefault();
                staff = ObjectMapper.Map<Staff, Model.Entities.Staff>(staffEntity);
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
