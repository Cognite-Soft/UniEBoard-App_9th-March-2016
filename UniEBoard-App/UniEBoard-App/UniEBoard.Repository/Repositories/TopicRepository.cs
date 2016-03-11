// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TopicRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for Topic Repository CRUD operations.
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
    /// The Topic Repository Class
    /// </summary>
    public class TopicRepository : BaseRepository<UniEBoardDbContext, Repository.Topic, Model.Entities.Topic>, ITopicRepository
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TopicRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        public TopicRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods
        /// <summary>
        /// Gets the topics by topic id.
        /// </summary>
        /// <param name="topicId">The topic id.</param>
        /// <returns></returns>
        public List<Model.Entities.Topic> GetTopicsByDiscussionId(int  topicId)
        {
            List<Topic> topicList=this.Context.Set<Topic>().Where(p => p.DiscussionId == topicId).ToList<Topic>();

            return ObjectMapper.Map<Topic, Model.Entities.Topic>(topicList);
        }
        #endregion

       
    }
}
