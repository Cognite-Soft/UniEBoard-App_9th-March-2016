// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Schedule.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Schedule class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// Schedule class definition
    /// </summary>
    public class Schedule : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the course id.
        /// </summary>
        /// <value>The course id.</value>
        public int CourseId { get; set; }

        /// <summary>
        /// Gets or sets the course id.
        /// </summary>
        /// <value>The course id.</value>
        public int UnitId { get; set; }

        /// <summary>
        /// Gets or sets the course.
        /// </summary>
        /// <value>The course.</value>
        public Course Course { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>The unit.</value>
        public Unit Unit { get; set; }

        /// <summary>
        /// Gets the scheduled from day.
        /// </summary>
        /// <value>The scheduled from day.</value>
        public string ScheduledFromDay
        {
            get
            {
                return ScheduledFrom.HasValue ? ScheduledFrom.Value.DayOfWeek.ToString() : string.Empty;
            }
        }

        /// <summary>
        /// Gets the scheduled from time.
        /// </summary>
        /// <value>The scheduled from time.</value>
        public string ScheduledFromTime
        {
            get
            {
                return ScheduledFrom.HasValue ? ScheduledFrom.Value.ToString("HH:mm") : string.Empty;
            }
        }

        /// <summary>
        /// Gets the scheduled to day.
        /// </summary>
        /// <value>The scheduled to day.</value>
        public string ScheduledToDay
        {
            get
            {
                return ScheduledTo.HasValue ? ScheduledTo.Value.DayOfWeek.ToString() : string.Empty;
            }
        }

        /// <summary>
        /// Gets the scheduled to time.
        /// </summary>
        /// <value>The scheduled to time.</value>
        public string ScheduledToTime
        {
            get
            {
                return ScheduledTo.HasValue ? ScheduledTo.Value.ToString("HH:mm") : string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the scheduled from.
        /// </summary>
        /// <value>The scheduled from.</value>
        public DateTime? ScheduledFrom { get; set; }

        /// <summary>
        /// Gets or sets the scheduled to.
        /// </summary>
        /// <value>The scheduled to.</value>
        public DateTime? ScheduledTo { get; set; }

        #endregion
    }
}
