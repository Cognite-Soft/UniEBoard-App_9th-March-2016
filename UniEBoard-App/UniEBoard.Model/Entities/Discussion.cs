// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Discussion.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Discussion class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// Discussion class definition
    /// </summary>
    public class Discussion : BaseEntity
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Discussion"/> class.
        /// </summary>
        public Discussion()
        {
            IsPostModerated = true;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Discussion"/> is post moderated.
        /// </summary>
        /// <value><c>true</c> if post moderated; otherwise, <c>false</c>.</value>
        public bool IsPostModerated { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        public int? SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the course id.
        /// </summary>
        /// <value>The course id.</value>
        public int CourseId { get; set; }

        /// <summary>
        /// Gets or sets the parent discussion id.
        /// </summary>
        /// <value>The parent discussion id.</value>
        public int? ParentDiscussionId { get; set; }

        /// <summary>
        /// Gets or sets the latest post id.
        /// </summary>
        /// <value>The latest post id.</value>
        public int? LatestPostId { get; set; }

        /// <summary>
        /// Gets or sets the course.
        /// </summary>
        /// <value>The course.</value>
        public Course Course { get; set; }

        /// <summary>
        /// Gets or sets the parent discussion.
        /// </summary>
        /// <value>The parent discussion.</value>
        //public Discussion ParentDiscussion { get; set; }

        /// <summary>
        /// Gets or sets the child discussions.
        /// </summary>
        /// <value>The child discussions.</value>
        public ICollection<Discussion> SubDiscussions { get; set; }

        /// <summary>
        /// Gets or sets the topics.
        /// </summary>
        /// <value>The topics.</value>
        public ICollection<Topic> Topics { get; set; }

        /// <summary>
        /// Gets or sets the latest post.
        /// </summary>
        /// <value>The latest post.</value>
        public TopicPost LatestPost { get; set; }

        #endregion
    }
}
