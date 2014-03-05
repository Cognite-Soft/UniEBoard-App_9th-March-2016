// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseModuleAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for all Course and module related operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Service.Interfaces.ApplicationService;
using UniEBoard.Service.Models;
using UniEBoard.Service.Models.Quizzes;

namespace UniEBoard.Service.ApplicationServices
{
    public class DiscussionAppService : BaseAppService, IDiscussionAppService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the discussion manager.
        /// </summary>
        /// <value>The discussion manager.</value>
        public IDiscussionDomainService DiscussionManager { get; set; }

        /// <summary>
        /// Gets or sets the topic manager.
        /// </summary>
        /// <value>The topic manager.</value>
        public ITopicDomainService TopicManager { get; set; }

        /// <summary>
        /// Gets or sets the topic post manager.
        /// </summary>
        /// <value>The topic post manager.</value>
        public ITopicPostDomainService PostManager { get; set; }

        public ICourseDomainService CourseManager { get; set; }


        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscussionAppService"/> class.
        /// </summary>
        /// <param name="objectMapperAdapter">The object mapper adapter.</param>
        /// <param name="cacheAdapter">The cache adapter.</param>
        /// <param name="exceptionManagerAdapter">The exception manager adapter.</param>
        /// <param name="loggingServiceAdapter">The logging service adapter.</param>
        /// <param name="discussionDomainService">The discussion domain service.</param>
        /// <param name="topicDomainService">The topic domain service.</param>
        /// <param name="topicPostDomainService">The topic post domain service.</param>
        public DiscussionAppService(IObjectMapperAdapter objectMapperAdapter, ICacheAdapter cacheAdapter,
            IExceptionManagerAdapter exceptionManagerAdapter, ILoggingServiceAdapter loggingServiceAdapter,
            IDiscussionDomainService discussionDomainService, ITopicDomainService topicDomainService,
            ITopicPostDomainService topicPostDomainService,
            ICourseDomainService courseDomainService)
            : base(objectMapperAdapter, cacheAdapter, exceptionManagerAdapter, loggingServiceAdapter)
        {
            DiscussionManager = discussionDomainService;
            TopicManager = topicDomainService;
            PostManager = topicPostDomainService;
            CourseManager = courseDomainService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the shared discussions with latest posts.
        /// </summary>
        /// <returns></returns>
        public List<DiscussionViewModel> GetSharedDiscussionsWithLatestPosts()
        {
            List<DiscussionViewModel> models = new List<DiscussionViewModel>();
            try
            {
                //Get shared discussions
                List<Discussion> discussionList = DiscussionManager.GetSharedDiscussionsWithLatestPosts();
                
                if(discussionList.Count >0)
                {
                    foreach (Discussion obj in discussionList)
                    {
                        if(obj.LatestPostId !=null)
                        obj.LatestPost = PostManager.GetTopicById((int)obj.LatestPostId);
                    }

                }
                models = ObjectMapper.Map<Model.Entities.Discussion, DiscussionViewModel>(discussionList);
                return models;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets the course discussions with latest posts.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        public List<DiscussionViewModel> GetCourseDiscussionsWithLatestPosts(int courseId)
        {
            List<DiscussionViewModel> models = new List<DiscussionViewModel>();
            try
            {
                //Get shared discussions
                List<Discussion> discussionList = DiscussionManager.GetCourseDiscussionsWithLatestPosts(courseId);
                if (discussionList.Count > 0)
                {
                    foreach (Discussion obj in discussionList)
                    {
                        if (obj.LatestPostId != null)
                            obj.LatestPost = PostManager.GetTopicById((int)obj.LatestPostId);
                    }

                }
                models = ObjectMapper.Map<Model.Entities.Discussion, DiscussionViewModel>(discussionList);
                return models;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets the child discussions with latest posts.
        /// </summary>
        /// <param name="parentDiscussionId">The parent discussion id.</param>
        /// <returns></returns>
        public List<DiscussionViewModel> GetChildDiscussionsWithLatestPosts(int parentDiscussionId)
        {
            List<DiscussionViewModel> models = new List<DiscussionViewModel>();
            try
            {
                //Get shared discussions
                List<Discussion> discussionList = DiscussionManager.GetSubDiscussionsWithLatestPosts(parentDiscussionId);
                if (discussionList.Count > 0)
                {
                    foreach (Discussion obj in discussionList)
                    {
                        if (obj.LatestPostId != null)
                            obj.LatestPost = PostManager.GetTopicById((int)obj.LatestPostId);
                    }

                }
                models = ObjectMapper.Map<Model.Entities.Discussion, DiscussionViewModel>(discussionList);
                return models;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets the list of all topic posts.
        /// </summary>
        /// <returns></returns>
        public List<TopicPostViewModel> GetAllTopicPosts()
        {
            List<TopicPostViewModel> models = new List<TopicPostViewModel>();
            try
            {
                List<TopicPost> topicPostList = PostManager.GetAllTopicPosts();
                models = ObjectMapper.Map<Model.Entities.TopicPost, TopicPostViewModel>(topicPostList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }


        /// <summary>
        /// Gets the list of TopicPosts associated with the Topic
        /// </summary>
        /// <param name="topicId">Id of the topic</param>
        /// <returns></returns>
        public List<TopicPostViewModel> GetTopicPostsByTopic(int topicId)
        {
            List<TopicPostViewModel> models = new List<TopicPostViewModel>();
            try
            {
                List<TopicPost> topicPostList = PostManager.GetTopicPostsByTopicId(topicId);
                models = ObjectMapper.Map<Model.Entities.TopicPost, TopicPostViewModel>(topicPostList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        public int AddTopicPost(TopicPostViewModel topicPost)
        {
            try
            {
                TopicPost _topicPost = ObjectMapper.Map<TopicPostViewModel, TopicPost>(topicPost);

                TopicPost newTopicPost = PostManager.Add(_topicPost);
                return newTopicPost.Id;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
                return 0;
            }
        }

        /// <summary>
        /// Add a new topic post to the database
        /// </summary>
        /// <param name="title">Post title</param>
        /// <param name="body">Post content</param>
        /// <param name="topicId">Topic id</param>
        /// <param name="currentUserId">Id of the user currently logged in</param>
        /// <returns>Id of the new TopicPost</returns>
        public int AddNewTopicPost(string title, string body, int topicId, int currentUserId)
        {
            TopicPostViewModel model = new TopicPostViewModel();
            model.Title = title;
            model.Body = body;
            model.DateCreated = DateTime.Now;
            model.PostedByUserId = currentUserId;
            model.TopicId = topicId;
            int newTopicPost = AddTopicPost(model);

            // Assign the newly created TopicPost to discussion's LatestPostId
            UpdateLatestPostForDiscussion(topicId, newTopicPost);

            return newTopicPost;
        }

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
        public int AddTopicPostReply(int topicPostId, string title, string body, int topicId, int currentUserId)
        {
            TopicPostViewModel parentModel = GetTopicPostById(topicPostId);
            TopicPostViewModel model = new TopicPostViewModel();

            model.Title = parentModel.Title;
            model.Body = body;
            model.DateCreated = DateTime.Now;
            model.PostedByUserId = currentUserId;
            model.TopicId = topicId;
            model.ParentTopicPostId = parentModel.Id;
            int newTopicPost = AddTopicPost(model);

            // Assign the newly created TopicPost to discussion's LatestPostId
            UpdateLatestPostForDiscussion(topicId, newTopicPost);

            return newTopicPost;
        }

        /// <summary>
        /// Create a new topic/thread for a class/module
        /// </summary>
        /// <param name="discussionViewModel">Topic View Model</param>
        /// <returns>TopicViewModel if created successfully otherwise null</returns>
        public TopicViewModel AddTopic(TopicViewModel topicViewModel)
        {
            Topic _topic = new Topic();
            try
            {
                _topic = ObjectMapper.Map<TopicViewModel, Topic>(topicViewModel);
                _topic.PublishFrom = DateTime.Now;
                _topic.PublishTo = DateTime.Now;
                Topic newTopicPost = TopicManager.Add(_topic);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
                return null;
            }
            TopicViewModel _topicViewModel = ObjectMapper.Map<Topic, TopicViewModel>(_topic);
            return _topicViewModel;
        }

        /// <summary>
        /// Gets the topics by topic id.
        /// </summary>
        /// <returns></returns>
        public List<TopicViewModel> GetTopicsByDiscussionId(int topicId)
        {
            List<TopicViewModel> models = new List<TopicViewModel>();
            try
            {
                List<Topic> topicList = TopicManager.GetTopicsByDiscussionId(topicId);
                models = ObjectMapper.Map<Model.Entities.Topic, TopicViewModel>(topicList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        public TopicPostViewModel GetTopicPostById(int topicId)
        {
            TopicPostViewModel model = new TopicPostViewModel();
            try
            {
                TopicPost topicPost = PostManager.GetTopicById(topicId);
                model = ObjectMapper.Map<Model.Entities.TopicPost, TopicPostViewModel>(topicPost);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="discussionViewModel"></param>
        /// <returns></returns>
        public DiscussionViewModel CreateDiscussion(DiscussionViewModel discussionViewModel)
        {
            DiscussionViewModel model = new DiscussionViewModel();
            try
            {
                Discussion discussion = ObjectMapper.Map<DiscussionViewModel, Discussion>(discussionViewModel);
                discussion = DiscussionManager.Add(discussion);
                model = ObjectMapper.Map<Discussion, DiscussionViewModel>(discussion);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return model;
        }

        /// <summary>
        /// Gets the sub discussions by staff.
        /// </summary>
        /// <param name="parentDiscussionId">The staff id.</param>
        /// <returns></returns>
        public List<DiscussionViewModel> GetDiscussionsByStaffId(int staffId)
        {
            List<DiscussionViewModel> models = new List<DiscussionViewModel>();
            try
            {
                List<Course> courses = CourseManager.GetAllCoursesByStudent(staffId, false);
                foreach (Course course in courses)
                {
                    List<DiscussionViewModel> discussionViewModel = GetCourseDiscussionsWithLatestPosts(course.Id);
                    if (discussionViewModel.Count > 0)
                    {
                        models.Add(discussionViewModel[0]);
                    }
                    
                }
                return models;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }


        #endregion



        #region Private Methods

        private void UpdateLatestPostForDiscussion(int topicId, int latestTopicPostId)
        {
            Topic topic = TopicManager.FindBy(topicId);
            Discussion discussion = DiscussionManager.FindBy(topic.DiscussionId);
            discussion.LatestPostId = latestTopicPostId;
            DiscussionManager.Update(discussion);
        }

        #endregion





        
    }
}
