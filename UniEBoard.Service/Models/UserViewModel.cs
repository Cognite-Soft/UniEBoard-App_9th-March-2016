// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaffViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  StaffViewModel class definition
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
    public class UserViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        [DataType(DataType.Text)]
        //[Required(ErrorMessage = "{0} is required.")]
        [Display(Name = "User name")]
        [AllowHtml]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        //[Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>The confirm password.</value>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [DataType(DataType.Text)]
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "{0} is required.")]
        [AllowHtml]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [DataType(DataType.Text)]
        [Display(Name = "LastName")]
        [Required(ErrorMessage = "{0} is required.")]
        [AllowHtml]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} is required.")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>The date of birth.</value>
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        //[Required(ErrorMessage = "{0} is required.")]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the user gender.
        /// </summary>
        /// <value>The user gender.</value>
        [Display(Name = "Gender")]
        //[Range(1, int.MaxValue, ErrorMessage = "Please Select your Gender")]
        public int UserGender { get; set; }

        /// <summary>
        /// Gets or sets the mobile.
        /// </summary>
        /// <value>The mobile.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the company id.
        /// </summary>
        /// <value>The company id.</value>
        [Display(Name = "CompanyId")]
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the courses.
        /// </summary>
        /// <value>The courses.</value>
        public ICollection<CourseViewModel> Courses { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The user roles.</value>
        public ICollection<RoleViewModel> Roles { get; set; }

        /// <summary>
        /// Gets or sets the default course id.
        /// </summary>
        /// <value>The default course id.</value>
        [Display(Name = "Course")]
        [Required(ErrorMessage = "{0} is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select your Course")]
        public int DefaultCourseId { get; set; }

        /// <summary>
        /// Gets or sets the membership_ id.
        /// </summary>
        /// <value>The membership_ id.</value>
        [Display(Name = "Membership Id")]
        public int Membership_Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [account disabled].
        /// </summary>
        /// <value><c>true</c> if [account disabled]; otherwise, <c>false</c>.</value>
        public bool AccountDisabled { get; set; }


        public string FullName 
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        public bool IsAdmin
        {
            get
            {
                foreach (var role in this.Roles)
                {
                    if (role.Title.Trim().ToLower().Equals(Service.C.Roles.Administrator.ToLower()))
                        return true;
                }
                return false;
            }
        }

        public bool IsTeacher
        {
            get
            {
                foreach (var role in this.Roles)
                {
                    if (role.Title.Trim().ToLower().Equals(Service.C.Roles.Teacher.ToLower()))
                        return true;
                }
                return false;
            }
        }

        public bool IsStudent
        {
            get
            {
                foreach (var role in this.Roles)
                {
                    if (role.Title.Trim().ToLower().Equals(Service.C.Roles.Student.ToLower()))
                        return true;
                }
                return false;
            }
        }
    }
}
