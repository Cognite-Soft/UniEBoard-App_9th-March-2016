// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScheduleViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  ScheduleViewModel class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using UniEBoard.Service.Helpers;

namespace UniEBoard.Service.Models
{
    /// <summary>
    /// ScheduleViewModel class definition
    /// </summary>
    public class ScheduleViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the course id.
        /// </summary>
        /// <value>The course id.</value>
        [Required]
        [Display(Name = "Course Id")]
        public int CourseId { get; set; }

        /// <summary>
        /// Gets or sets the unit id.
        /// </summary>
        /// <value>The unit id.</value>
        [Required]
        [Display(Name = "Unit Id")]
        public int UnitId { get; set; }

        /// <summary>
        /// Gets or sets the course.
        /// </summary>
        /// <value>The course.</value>
        public CourseViewModel Course { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>The unit.</value>
        public UnitViewModel Unit { get; set; }

        /// <summary>
        /// Gets or sets the scheduled from day.
        /// </summary>
        /// <value>The scheduled from day.</value>
        [DataType(DataType.Text)]
        [Display(Name = "From Day")]
        public string ScheduledFromDay { get; set; }

        /// <summary>
        /// Gets or sets the scheduled from time.
        /// </summary>
        /// <value>The scheduled from time.</value>
        [DataType(DataType.Text)]
        [Display(Name = "From Time")]
        public string ScheduledFromTime { get; set; }


        /// <summary>
        /// Gets or sets the scheduled to day.
        /// </summary>
        /// <value>The scheduled to day.</value>
        [DataType(DataType.Text)]
        [Display(Name = "To Day")]
        public string ScheduledToDay { get; set; }

        /// <summary>
        /// Gets or sets the scheduled to time.
        /// </summary>
        /// <value>The scheduled to time.</value>
        [DataType(DataType.Text)]
        [Display(Name = "To Time")]
        public string ScheduledToTime { get; set; }

        /// <summary>
        /// Gets or sets the scheduled from.
        /// </summary>
        /// <value>The scheduled from.</value>
        [Display(Name = "ScheduledFrom")]
        public DateTime ScheduledFrom { get; set; }

        /// <summary>
        /// Gets or sets the scheduled to.
        /// </summary>
        /// <value>The scheduled to.</value>
        [Display(Name = "ScheduledTo")]
        public DateTime ScheduledTo { get; set; }

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

        #endregion
    }
}
