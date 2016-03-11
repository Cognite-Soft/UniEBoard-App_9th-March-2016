// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TopicPostDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for TopicPost Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using UniEBoard.Model.Entities;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Model.Interfaces.Repository;
using System.Collections.Generic;
using System;
using UniEBoard.Model.Enums;
using System.Linq;

namespace UniEBoard.Model.DomainServices
{
    /// <summary>
    /// TopicPostDomainService class definition - Contains Methods for TopicPost Operations
    /// </summary>
    public class TopicPostDomainService : BaseDomainService<TopicPost, ITopicPostRepository>, ITopicPostDomainService
    {
        #region Properties

        /// <summary>
        /// The TopicPost repository
        /// </summary>
        public ITopicPostRepository TopicPostRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TopicPostDomainService"/> class.
        /// </summary>
        /// <param name="topicPostRepository">The TopicPost repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public TopicPostDomainService(ITopicPostRepository topicPostRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(topicPostRepository, exceptionManager, loggingService)
        {
            TopicPostRepository = topicPostRepository;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Gets the topic posts by topic id.
        /// </summary>
        /// <param name="topicId">The topic id.</param>
        /// <returns></returns>
        public List<TopicPost> GetTopicPostsByTopicId(int topicId)
        {
            List<TopicPost> topicPosts = new List<TopicPost>();
            try
            {
                topicPosts = TopicPostRepository.GetTopicPostsByTopicId(topicId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return topicPosts;
        }

 
        /// <summary>
        /// Gets all topic posts.
        /// </summary>
        /// <returns></returns>
        public List<TopicPost> GetAllTopicPosts()
        {
            List<TopicPost> topicPosts = new List<TopicPost>();
            try
            {
                topicPosts = TopicPostRepository.GetAllTopicPosts();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return topicPosts;
        }


        /// <summary>
        /// Gets the topic by id.
        /// </summary>
        /// <param name="topicId">The topic id.</param>
        /// <returns></returns>
        public TopicPost GetTopicById(int topicId)
        {
            try
            {
                return TopicPostRepository.GetTopicPostByTopicPostId(topicId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return null;
            
        }

        /// <summary>
        /// Finds all TopicPost registration.
        /// </summary>
        /// <returns>List of all TopicPost registrations.</returns>
        IQueryable<TopicPost> FindAll(List<string> associations)
        {
            return TopicPostRepository.FindAll(associations);
        }
        #endregion

    }
}
