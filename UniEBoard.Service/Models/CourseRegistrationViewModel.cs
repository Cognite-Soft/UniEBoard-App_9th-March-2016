// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseRegistrationViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  CourseRegistrationViewModel class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using UniEBoard.Model.Entities;

namespace UniEBoard.Service.Models
{
    /// <summary>
    //  CourseRegistrationViewModel class definition
    /// </summary>
    public class CourseRegistrationViewModel : BaseViewModel
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
        /// Gets or sets the student_ id.
        /// </summary>
        /// <value>The student_ id.</value>
        public StudentViewModel Student { get; set; }

        /// <summary>
        /// Gets or sets the course_ id.
        /// </summary>
        /// <value>The course_ id.</value>
        public CourseViewModel Course { get; set; }

        #endregion

    }


}
