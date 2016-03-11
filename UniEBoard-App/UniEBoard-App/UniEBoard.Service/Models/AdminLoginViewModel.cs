// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdminLoginViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  AdminLoginViewModel class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace UniEBoard.Service.Models
{
    /// <summary>
    /// AdminLoginViewModel class definition
    /// </summary>
    public class AdminLoginViewModel : BaseViewModel
    {
        #region Properties
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        [Required(ErrorMessage="User field is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "User:")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [Required(ErrorMessage = "Password field is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        #endregion
    }
}
