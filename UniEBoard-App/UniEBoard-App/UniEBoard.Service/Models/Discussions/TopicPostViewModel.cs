// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TopicPostViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  TopicPostViewModel class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace UniEBoard.Service.Models
{
    /// <summary>
    /// TopicPostViewModel class definition
    /// </summary>
    public class TopicPostViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the IP.
        /// </summary>
        /// <value>The IP.</value>
        [DataType(DataType.Text)]
        [Display(Name = "IP")]
        public string IP { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [Required]
        [Display(Name = "Status")]
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        [Required]
        [DataType(DataType.Html)]
        [Display(Name = "Body")]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the TopicPost creation date.
        /// </summary>
        public System.DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the votes.
        /// </summary>
        /// <value>The votes.</value>
        [Display(Name = "Votes")]
        public int? Votes { get; set; }

        /// <summary>
        /// Gets or sets the topic id.
        /// </summary>
        /// <value>The topic id.</value>
        [Display(Name = "Topic Id")]
        public int TopicId { get; set; }

        /// <summary>
        /// Gets or sets the posted by user id.
        /// </summary>
        /// <value>The posted by user id.</value>
        [Display(Name = "Posted By UserId")]
        public int PostedByUserId { get; set; }

        /// <summary>
        /// Gets or sets the parent topic post id.
        /// </summary>
        /// <value>The parent topic post id.</value>
        [Display(Name = "Parent TopicPost ")]
        public int? ParentTopicPostId { get; set; }

        /// <summary>
        /// Gets or sets the posted by user.
        /// </summary>
        /// <value>The posted by user.</value>
        public UserViewModel PostedByUser { get; set; }

        /// <summary>
        /// Gets or sets the reply posts.
        /// </summary>
        /// <value>The reply posts.</value>
        public ICollection<TopicPostViewModel> ReplyPosts { get; set; }

        /// <summary>
        /// Gets or sets the parent post.
        /// </summary>
        /// <value>The parent post.</value>
        public TopicPostViewModel ParentPost { get; set; }
    }
}