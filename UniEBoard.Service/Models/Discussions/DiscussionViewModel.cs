// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiscussionViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  DiscussionViewModel class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniEBoard.Service.Helpers;

namespace UniEBoard.Service.Models
{
    /// <summary>
    /// DiscussionViewModel class definition
    /// </summary>
    public class DiscussionViewModel : BaseViewModel
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
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DiscussionViewModel"/> is post moderated.
        /// </summary>
        /// <value><c>true</c> if post moderated; otherwise, <c>false</c>.</value>
        [Display(Name = "IsPostModerated")]
        public bool IsPostModerated { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        [Display(Name = "SortOrder")]
        public int? SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the course id.
        /// </summary>
        /// <value>The course id.</value>
        [Display(Name = "Course Id")]
        public int CourseId { get; set; }

        /// <summary>
        /// Gets or sets the parent discussion id.
        /// </summary>
        /// <value>The parent discussion id.</value>
        [Display(Name = "ParentDiscussionId")]
        public int ParentDiscussionId { get; set; }

        /// <summary>
        /// Gets or sets the latest post id.
        /// </summary>
        /// <value>The latest post id.</value>
        [Display(Name = "Latest Post Id")]
        public int? LatestPostId { get; set; }

        /// <summary>
        /// Gets or sets the course.
        /// </summary>
        /// <value>The course.</value>
        [Display(Name = "Course")]
        public CourseViewModel Course { get; set; }

        /// <summary>
        /// Gets or sets the topics.
        /// </summary>
        /// <value>The topics.</value>
        [Display(Name = "Topics")]
        public ICollection<TopicViewModel> Topics { get; set; }

        /// <summary>
        /// Gets or sets the latest post.
        /// </summary>
        /// <value>The latest post.</value>
        [Display(Name = "Latest Post")]
        public TopicPostViewModel LatestPost { get; set; }


        /// <summary>
        /// Gets the latest post calculated id.
        /// </summary>
        public int? LatestPostCalculatedTopicId
        {
            get
            {
                if (LatestPost == null)
                {
                    return null;
                }
                else
                {
                    return (int)LatestPost.TopicId;
                }
            }
        }

        /// <summary>
        /// Gets the latest post body.
        /// </summary>
        public string LatestPostBody
        {
            get
            {
                if (LatestPost == null)
                {
                    return string.Empty;
                }
                else
                {
                    return LatestPost.Body;
                }
            }
        }

        /// <summary>
        /// Gets the latest post CSS.
        /// </summary>
        public string LatestPostCSS
        {
            get
            {
                if (LatestPost == null)
                {
                    return CssHelper.GetCssClassForPostNotExsits();
                }
                else
                {
                    return LatestPost.Body;
                }
            }
        }
    }
}