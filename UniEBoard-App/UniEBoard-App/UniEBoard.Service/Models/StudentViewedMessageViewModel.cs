// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StudentViewedMessageViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  StudentViewedMessageViewModel class definition
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
    //  StudentViewedMessageViewModel class definition
    /// </summary>
    public class StudentViewedMessageViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [Display(Name = "Student Id")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [Display(Name = "Message Id")]
        public int MessageId { get; set; }

        #endregion
    }
}
