// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserLoginViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  UserLoginViewModel class definition
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
    /// UserLoginViewModel class definition
    /// </summary>
    public class UserLoginViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the type of the user.
        /// </summary>
        /// <value>The type of the user.</value>
        //[Required(ErrorMessage = "Are you a Student or a Teacher?")]
        [Display(Name = "Are you a student or teacher?")]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select your Login")]
        public int? UserType { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        [Required(ErrorMessage="User field is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "User:")]
        [AllowHtml]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [Required(ErrorMessage = "Password field is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [remember me].
        /// </summary>
        /// <value><c>true</c> if [remember me]; otherwise, <c>false</c>.</value>
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        #endregion
    }
}
