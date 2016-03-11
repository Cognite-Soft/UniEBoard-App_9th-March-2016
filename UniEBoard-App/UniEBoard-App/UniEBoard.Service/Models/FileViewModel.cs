// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  FileViewModel class definition
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
    //  FileViewModel class definition
    /// </summary>
    public class FileViewModel : BaseFileViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the binary content.
        /// </summary>
        /// <value>The binary content.</value>
        public byte[] Content { get; set; }


        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        /// <value>The type of the content.</value>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the contentlength.
        /// </summary>
        /// <value>The contentlength.</value>
        public int ContentLength { get; set; }

        #endregion
    }
}
