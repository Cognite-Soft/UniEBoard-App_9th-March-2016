// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TopicDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Topic Operations
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
    /// TopicDomainService class definition - Contains Methods for Topic Operations
    /// </summary>
    public class TopicDomainService : BaseDomainService<Topic, ITopicRepository>, ITopicDomainService
    {
        #region Properties

        /// <summary>
        /// The Topic repository
        /// </summary>
        public ITopicRepository TopicRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TopicDomainService"/> class.
        /// </summary>
        /// <param name="topicRepository">The Topic repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public TopicDomainService(ITopicRepository topicRepository,  IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(topicRepository, exceptionManager, loggingService)
        {
            TopicRepository = topicRepository;
        }


        /// <summary>
        /// Gets the topics by topic id.
        /// </summary>
        /// <param name="topicId">The topic id.</param>
        /// <returns></returns>
        public List<Model.Entities.Topic> GetTopicsByDiscussionId(int topicId)
        {
            return TopicRepository.GetTopicsByDiscussionId(topicId);
        }

        #endregion
    }
}
