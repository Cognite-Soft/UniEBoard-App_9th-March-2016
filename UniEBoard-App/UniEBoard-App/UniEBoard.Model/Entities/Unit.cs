// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Unit.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Unit class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// Unit class definition
    /// </summary>
    public class Unit : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the scheduled date.
        /// </summary>
        /// <value>The scheduled date.</value>
        public DateTime? ScheduledDate { get; set; }

        /// <summary>
        /// Gets the day.
        /// </summary>
        /// <value>The day.</value>
        public string ScheduledDay
        {
            get
            {
                return ScheduledDate.HasValue ? ScheduledDate.Value.DayOfWeek.ToString() : string.Empty;
            }
        }

        /// <summary>
        /// Gets the day.
        /// </summary>
        /// <value>The day.</value>
        public string ScheduledTime
        {
            get
            {
                return ScheduledDate.HasValue ? ScheduledDate.Value.ToString("HH:mm") : string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the staff id.
        /// </summary>
        /// <value>The staff id.</value>
        public int StaffId { get; set; }

        /// <summary>
        /// Gets or sets the Sort Order.
        /// </summary>
        /// <value>The Sort Order.</value>
        public int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the video.
        /// </summary>
        /// <value>
        /// The video.
        /// </value>
        public Video Video { get; set; }

        /// <summary>
        /// Gets or sets the video id.
        /// </summary>
        /// <value>The video id.</value>
        public int? VideoId { get; set; }

        /// <summary>
        /// Gets or sets the document id.
        /// </summary>
        /// <value>The document id.</value>
        public int? DocumentId { get; set; }

        /// <summary>
        /// Gets or sets the assignment id.
        /// </summary>
        /// <value>The assignment id.</value>
        public int? AssignmentId { get; set; }

        /// <summary>
        /// Gets or sets the quiz id.
        /// </summary>
        /// <value>The quiz id.</value>
        public int? QuizId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [module id].
        /// </summary>
        /// <value><c>true</c> if [module id]; otherwise, <c>false</c>.</value>
        public int? ModuleId { get; set; }

        /// <summary>
        /// Gets or sets the module.
        /// </summary>
        /// <value>The module.</value>
        public Module Module { get; set; }

        /// <summary>
        /// Gets or sets the created by staff.
        /// </summary>
        /// <value>The created by staff.</value>
        public Staff CreatedByStaff { get; set; }

        /// <summary>
        /// Gets or sets the document.
        /// </summary>
        /// <value>The document.</value>
        public Document Document { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Quiz Quiz { get; set; }

        /// <summary>
        /// Gets the module title.
        /// </summary>
        public string ModuleTitle
        {
            get
            {
                return Module != null ? Module.Title : string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the assignment.
        /// </summary>
        /// <value>
        /// The assignment.
        /// </value>
        public List<Assignment> Assignments { get; set; }

        /// <summary>
        /// Gets or sets the assets.
        /// </summary>
        /// <value>
        /// The assets.
        /// </value>
        public List<Asset> Assets { get; set; }

        /// <summary>
        /// Gets or sets the schedules.
        /// </summary>
        /// <value>
        /// The schedules.
        /// </value>
        public List<Schedule> Schedules { get; set; }

        /// <summary>
        /// Gets or sets the duration of the Class/Unit
        /// </summary>
        public Nullable<double> Duration { get; set; }

        #endregion
    }
}
