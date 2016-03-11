// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseFileViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  BaseFileViewModel class definition
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
    //  BaseFileViewModel class definition
    /// </summary>
    public class BaseFileViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identity token.
        /// </summary>
        /// <value>The identity token.</value>
        public Guid IdentityToken { get; set; }

        /// <summary>
        /// Gets or sets the filename.
        /// </summary>
        /// <value>The filename.</value>
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "FileName")]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        /// <value>The extension.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Extension")]
        public string Extension { get; set; }

        /// <summary>
        /// Gets or sets the submission id.
        /// </summary>
        /// <value>The submission id.</value>
        [Display(Name = "Submission Id")]
        public int SubmissionId { get; set; }

        /// <summary>
        /// Gets or sets the assignment id.
        /// </summary>
        /// <value>The assignment id.</value>
        [Display(Name = "Assignment Id")]
        public int AssignmentId { get; set; }

        /// <summary>
        /// Gets or sets the unit id.
        /// </summary>
        /// <value>The unit id.</value>
        [Display(Name = "Unit Id")]
        public int UnitId { get; set; }

        #endregion
    }
}
