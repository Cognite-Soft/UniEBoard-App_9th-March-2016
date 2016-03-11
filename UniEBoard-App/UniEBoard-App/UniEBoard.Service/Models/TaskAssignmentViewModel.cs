// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskAssignmentViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  TaskAssignmentViewModel class definition
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
    /// TaskAssignmentViewModel class definition
    /// </summary>
    public class TaskAssignmentViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Title:")]
        [Required(ErrorMessage = "{0} is required.")]
        [AllowHtml]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the deadline.
        /// </summary>
        /// <value>The deadline.</value>
        [Display(Name = "Deadline:")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? Deadline { get; set; }

        /// <summary>
        /// Gets or sets the days left.
        /// </summary>
        /// <value>The days left.</value>
        [Display(Name = "Number of Days Due:")]
        public int DaysDue { get; set; }

        /// <summary>
        /// Gets or sets the days left.
        /// </summary>
        /// <value>The days left.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Due:")]
        public string DaysLeft { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is task.
        /// </summary>
        /// <value><c>true</c> if this instance is task; otherwise, <c>false</c>.</value>
        [Display(Name = "Is Task")]
        public bool IsTask { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        /// <value>The priority.</value>
        public int Priority { get; set; }

        /// <summary>
        /// Gets or sets the CSS class.
        /// </summary>
        /// <value>The CSS class.</value>
        [DataType(DataType.Text)]
        [Display(Name = "CssClass:")]
        public string CssClass
        {
            get
            {
                return CssHelper.GetCssClassForLowPriorityLabels(Priority);
            }
        }

        #endregion
    }
}
