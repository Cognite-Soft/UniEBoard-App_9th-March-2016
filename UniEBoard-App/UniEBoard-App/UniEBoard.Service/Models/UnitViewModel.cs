// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  UnitViewModel class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using UniEBoard.Service.Models.Quizzes;
using System.Web.Mvc;

namespace UniEBoard.Service.Models
{
    /// <summary>
    //  UnitViewModel class definition
    /// </summary>
    public class UnitViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Title
        /// </summary>
        /// <value>Title</value>
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        [AllowHtml]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the scheduled day.
        /// </summary>
        /// <value>The scheduled day.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Day")]
        public string ScheduledDay { get; set; }

        /// <summary>
        /// Gets or sets the scheduled time.
        /// </summary>
        /// <value>The scheduled time.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Time")]
        public string ScheduledTime { get; set; }

        /// <summary>
        /// Gets or sets the scheduled date.
        /// </summary>
        /// <value>The scheduled date.</value>
        [Display(Name = "Start Date")]
        public DateTime ScheduledDate { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        /// <value>Description</value>
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        [AllowHtml]
        public string Description { get; set; }


        /// <summary>
        /// Gets or sets the publish from.
        /// </summary>
        /// <value>The publish from.</value>
        [Display(Name = "Publish From")]
        [DataType(DataType.DateTime), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm")]
        [Required]
        public DateTime? PublishFrom { get; set; }

        /// <summary>
        /// Gets or sets the publish to.
        /// </summary>
        /// <value>The publish to.</value>
        [Display(Name = "Publish To")]
        [DataType(DataType.DateTime), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy  HH:mm}")]
        public DateTime? PublishTo { get; set; }

        /// <summary>
        /// StaffId
        /// </summary>
        /// <value>StaffId</value>
        [Required]
        [Display(Name = "StaffId")]
        public int StaffId { get; set; }

        /// <summary>
        /// Gets or sets the Sort Order.
        /// </summary>
        /// <value>The Sort Order.</value>
        public int SortOrder { get; set; }

        /// <summary>
        /// ModuleId
        /// </summary>
        /// <value>ModuleId</value>
        //[Required]
        [Display(Name = "ModuleId")]
        public int? ModuleId { get; set; }

        /// <summary>
        /// ModuleTitle
        /// </summary>
        /// <value>ModuleTitle</value>
        //[Required]
        [Display(Name = "ModuleTitle")]
        [AllowHtml]
        public string ModuleTitle { get; set; }

        /// <summary>
        /// VideoId
        /// </summary>
        /// <value>VideoId</value>
        //[Required]
        [Display(Name = "VideoId")]
        public int? VideoId { get; set; }

        /// <summary>
        /// DocumentId
        /// </summary>
        /// <value>DocumentId</value>
        //[Required]
        [Display(Name = "DocumentId")]
        public int? DocumentId { get; set; }

        /// <summary>
        /// AssignmentId
        /// </summary>
        /// <value>AssignmentId</value>
        //[Required]
        [Display(Name = "AssignmentId")]
        public int AssignmentId { get; set; }


        /// <summary>
        /// Video Path
        /// </summary>
        /// <value>Path of the video</value>
        //[Required]
        [Display(Name = "Path")]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the module.
        /// </summary>
        /// <value>The module.</value>
        public ModuleViewModel Module { get; set; }

        /// <summary>
        /// Gets or sets the video.
        /// </summary>
        /// <value>
        /// The video.
        /// </value>
        public VideoViewModel Video { get; set; }

        /// <summary>
        /// Gets or sets the Document.
        /// </summary>
        /// <value>
        /// The Document.
        /// </value>
        public DocumentViewModel Document { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public QuizzesViewModel Quiz { get; set; }

        /// <summary>
        /// Gets or sets the QuizId.
        /// </summary>
        /// <value>
        /// The QuizId.
        /// </value>
        public int? QuizId { get; set; }

        /// <summary>
        /// Gets or sets the duration of the Class/Unit
        /// </summary>
        [Required]
        [Display(Name = "Duration1")]
        public Nullable<double> Duration { get; set; }

        /// <summary>
        /// Gets or sets the duration of the Class/Unit
        /// </summary>
        public string DurationFormatted { get; set; }

        /// <summary>
        /// Gets or sets the duration of the Class/Unit
        /// </summary>
        public Nullable<int> DurationSelectedOption { get; set; }
              
        public List<AssetViewModel> Assets { get; set; }

        #endregion
    }
}
