// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  MessageViewModel class definition
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
    //  MessageViewModel class definition
    /// </summary>
    public class MessageViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Alert Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [AllowHtml]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Body")]
        [Required(ErrorMessage = "{0} is required.")]
        [AllowHtml]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>The date created.</value>
        [Display(Name = "Date Created")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Required(ErrorMessage = "{0} is required.")]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the type of the alert.
        /// </summary>
        /// <value>The type of the alert.</value>
        [Display(Name = "Alert Type")]
        public int MessageType { get; set; }

        /// <summary>
        /// Gets or sets from user id.
        /// </summary>
        /// <value>From user id.</value>
        [Display(Name = "From")]
        public int FromUserId { get; set; }

        /// <summary>
        /// Gets or sets the recipient user id.
        /// </summary>
        /// <value>The recipient user id.</value>
        [Display(Name = "User")]
        public int RecipientUserId { get; set; }

        /// <summary>
        /// Gets or sets the entity Id this message is created for
        /// </summary>
        public Nullable<int> EntityId { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>The comments.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Comments")]
        public string Comments { get; set; }

        #endregion
    }
}
