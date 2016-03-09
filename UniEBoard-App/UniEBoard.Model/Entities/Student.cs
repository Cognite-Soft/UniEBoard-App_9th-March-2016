// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Student.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Student class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// Student class definition
    /// </summary>
    public class Student : User
    {
        #region Properties

        /// <summary>
        /// Gets or sets the student number.
        /// </summary>
        /// <value>The student number.</value>
        public string StudentNumber { get; set; }

        /// <summary>
        /// Gets or sets the course registrations.
        /// </summary>
        /// <value>The course registrations.</value>
        public ICollection<CourseRegistration> CourseRegistrations { get; set; }

        /// <summary>
        /// Gets or sets the submissions.
        /// </summary>
        /// <value>The submissions.</value>
        public ICollection<Submission> Submissions { get; set; }

        #endregion
    }
}
