// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Task.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Task class definition
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
    /// Task class definition
    /// </summary>
    public class Task : BaseTask
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Task"/> class.
        /// </summary>
        public Task()
            : base()
        {
            IsCompleted = false;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>The note.</value>
        public string Note { get; set; }

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
        /// Gets the priority.
        /// </summary>
        /// <value>The priority.</value>
        public override PriorityType Priority
        {
            get
            {
                return IsCompleted ? PriorityType.None : base.Priority;
            }
        }

        /// <summary>
        /// Gets the days due.
        /// </summary>
        /// <value>The days due.</value>
        public override int DaysDue
        {
            get
            {
                return IsCompleted ? 0 : base.DaysDue;
            }
        }

        /// <summary>
        /// Gets or sets the days left.
        /// </summary>
        /// <value>The days left.</value>
        public override string DaysLeft
        {
            get
            {
                return IsCompleted ? string.Empty : base.DaysLeft;
            }
        }

        #endregion
    }
}
