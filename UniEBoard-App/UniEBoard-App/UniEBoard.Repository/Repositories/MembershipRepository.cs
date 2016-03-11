// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MembershipRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for Membership CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Entity;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.Repository;

namespace UniEBoard.Repository.Repositories
{
    /// <summary>
    /// The Membership Repository Class
    /// </summary>
    public class MembershipRepository : BaseRepository<UniEBoardDbContext, Repository.Membership, Model.Entities.Membership>, IMembershipRepository
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MembershipRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        public MembershipRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Properties
        #endregion
    }
}
