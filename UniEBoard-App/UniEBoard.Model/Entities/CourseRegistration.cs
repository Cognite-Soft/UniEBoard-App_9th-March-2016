// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseRegistration.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  CourseRegistration class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// CourseRegistration class definition
    /// </summary>
    public class CourseRegistration : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the effective from.
        /// </summary>
        /// <value>The effective from.</value>
        public DateTime? EffectiveFrom { get; set; }

        /// <summary>
        /// Gets or sets the effective to.
        /// </summary>
        /// <value>The effective to.</value>
        public DateTime? EffectiveTo { get; set; }

        /// <summary>
        /// Gets or sets the student_ id.
        /// </summary>
        /// <value>The student_ id.</value>
        public int Student_Id { get; set; }

        /// <summary>
        /// Gets or sets the course_ id.
        /// </summary>
        /// <value>The course_ id.</value>
        public int Course_Id { get; set; }

        /// <summary>
        /// Gets or sets the course.
        /// </summary>
        /// <value>The course.</value>
        public Course Course { get; set; }

        /// <summary>
        /// Gets or sets the student.
        /// </summary>
        /// <value>The student.</value>
        public Student Student { get; set; }

        #endregion
    }
}
