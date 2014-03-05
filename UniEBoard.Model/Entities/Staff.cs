// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Staff.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Staff class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// Staff class definition
    /// </summary>
    public class Staff : User
    {
        #region Properties

        /// <summary>
        /// Gets or sets the department id.
        /// </summary>
        /// <value>The department id.</value>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the department_id.
        /// </summary>
        /// <value>The department_id.</value>
        public int Position_Id { get; set; }

        /// <summary>
        /// Gets or sets the staff courses.
        /// </summary>
        /// <value>The staff courses.</value>
        public ICollection<StaffCourse> StaffCourses { get; set; }

        #endregion
    }
}
