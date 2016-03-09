// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Course.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Course class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// Couse class definition
    /// </summary>
    public class Course : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the overview.
        /// </summary>
        /// <value>The overview.</value>
        public string Overview { get; set; }

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>The length.</value>
        public string Length { get; set; }

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>The length.</value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Course"/> is approved.
        /// </summary>
        /// <value><c>true</c> if approved; otherwise, <c>false</c>.</value>
        public bool Approved { get; set; }

        /// <summary>
        /// Gets or sets the department_ id.
        /// </summary>
        /// <value>The department_ id.</value>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the company id.
        /// </summary>
        /// <value>The company id.</value>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the accreditation_ id.
        /// </summary>
        /// <value>The accreditation_ id.</value>
        public int Accreditation_Id { get; set; }

        /// <summary>
        /// Gets or sets the course template_ id.
        /// </summary>
        /// <value>The course template_ id.</value>
        public int CourseTemplate_Id { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>The company.</value>
        public Company Company { get; set; }

        /// <summary>
        /// Gets or sets the course registrations.
        /// </summary>
        /// <value>The course registrations.</value>
        public ICollection<CourseRegistration> CourseRegistrations { get; set; }

        /// <summary>
        /// Gets or sets the course modules.
        /// </summary>
        /// <value>The course modules.</value>
        public ICollection<CourseModule> CourseModules { get; set; }

        /// <summary>
        /// Gets or sets the staff courses.
        /// </summary>
        /// <value>The staff courses.</value>
        public ICollection<StaffCourse> StaffCourses { get; set; }

        /// <summary>
        /// Gets or sets the course department.
        /// </summary>
        /// <value>
        /// The course department.
        /// </value>
        public Department Department { get; set; }

        /// <summary>
        /// Gets or set the order of the course
        /// </summary>
        public Nullable<int> SortOrder { get; set; }

        /// <summary>
        /// The id of the owner of the course, usually the staff
        /// </summary>
        public Nullable<int> OwnerId { get; set; }

        #endregion
    }
}
