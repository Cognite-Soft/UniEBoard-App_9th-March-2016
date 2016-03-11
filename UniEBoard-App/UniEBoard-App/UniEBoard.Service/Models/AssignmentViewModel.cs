// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssignmentViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  AssignmentViewModel class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using UniEBoard.Service.Helpers;
using System.Web;
using System.Web.Mvc;

namespace UniEBoard.Service.Models
{
    /// <summary>
    //  AssignmentViewModel class definition
    /// </summary>
    public class AssignmentViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        [Required(ErrorMessage = "{0} is required.")]
        [AllowHtml]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the instructions.
        /// </summary>
        /// <value>The instructions.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Instructions")]
        [Required(ErrorMessage = "{0} are required.")]
        [AllowHtml]
        public string Instructions { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>The date created.</value>
        [Display(Name = "Date Created")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        //[Required(ErrorMessage = "{0} is required.")]
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Gets or sets the publish from.
        /// </summary>
        /// <value>The publish from.</value>
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime PublishFrom { get; set; }

        /// <summary>
        /// Gets or sets the publish to.
        /// </summary>
        /// <value>The publish to.</value>
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime PublishTo { get; set; }

        /// <summary>
        /// Gets or sets the quiz id.
        /// </summary>
        /// <value>The quiz id.</value>
        [Display(Name = "related Quiz")]
        public int? QuizId { get; set; }

        /// <summary>
        /// Gets or sets the points possible.
        /// </summary>
        /// <value>The points possible.</value>
        [Display(Name = "Points Possible")]
        [Range(1, 100)]
        [Required(ErrorMessage = "{0} is required.")]
        public int? PointsPossible { get; set; }

        /// <summary>
        /// Gets or sets the course id.
        /// </summary>
        /// <value>The course id.</value>
        [Display(Name = "Course")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? CourseId { get; set; }

        /// <summary>
        /// Gets or sets the module id.
        /// </summary>
        /// <value>The module id.</value>
        [Display(Name = "Module")]
        [Required(ErrorMessage = "{0} is required.")]
        public int? ModuleId { get; set; }

        /// <summary>
        /// Gets or sets the unit id.
        /// </summary>
        /// <value>The unit id.</value>
        [Display(Name = "Unit")]
        public int? UnitId { get; set; }

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
        public string CssClass
        {
            get
            {
                return CssHelper.GetCssClassForLowPriorityLabels(Priority);
            }
        }

        /// <summary>
        /// Gets or sets the student id.
        /// </summary>
        /// <value>The student id.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Student")]
        [Required(ErrorMessage = "{0} is required.")]
        public int StudentId { get; set; }

        /// <summary>
        /// Gets or sets the file to upload.
        /// </summary>
        /// <value>The file to upload.</value>
        [Display(Name = "File Upload")]
        public HttpPostedFileBase UploadFile { get; set; }

        public virtual ICollection<AssetViewModel> Assets { get; set; }

        /// <summary>
        /// Gets or sets the submissions.
        /// </summary>
        /// <value>The submissions.</value>
        public ICollection<SubmissionViewModel> Submissions { get; set; }
        
        /// <summary>
        /// Gets or sets the submissions.
        /// </summary>
        /// <value>The submissions.</value>
        public ModuleViewModel Module { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CourseViewModel Course { get; set; }

        public int AverageGrade
        {
            get
            {
                if (this.Submissions == null || this.Submissions.Count() == 0)
                {
                    return 0;
                }
                else
                {
                    int total = 0;
                    foreach (var sub in this.Submissions)
                    {
                        total += sub.GradePointValue ?? 0;
                    }
                    return total / this.Submissions.Count();
                }
            }
        }


        #endregion
    }
}
