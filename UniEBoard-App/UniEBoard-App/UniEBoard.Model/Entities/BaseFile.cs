// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseFile.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  BaseFile class definition - contains file metadata information
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    ///  BaseFile class definition
    /// </summary>
    public class BaseFile : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        /// <value>The extension.</value>
        public string Extension { get; set; }

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>The file path.</value>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the identity token.
        /// </summary>
        /// <value>The identity token.</value>
        public Guid IdentityToken { get; set; }

        /// <summary>
        /// Gets or sets the submission id.
        /// </summary>
        /// <value>The submission id.</value>
        public int? SubmissionId { get; set; }

        /// <summary>
        /// Gets or sets the assignment id.
        /// </summary>
        /// <value>The assignment id.</value>
        public int? AssignmentId { get; set; }

        /// <summary>
        /// Gets or sets the unit id.
        /// </summary>
        /// <value>The unit id.</value>
        public int? UnitId { get; set; }

        /// <summary>
        /// Gets or sets the submission.
        /// </summary>
        /// <value>The submission.</value>
        public Submission Submission { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>The unit.</value>
        public Unit Unit { get; set; }

        /// <summary>
        /// Gets or sets the assignment.
        /// </summary>
        /// <value>The assignment.</value>
        public Assignment Assignment { get; set; }

        #endregion
    }
}
