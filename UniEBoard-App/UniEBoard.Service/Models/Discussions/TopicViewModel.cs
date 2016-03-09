// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TopicViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  TopicViewModel class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UniEBoard.Service.Models
{
    /// <summary>
    /// TopicViewModel class definition
    /// </summary>
    public class TopicViewModel : BaseQuestionTopicViewModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is pinned.
        /// </summary>
        /// <value><c>true</c> if this instance is pinned; otherwise, <c>false</c>.</value>
        [Display(Name = "IsPinned")]
        public bool IsPinned { get; set; }

        /// <summary>
        /// Gets or sets the discussion id.
        /// </summary>
        /// <value>The discussion id.</value>
        [Display(Name = "Discussion Id ")]
        public int DiscussionId { get; set; }

        /// <summary>
        /// Gets or sets the discussion.
        /// </summary>
        /// <value>The discussion.</value>
        public DiscussionViewModel Discussion { get; set; }

        /// <summary>
        /// Gets or sets the topic posts.
        /// </summary>
        /// <value>The topic posts.</value>
        public ICollection<TopicPostViewModel> TopicPosts { get; set; }
    }
}