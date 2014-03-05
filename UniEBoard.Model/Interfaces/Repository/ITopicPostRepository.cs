// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITopicPostRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for TopicPost Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using UniEBoard.Model.Entities;
using System.Collections.Generic;

namespace UniEBoard.Model.Interfaces.Repository
{
    /// <summary>
    /// The TopicPost Repository Interface
    /// </summary>
    public interface ITopicPostRepository : IBaseRepository<TopicPost>
    {
        /// <summary>
        /// Gets the topic posts by topic id.
        /// </summary>
        /// <param name="topicId">The topic id.</param>
        /// <returns></returns>
        List<Model.Entities.TopicPost> GetTopicPostsByTopicId(int topicId);
        /// <summary>
        /// Gets all topic posts.
        /// </summary>
        /// <returns></returns>
        List<Model.Entities.TopicPost> GetAllTopicPosts();
        /// <summary>
        /// Gets the topic post by topic post id.
        /// </summary>
        /// <param name="topicId">The topic id.</param>
        /// <returns></returns>
        TopicPost GetTopicPostByTopicPostId(int topicId);
    }
}
