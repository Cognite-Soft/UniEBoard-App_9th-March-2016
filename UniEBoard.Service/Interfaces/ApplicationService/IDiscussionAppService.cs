// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDiscussionAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for Discussion Application Service Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Service.Models;

namespace UniEBoard.Service.Interfaces.ApplicationService
{
    /// <summary>
    /// IDiscussionAppService Interface - Contains Methods for Discussion Application Service Operations
    /// </summary>
    public interface IDiscussionAppService : IBaseAppService
    {
        /// <summary>
        /// Gets or sets the discussion manager.
        /// </summary>
        /// <value>The discussion manager.</value>
        IDiscussionDomainService DiscussionManager { get; set; }

        /// <summary>
        /// Gets or sets the topic manager.
        /// </summary>
        /// <value>The topic manager.</value>
        ITopicDomainService TopicManager { get; set; }

        /// <summary>
        /// Gets or sets the post manager.
        /// </summary>
        /// <value>The post manager.</value>
        ITopicPostDomainService PostManager { get; set; }

        /// <summary>
        /// Gets the shared discussions with latest posts.
        /// </summary>
        /// <returns></returns>
        List<DiscussionViewModel> GetSharedDiscussionsWithLatestPosts();

        /// <summary>
        /// Gets the course discussions with latest posts.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        List<DiscussionViewModel> GetCourseDiscussionsWithLatestPosts(int courseId);

        /// <summary>
        /// Gets the child discussions with latest posts.
        /// </summary>
        /// <param name="parentDiscussionId">The parent discussion id.</param>
        /// <returns></returns>
        List<DiscussionViewModel> GetChildDiscussionsWithLatestPosts(int parentDiscussionId);

        /// <summary>
        /// Gets the sub discussions by staff.
        /// </summary>
        /// <param name="parentDiscussionId">The staff id.</param>
        /// <returns></returns>
        List<DiscussionViewModel> GetDiscussionsByStaffId(int staffId);

        /// <summary>
        /// Gets the list of all topic posts.
        /// </summary>
        /// <returns></returns>
        List<TopicPostViewModel> GetAllTopicPosts();

        /// <summary>
        /// Gets the list of TopicPosts associated with the Topic
        /// </summary>
        /// <param name="topicId">Id of the topic</param>
        /// <returns></returns>
        List<TopicPostViewModel> GetTopicPostsByTopic(int topicId);

        /// <summary>
        /// Add a TopicPost to the database
        /// </summary>
        /// <param name="topicPost">TopicPost</param>
        /// <returns>id of the new TopicPost</returns>
        int AddTopicPost(TopicPostViewModel topicPost);

        /// <summary>
        /// Add a new topic post to the database
        /// </summary>
        /// <param name="title">Post title</param>
        /// <param name="body">Post content</param>
        /// <param name="topicId">Topic id</param>
        /// <param name="currentUserId">Id of the user currently logged in</param>
        /// <returns>Id of the new TopicPost</returns>
        int AddNewTopicPost(string title, string body, int topicId, int currentUserId);

        /// <summary>
        /// Add a new topic post to the database
        /// </summary>
        /// <param name="topicPostId">Id of the TopicPost being replied</param>
        /// <param name="title">Post title</param>
        /// <param name="body">Post content</param>
        /// <param name="topicId">Topic id</param>
        /// <returns>the id of the new TopicPost</returns>
        /// <param name="currentUserId">Id of the user currently logged in</param>
        /// <returns>Id of the TopicPost reply</returns>
        int AddTopicPostReply(int topicPostId, string title, string body, int topicId, int currentUserId);

        /// <summary>
        /// Create a new discussion for a course
        /// </summary>
        /// <param name="discussionViewModel">Discussion View Model</param>
        /// <returns>true if created successfully otherwise false</returns>
        DiscussionViewModel CreateDiscussion(DiscussionViewModel discussionViewModel);

        /// <summary>
        /// Create a new topic/thread for a class/module
        /// </summary>
        /// <param name="discussionViewModel">Topic View Model</param>
        /// <returns>TopicViewModel if created successfully otherwise null</returns>
        TopicViewModel AddTopic(TopicViewModel topicViewModel);


        /// <summary>
        /// Gets the topic by id
        /// </summary>
        /// <param name="topicId">The topic id</param>
        /// <returns>an instance of TopicPost</returns>
        TopicPostViewModel GetTopicPostById(int topicId);


        /// <summary>
        /// Gets the topics by discussion id.
        /// </summary>
        /// <param name="topicId">The topic id.</param>
        /// <returns></returns>
        List<TopicViewModel> GetTopicsByDiscussionId(int topicId);
    }
}
