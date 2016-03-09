// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Module.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Module class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// Module class definition
    /// </summary>
    public class Module : BaseEntity
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
        /// Gets or sets the score.
        /// </summary>
        /// <value>The score.</value>
        public string Score { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Course"/> is approved.
        /// </summary>
        /// <value><c>true</c> if approved; otherwise, <c>false</c>.</value>
        public bool Approved { get; set; }

        /// <summary>
        /// Gets or sets the created by staff_ id.
        /// </summary>
        /// <value>The created by staff_ id.</value>
        public int CreatedByStaff_Id { get; set; }

        /// <summary>
        /// Gets or sets the course_ id.
        /// </summary>
        /// <value>The course_ id.</value>
        public int Course_Id { get; set; }

        /// <summary>
        /// Gets or sets the SortOrder.
        /// </summary>
        /// <value>The sort order.</value>
        public int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the created by staff.
        /// </summary>
        /// <value>The created by staff.</value>
        public Staff CreatedByStaff { get; set; }

        /// <summary>
        /// Gets or sets the assignments.
        /// </summary>
        /// <value>The assignments.</value>
        public ICollection<Assignment> Assignments { get; set; }

        /// <summary>
        /// Gets or sets the course modules.
        /// </summary>
        /// <value>The course modules.</value>
        public ICollection<CourseModule> CourseModules { get; set; }

        /// <summary>
        /// Gets or sets the units.
        /// </summary>
        /// <value>The units.</value>
        public ICollection<Unit> Units { get; set; }

        /// <summary>
        /// Gets or sets the module quizs.
        /// </summary>
        /// <value>The module quizs.</value>
        public ICollection<ModuleQuiz> ModuleQuizs { get; set; }

        #endregion
    }
}
