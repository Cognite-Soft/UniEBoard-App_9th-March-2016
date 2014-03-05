// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseQuestionTopicViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  BaseQuestionTopic class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Entities;
using UniEBoard.Service.Helpers;

namespace UniEBoard.Service.Models
{
    /// <summary>
    //  BaseQuestionTopicViewModel class definition
    /// </summary>
    public class BaseQuestionTopicViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public QuestionTopicStatusType Status { get; set; }

        /// <summary>
        /// Gets or sets the completed CSS class.
        /// </summary>
        /// <value>The completed CSS class.</value>
        [DataType(DataType.Text)]
        [Display(Name = "CssClass:")]
        public string StatusCssClass
        {
            get
            {
                return CssHelper.GetCssClassForQuestionStatus(Status);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is topic.
        /// </summary>
        /// <value><c>true</c> if this instance is topic; otherwise, <c>false</c>.</value>
        public bool IsTopic { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the originator id.
        /// </summary>
        /// <value>The originator id.</value>
        public int OriginatorId { get; set; }


        #endregion

        #region Topic
        
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

        #region QuestionUser

        /// <summary>
        /// Gets or sets the recipient id.
        /// </summary>
        /// <value>The recipient id.</value>
        public int RecipientId { get; set; }

        #endregion


    }


}
