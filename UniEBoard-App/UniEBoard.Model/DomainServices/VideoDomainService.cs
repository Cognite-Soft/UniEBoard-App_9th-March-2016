// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VideoDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Unit Operations
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
    /// VideoDomainService class definition - Contains Methods for Video Operations
    /// </summary>
    public class VideoDomainService : BaseDomainService<Video, IVideoRepository>, IVideoDomainService
    {
        #region Properties

        /// <summary>
        /// VideoRepository instance
        /// </summary>
        public IVideoRepository VideoRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Students the domain service.
        /// </summary>
        /// <param name="taskRepository">The task repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public VideoDomainService(IVideoRepository videoRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(videoRepository, exceptionManager, loggingService)
        {
            VideoRepository = videoRepository;
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
            return VideoRepository.FindVideoById(id);
        }
        #endregion



    }
}
