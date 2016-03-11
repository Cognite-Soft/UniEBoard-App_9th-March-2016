// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TopicPost.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  TopicPost class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// TopicPost class definition
    /// </summary>
    public class TopicPost : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the IP.
        /// </summary>
        /// <value>The IP.</value>
        public string IP { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the TopicPost creation date.
        /// </summary>
        public System.DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the votes.
        /// </summary>
        /// <value>The votes.</value>
        public int? Votes { get; set; }

        /// <summary>
        /// Gets or sets the topic id.
        /// </summary>
        /// <value>The topic id.</value>
        public int TopicId { get; set; }

        /// <summary>
        /// Gets or sets the posted by user id.
        /// </summary>
        /// <value>The posted by user id.</value>
        public int PostedByUserId { get; set; }

        /// <summary>
        /// Gets or sets the parent topic post id.
        /// </summary>
        /// <value>The parent topic post id.</value>
        public int? ParentTopicPostId { get; set; }

        /// <summary>
        /// Gets or sets the topic.
        /// </summary>
        /// <value>The topic.</value>
        public Topic Topic { get; set; }

        /// <summary>
        /// Gets or sets the posted by user.
        /// </summary>
        /// <value>The posted by user.</value>
        public User PostedByUser { get; set; }

        /// <summary>
        /// Gets or sets the reply posts.
        /// </summary>
        /// <value>The reply posts.</value>
        public ICollection<TopicPost> ReplyPosts { get; set; }

        /// <summary>
        /// Gets or sets the parent post.
        /// </summary>
        /// <value>The parent post.</value>
        public TopicPost ParentPost { get; set; }

        #endregion
    }
}
