// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GroupViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  GroupViewModel class definition
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
    //  GroupViewModel class definition
    /// </summary>
    public class GroupViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Group Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [AllowHtml]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        [Required(ErrorMessage = "{0} is required.")]
        [AllowHtml]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the student number.
        /// </summary>
        /// <value>The student number.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Student Number")]
        [AllowHtml]
        public string StudentNumber { get; set; }

        #endregion

    }
}
