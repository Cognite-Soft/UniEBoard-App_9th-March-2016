// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewedMessageRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for Viewed Message Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Interfaces.Repository;
using UniEBoard.Model.Interfaces.Adapter;

namespace UniEBoard.Repository.Repositories
{
    /// <summary>
    /// The Viewed Message Repository Class
    /// </summary>
    public class ViewedMessageRepository : BaseRepository<UniEBoardDbContext, Repository.ViewedMessage, Model.Entities.ViewedMessage>, IViewedMessageRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewedMessageRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        public ViewedMessageRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion
    }
}
