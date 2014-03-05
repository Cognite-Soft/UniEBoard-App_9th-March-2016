// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubmissionViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  SubmissionViewModel class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace UniEBoard.Service.Models
{
    /// <summary>
    //  SubmissionViewModel class definition
    /// </summary>
    public class SubmissionViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [DataType(DataType.Text)]
        [Display(Name = "title")]
        [Required(ErrorMessage = "{0} is required.")]
        [AllowHtml]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Body")]
        [AllowHtml]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [Display(Name = "Status")]
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the student id.
        /// </summary>
        /// <value>The student id.</value>
        [Display(Name = "Student")]
        public int StudentId { get; set; }

        /// <summary>
        /// Gets or sets the assignment id.
        /// </summary>
        /// <value>The assignment id.</value>
        [Display(Name = "Assignment")]
        public int AssignmentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Grade")]
        public int? GradePointValue { get; set; }

        /// <summary>
        /// Gets or sets the file uploads.
        /// </summary>
        /// <value>The file uploads.</value>
        public ICollection<BaseFileViewModel> FileUploads { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AssignmentViewModel Assignment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public StudentViewModel Student { get; set; }

        #endregion
    }
}
