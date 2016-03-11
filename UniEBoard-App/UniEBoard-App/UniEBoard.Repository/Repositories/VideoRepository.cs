// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VideoRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for Course Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Repository;
using UniEBoard.Model.Interfaces.Adapter;
using System.Data.Entity;
using System.Data.Objects.DataClasses;

namespace UniEBoard.Repository.Repositories
{
    /// <summary>
    /// The Course Repository Class
    /// </summary>
    public class VideoRepository : BaseRepository<UniEBoardDbContext, Repository.Video, Model.Entities.Video>, IVideoRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        public VideoRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Finds the video by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Model.Entities.Video FindVideoById(int id)
        {
            return ObjectMapper.Map<Video, Model.Entities.Video>(
                this.Context.Set<Video>().FirstOrDefault(p => p.Id.Equals(id)));
        }
       
        #endregion

    }
}
