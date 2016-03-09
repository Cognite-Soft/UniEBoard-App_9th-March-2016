// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Topic.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Topic class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// Topic class definition
    /// </summary>
    public class Topic : BaseQuestionTopic
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Topic"/> class.
        /// </summary>
        public Topic()
        {
            IsPinned = false;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether this instance is pinned.
        /// </summary>
        /// <value><c>true</c> if this instance is pinned; otherwise, <c>false</c>.</value>
        public bool IsPinned { get; set; }

        /// <summary>
        /// Gets or sets the discussion id.
        /// </summary>
        /// <value>The discussion id.</value>
        public int DiscussionId { get; set; }

        /// <summary>
        /// Gets or sets the discussion.
        /// </summary>
        /// <value>The discussion.</value>
        public Discussion Discussion { get; set; }

        /// <summary>
        /// Gets or sets the topic posts.
        /// </summary>
        /// <value>The topic posts.</value>
        public ICollection<TopicPost> TopicPosts { get; set; }

        #endregion
    }
}
