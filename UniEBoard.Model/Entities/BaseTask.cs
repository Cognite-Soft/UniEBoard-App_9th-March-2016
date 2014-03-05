// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseTask.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  BaseTask abstract base class definition { Parent for Assignment and Task classes}
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
    /// The Base Entity Class
    /// </summary>
    public abstract class BaseTask : BaseEntity
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTask"/> class.
        /// </summary>
        public BaseTask()
            : base()
        {
            //Deadline = DateTime.MinValue;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the deadline.
        /// </summary>
        /// <value>The deadline.</value>
        public DateTime? Deadline { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is task.
        /// </summary>
        /// <value><c>true</c> if this instance is task; otherwise, <c>false</c>.</value>
        public bool IsTask
        {
            get
            {
                return (this is Task) ? true : false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has deadline.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has deadline; otherwise, <c>false</c>.
        /// </value>
        public bool HasDeadline
        {
            get
            {
                return (Deadline.HasValue && Deadline.Value != DateTime.MinValue) ? true : false;
            }
        }

        /// <summary>
        /// Gets the priority.
        /// </summary>
        /// <value>The priority.</value>
        public virtual PriorityType Priority
        {
            get
            {
                int daysDue = DaysDue;
                PriorityType priority = PriorityType.None;
                if (HasDeadline)
                {
                    if (daysDue <= 5)
                    {
                        priority = PriorityType.High;
                    }
                    else if (daysDue <= 10)
                    {
                        priority = PriorityType.Medium;
                    }
                    else
                    {
                        priority = PriorityType.Low;
                    }
                }
                return priority;
            }
        }

        /// <summary>
        /// Gets the days due.
        /// </summary>
        /// <value>The days due.</value>
        public virtual int DaysDue
        {
            get
            {
                return (HasDeadline)
                    ? (Deadline.Value.Date - DateTime.Now.Date).Days
                    : 0;
            }
        }

        /// <summary>
        /// Gets or sets the days left.
        /// </summary>
        /// <value>The days left.</value>
        public virtual string DaysLeft
        {
            get
            {
                if (!HasDeadline)
                {
                    return string.Empty;
                }
                else if (DaysDue < 0)
                {
                    return "Overdue";
                }
                else if (DaysDue == 0)
                {
                    return "Today";
                }
                else if (DaysDue == 1)
                {
                    return "Tomorrow";
                }
                else
                {
                    return string.Format("{0} Days", DaysDue);
                }
            }
        }

        #endregion
    }
}
