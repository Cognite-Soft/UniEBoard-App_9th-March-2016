// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  CourseViewModel class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using UniEBoard.Model.Entities;
using UniEBoard;
using UniEBoard.Resource;

namespace UniEBoard.Service.Models
{
    /// <summary>
    //  CourseViewModel class definition
    /// </summary>
    public class CourseViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        //[Required]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        [AllowHtml]
        [Required(ErrorMessage = "{0} is required.")]
        //[Display(EntityDisplayNames.Assets]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        //[Required]
        [DataType(DataType.Text)]
        [Display(Name = "Code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the overview.
        /// </summary>
        /// <value>The overview.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        [Required(ErrorMessage = "{0} is required.")]
        [AllowHtml]
        public string Overview { get; set; }

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>The length.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Length")]
        //[Required(ErrorMessage = "{0} is required.")]
        public string Length { get; set; }

        /// <summary>
        /// Gets or sets the publish from.
        /// </summary>
        /// <value>The publish from.</value>
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "{0} is required.")]
        public DateTime PublishFrom { get; set; }

        /// <summary>
        /// Gets or sets the publish to.
        /// </summary>
        /// <value>The publish to.</value>
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [Required(ErrorMessage = "{0} is required.")]
        public DateTime PublishTo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ModuleViewModel"/> is approved.
        /// </summary>
        /// <value><c>true</c> if approved; otherwise, <c>false</c>.</value>
        [Display(Name = "Approved")]
        public bool Approved { get; set; }

         /// <summary>
        /// Gets or sets the course template id.
        /// </summary>
        /// <value>The course template id.</value>
        [Display(Name = "Course Id")]
        public int CourseTemplate_Id { get; set; }

        /// <summary>
        /// Gets or sets the company id.
        /// </summary>
        /// <value>The company id.</value>
        [Required]
        [Display(Name = "CompanyId")]
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the department_ id.
        /// </summary>
        /// <value>The department_ id.</value>
        //[Required]
        [Display(Name = "Department")]
        [Required(ErrorMessage = "{0} is required.")]
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the modules.
        /// </summary>
        /// <value>The modules.</value>
        public ICollection<ModuleViewModel> Modules { get; set; }

        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        /// <value>
        /// The name of the department.
        /// </value>
        [Display(Name = "Department Name")]
        public string DepartmentName { set; get; }


        /// <summary>
        /// Gets or sets the staff count.
        /// </summary>
        /// <value>
        /// The staff count.
        /// </value>
        public string  StaffUsers { set; get; }

        /// <summary>
        /// Gets or sets the student count.
        /// </summary>
        /// <value>
        /// The student count.
        /// </value>
        public int StudentCount { set; get; }

        /// <summary>
        /// Gets or sets the accreditation_ id.
        /// </summary>
        /// <value>The accreditation_ id.</value>
        public int Accreditation_Id { get; set; }

        /// <summary>
        /// Gets or set the order of the course
        /// </summary>
        public Nullable<int> SortOrder { get; set; }

        /// <summary>
        /// The id of the owner of the course, usually the staff
        /// </summary>
        public Nullable<int> OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the course modules.
        /// </summary>
        /// <value>The course modules.</value>
        public ICollection<CourseModuleViewModel> CourseModules { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<CourseRegistrationViewModel> CourseRegistrations { get; set; }

        #endregion

    }


}
