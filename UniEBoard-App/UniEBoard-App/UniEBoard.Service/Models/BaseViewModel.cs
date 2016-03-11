// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  BaseViewModel class definition
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
    //  BaseViewModel class definition
    /// </summary>
    public class BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [Display(Name = "Id")]
        public int Id { get; set; }

        #endregion
    }
}
