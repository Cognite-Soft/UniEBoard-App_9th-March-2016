// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  ModuleViewModel class definition
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
    //  ModuleViewModel class definition
    /// </summary>
    public class ModuleViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        [AllowHtml]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>The overview.</value>
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        [AllowHtml]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the publish from.
        /// </summary>
        /// <value>The publish from.</value>
        //[Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? PublishFrom { get; set; }

        /// <summary>
        /// Gets or sets the publish to.
        /// </summary>
        /// <value>The publish to.</value>
        //[Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? PublishTo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ModuleViewModel"/> is approved.
        /// </summary>
        /// <value><c>true</c> if approved; otherwise, <c>false</c>.</value>
        [Display(Name = "Approved")]
        public bool Approved { get; set; }

        /// <summary>
        /// Gets or sets the course_ id.
        /// </summary>
        /// <value>The course_ id.</value>
        [Display(Name = "Course Id")]
        public int Course_Id { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        [Display(Name = "Sort Order")]
        public int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the CreatedByStaff_id.
        /// </summary>
        /// <value>The CreatedByStaff_id.</value>
        [Display(Name = "Staff Id")]
        public int CreatedByStaff_Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Quizzes.QuizzesViewModel> Quizzes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<UnitViewModel> Units { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<CourseModuleViewModel> CourseModules { get; set; }

        public List<AssignmentViewModel> Assignments { get; set; }


        #endregion
    }


    /// <summary>
    //  ModuleSyllabusModel class definition
    /// </summary>
    public class ModuleSyllabusModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// PublishFrom
        /// </summary>
        /// <value>PublishFrom</value>
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "PublishFrom")]
        public string PublishFrom { get; set; }

        /// <summary>
        /// PublishTo
        /// </summary>
        /// <value>PublishTo</value>
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "PublishTo")]
        public string PublishTo { get; set; }

        /// <summary>
        /// Title of the module
        /// </summary>
        /// <value>title</value>
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Modules")]
        public List<ModuleViewModel> Modules { get; set; }

          
        #endregion
    }

    /// <summary>
    //  ModuleQuizViewModel class definition
    /// </summary>
    public class ModuleQuizViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the quiz id.
        /// </summary>
        /// <value>The quiz id.</value>
        [Required]
        [Display(Name = "QuizId")]
        public int QuizId { get; set; }

        /// <summary>
        /// Gets or sets the module id.
        /// </summary>
        /// <value>The module id.</value>
        [Required]
        [Display(Name = "ModuleId")]
        public int ModuleId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ModuleViewModel> Modules { get; set; }

        

        #endregion
    }

}
