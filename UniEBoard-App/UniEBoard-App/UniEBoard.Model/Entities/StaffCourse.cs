// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaffCourse.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  StaffCourse class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// StaffCourse class definition
    /// </summary>
    public class StaffCourse : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public DateTime EffectiveFrom { get; set; }

        /// <summary>
        /// Gets or sets the overview.
        /// </summary>
        /// <value>The overview.</value>
        public DateTime EffectiveTo { get; set; }

        /// <summary>
        /// Gets or sets the staff_ id.
        /// </summary>
        /// <value>The staff_ id.</value>
        public int Staff_Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [course_ id].
        /// </summary>
        /// <value><c>true</c> if [course_ id]; otherwise, <c>false</c>.</value>
        public int Course_Id { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the staff.
        /// </summary>
        /// <value>The staff.</value>
        public Staff Staff { get; set; }

        /// <summary>
        /// Gets or sets the course.
        /// </summary>
        /// <value>The course.</value>
        public Course Course { get; set; }

        #endregion
    }
}
