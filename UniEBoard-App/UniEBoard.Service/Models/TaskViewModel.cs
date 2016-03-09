// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  TaskViewModel class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using UniEBoard.Service.Helpers;
using System.Web.Mvc;

namespace UniEBoard.Service.Models
{
    /// <summary>
    /// TaskViewModel class definition
    /// </summary>
    public class TaskViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required")]
        [AllowHtml]
        public string Title { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Notes")]
        [Required(ErrorMessage = "Notes are required")]
        [AllowHtml]
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the deadline.
        /// </summary>
        /// <value>The deadline.</value>
        [Display(Name = "Deadline")]
        //[DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Required(ErrorMessage = "Deadline is required")]
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Gets or sets the days left.
        /// </summary>
        /// <value>The days left.</value>
        [Display(Name = "Due")]
        public int DaysDue { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        /// <value>The priority.</value>
        public int Priority { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is completed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is completed; otherwise, <c>false</c>.
        /// </value>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>The user id.</value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the days left.
        /// </summary>
        /// <value>The days left.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Due:")]
        public string DaysLeft { get; set; }

        /// <summary>
        /// Gets or sets the priority label CSS class.
        /// </summary>
        /// <value>The priority label  CSS class.</value>
        [DataType(DataType.Text)]
        [Display(Name = "CssClass:")]
        public string PriorityLabelCssClass
        {
            get
            {
                return CssHelper.GetCssClassForLowPriorityLabels(Priority);
            }
        }

        /// <summary>
        /// Gets or sets the completed CSS class.
        /// </summary>
        /// <value>The completed CSS class.</value>
        [DataType(DataType.Text)]
        [Display(Name = "CssClass:")]
        public string CompletedCssClass
        {
            get
            {
                return CssHelper.GetCssClassForCompletedTasks(IsCompleted);
            }
        }

        #endregion
    }
}
