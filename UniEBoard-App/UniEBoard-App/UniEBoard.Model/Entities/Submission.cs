// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Submission.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Submission class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    ///  Submission class definition
    /// </summary>
    public class Submission : BaseEntity
    {
        #region Constructor
        public Submission() 
        {
            Status = 1;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the date submitted.
        /// </summary>
        /// <value>The date submitted.</value>
        public DateTime? DateSubmitted { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the student id.
        /// </summary>
        /// <value>The student id.</value>
        public int StudentId { get; set; }

        /// <summary>
        /// Gets or sets the assignment id.
        /// </summary>
        /// <value>The assignment id.</value>
        public int AssignmentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? GradePointValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Assignment Assignment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Student Student { get; set; }
        
        /// <summary>
        /// Gets or sets the file uploads.
        /// </summary>
        /// <value>The file uploads.</value>
        public ICollection<BaseFile> FileUploads { get; set; }

        #endregion
    }
}
