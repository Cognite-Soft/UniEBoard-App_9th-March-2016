// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITopicPostDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for TopicPost Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using UniEBoard.Model.Entities;
using System.Collections.Generic;

namespace UniEBoard.Model.Interfaces.DomainService
{
    /// <summary>
    /// ITopicPostDomainService interface definition - Contains Methods for TopicPost Operations
    /// </summary>
    public interface ITopicPostDomainService : IBaseDomainService<TopicPost>
    {
        /// <summary>
        /// Gets the topic posts by topic id.
        /// </summary>
        /// <param name="topicId">The topic id.</param>
        /// <returns></returns>
        List<TopicPost> GetTopicPostsByTopicId(int topicId);
        /// <summary>
        /// Gets all topic posts.
        /// </summary>
        /// <returns></returns>
        List<TopicPost> GetAllTopicPosts();
        /// <summary>
        /// Gets the topic by id.
        /// </summary>
        /// <param name="topicId">The topic id.</param>
        /// <returns></returns>
        TopicPost GetTopicById(int topicId);
    }
}
