// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseModule.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  CourseModule class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// CourseModule class definition
    /// </summary>
    public class CourseModule : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the course_ id.
        /// </summary>
        /// <value>The course_ id.</value>
        public int Course_Id { get; set; }

        /// <summary>
        /// Gets or sets the module_ id.
        /// </summary>
        /// <value>The module_ id.</value>
        public int Module_Id { get; set; }

        /// <summary>
        /// Gets or sets the course.
        /// </summary>
        /// <value>The course.</value>
        public Course Course { get; set; }

        /// <summary>
        /// Gets or sets the module.
        /// </summary>
        /// <value>The module.</value>
        public Module Module { get; set; }

        #endregion
    }
}
