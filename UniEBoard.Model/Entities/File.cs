// --------------------------------------------------------------------------------------------------------------------
// <copyright file="File.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  File class definition - contains file binary data and meta data
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    ///  File class definition
    /// </summary>
    public class File : BaseFile
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
