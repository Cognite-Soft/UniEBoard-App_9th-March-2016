// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TopicPostRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for TopicPost Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using UniEBoard.Model.Interfaces.Repository;
using UniEBoard.Model.Interfaces.Adapter;
using System.Collections.Generic;
using System;
using UniEBoard.Model.Enums;
using System.Linq;

namespace UniEBoard.Repository.Repositories
{
    /// <summary>
    /// The TopicPost Repository Class
    /// </summary>
    public class TopicPostRepository : BaseRepository<UniEBoardDbContext, Repository.TopicPost, Model.Entities.TopicPost>, ITopicPostRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TopicPostRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        public TopicPostRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods
        /// <summary>
        /// Gets the topic posts by topic id.
        /// </summary>
        /// <param name="topicId">The topic id.</param>
        /// <returns></returns>
        public List<Model.Entities.TopicPost> GetTopicPostsByTopicId(int topicId)
        {
            List<Model.Entities.TopicPost> topicPostList = new List<Model.Entities.TopicPost>();
            try
            {
                IQueryable<TopicPost> topicPosts = from tp in this.Context.Set<TopicPost>().Where(t => t.TopicId == topicId)
                                                   select tp;
                IQueryable<User> user = topicPosts.Select(u => u.PostedByUser);
                List<TopicPost> topicPostEntityList = topicPosts.ToList();
                user.ToList();

                topicPostList = ObjectMapper.Map<TopicPost, Model.Entities.TopicPost>(topicPostEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return topicPostList;
        }

        /// <summary>
        /// Gets all topic posts.
        /// </summary>
        /// <returns></returns>
        public List<Model.Entities.TopicPost> GetAllTopicPosts()
        {
            List<Model.Entities.TopicPost> topicPostList = new List<Model.Entities.TopicPost>();
            try
            {
                IQueryable<TopicPost> topicPosts = from tp in this.Context.Set<TopicPost>()
                                                   select tp;
                IQueryable<TopicPost> replyPosts = topicPosts.SelectMany(tp => tp.ReplyPosts);
                List<TopicPost> topicPostEntityList = topicPosts.ToList();
                replyPosts.ToList();

                topicPostList = ObjectMapper.Map<TopicPost, Model.Entities.TopicPost>(topicPostEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return topicPostList;
        }

        /// <summary>
        /// Gets the topic post by topic post id.
        /// </summary>
        /// <param name="topicId">The topic id.</param>
        /// <returns></returns>
        public Model.Entities.TopicPost GetTopicPostByTopicPostId(int topicId)
        {

            try
            {
                TopicPost obj = this.Context.Set<TopicPost>().Where(p => p.Id == topicId).FirstOrDefault();


                return ObjectMapper.Map<TopicPost, Model.Entities.TopicPost>(obj);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }

            return null;
        }

  
        #endregion

      
    }
}
