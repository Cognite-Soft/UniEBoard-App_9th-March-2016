// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StudentViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  StudentViewModel class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UniEBoard.Service.Models
{
    /// <summary>
    //  StudentViewModel class definition
    /// </summary>
    public class StudentViewModel : UserViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the student number.
        /// </summary>
        /// <value>The student number.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Student Ref")]
        public string StudentNumber { get; set; }

        /// <summary>
        /// Gets or sets the course registrations.
        /// </summary>
        /// <value>The course registrations.</value>
        public ICollection<CourseRegistrationViewModel> CourseRegistrations { get; set; }

        #endregion
    }
}
