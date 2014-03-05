// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaffViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  StaffViewModel class definition
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
    //  StaffViewModel class definition
    /// </summary>
    public class StaffViewModel : UserViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the department_ id.
        /// </summary>
        /// <value>The department_ id.</value>
        [Required]
        [Display(Name = "DepartmentId")]
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the position_ id.
        /// </summary>
        /// <value>The position_ id.</value>
        [Required]
        [Display(Name = "PositionId")]
        public int Position_Id { get; set; }

        #endregion
    }
}
