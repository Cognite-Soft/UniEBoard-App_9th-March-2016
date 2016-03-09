// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssignmentSubmissionViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  AssignmentSubmissionViewModel class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UniEBoard.Service.Helpers;

namespace UniEBoard.Service.Models
{
    /// <summary>
    //  AssignmentSubmissionViewModel class definition
    /// </summary>
    public class AssignmentSubmissionViewModel : SubmissionViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the instructions.
        /// </summary>
        /// <value>The instructions.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Instructions")]
        [AllowHtml]
        public string Instructions { get; set; }

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
        /// Gets or sets the points possible.
        /// </summary>
        /// <value>The points possible.</value>
        public int? PointsPossible { get; set; }

        /// <summary>
        /// Gets or sets the days left.
        /// </summary>
        /// <value>The days left.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Due:")]
        public string DaysLeft { get; set; }

        /// <summary>
        /// Gets or sets the CSS class.
        /// </summary>
        /// <value>The CSS class.</value>
        [DataType(DataType.Text)]
        [Display(Name = "CssClass:")]
        public string AssignmentCssClass
        {
            get
            {
                return CssHelper.GetCssClassForLowPriorityLabels(Priority);
            }
        }

        /// <summary>
        /// Gets or sets the assignment uploads.
        /// </summary>
        /// <value>The assignment uploads.</value>
        public ICollection<BaseFileViewModel> AssignmentUploads { get; set; }

        /// <summary>
        /// Gets or sets the file to upload.
        /// </summary>
        /// <value>The file to upload.</value>
        [Display(Name = "Upload Document")]
        public HttpPostedFileBase UploadFile { get; set; }

        #endregion
    }
}
