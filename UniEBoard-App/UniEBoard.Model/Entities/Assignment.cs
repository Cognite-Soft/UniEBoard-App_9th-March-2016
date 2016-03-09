// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Assignment.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Assignment class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// Assignment class definition
    /// </summary>
    public class Assignment : BaseTask
    {
        #region Properties

        /// <summary>
        /// Gets or sets the instructions.
        /// </summary>
        /// <value>The instructions.</value>
        public string Instructions { get; set; }

        /// <summary>
        /// Gets or sets the quiz id.
        /// </summary>
        /// <value>The quiz id.</value>
        public int? QuizId { get; set; }

        /// <summary>
        /// Gets or sets the course id.
        /// </summary>
        /// <value>The course id.</value>
        public int? CourseId { get; set; }

        /// <summary>
        /// Gets or sets the unit id.
        /// </summary>
        /// <value>The unit id.</value>
        public int? UnitId { get; set; }

        /// <summary>
        /// Gets or sets the module id.
        /// </summary>
        /// <value>The module id.</value>
        public int? ModuleId { get; set; }

        /// <summary>
        /// Gets or sets the points possible.
        /// </summary>
        /// <value>The points possible.</value>
        public int? PointsPossible { get; set; }

        /// <summary>
        /// Gets or sets the submissions.
        /// </summary>
        /// <value>The submissions.</value>
        public ICollection<Submission> Submissions { get; set; }

        /// <summary>
        /// Gets or sets the file uploads.
        /// </summary>
        /// <value>The file uploads.</value>
        public ICollection<BaseFile> FileUploads { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Asset> Assets { get; set; }


        /// <summary>
        /// Gets or sets the module.
        /// </summary>
        /// <value>The module.</value>
        public Module Module { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Course Course { get; set; }

        #endregion
    }
}
