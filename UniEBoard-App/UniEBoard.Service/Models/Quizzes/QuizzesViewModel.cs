// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuizzesViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  QuizzesViewModel class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using UniEBoard.Model.Enums;

namespace UniEBoard.Service.Models.Quizzes
{
    /// <summary>
    //  QuizzesViewModel class definition
    /// </summary>
    public class QuizzesViewModel : BaseViewModel
    {

        #region properties


        /// <summary>
        /// Gets or sets the CourseId.
        /// </summary>
        /// <value>The CourseId.</value>
        [DataType(DataType.Text)]
        [Display(Name = "CourseId:")]
        public int CourseId { get; set; }


        /// <summary>
        /// Gets or sets the CourseTitle.
        /// </summary>
        /// <value>The CourseTitle.</value>
        [DataType(DataType.Text)]
        [Display(Name = "CourseTitle:")]
        public int CourseTitle { get; set; }

        /// <summary>
        /// Gets or sets the ModuleId.
        /// </summary>
        /// <value>The ModuleId.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Module")]
        public int ModuleId { get; set; }


        /// <summary>
        /// Gets or sets the ModuleTitle.
        /// </summary>
        /// <value>The ModuleTitle.</value>
        [DataType(DataType.Text)]
        [Display(Name = "ModuleTitle:")]
        public string ModuleTitle { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Quiz Title")]
        [Required(ErrorMessage = "* Title field is required.")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the PublishFrom.
        /// </summary>
        /// <value>The PublishFrom.</value>
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime PublishFrom { get; set; }

        /// <summary>
        /// Gets or sets the PublishTo.
        /// </summary>
        /// <value>The PublishTo.</value>
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime PublishTo { get; set; }

        /// <summary>
        /// Gets or sets the MaxAttemptsAllowed.
        /// </summary>
        /// <value>The MaxAttemptsAllowed.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Allowed Attempts")]
        public int MaxAttemptsAllowed { get; set; }

        /// <summary>
        /// Gets or sets the AttemptsSoFar.
        /// </summary>
        /// <value>The AttemptsSoFar.</value>
        [Display(Name = "AttemptsSoFar:")]
        public int AttemptsSoFar { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>The Description.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the DisplayEndResults.
        /// </summary>
        /// <value>The DisplayEndResults.</value>
        [Display(Name = "Display End Results:")]
        [Required(ErrorMessage = "* field is required.")]
        public QuizDisplayEndResultsOptions DisplayEndResults { get; set; }

        /// <summary>
        /// Gets or sets the CorrectUserChoices.
        /// </summary>
        /// <value>The CorrectUserChoices.</value>
        [Display(Name = "CorrectUserChoices:")]
        [Required(ErrorMessage = "* field is required.")]
        public bool CorrectUserChoices { get; set; }

        /// <summary>
        /// Gets or sets the Instructions.
        /// </summary>
        /// <value>The Instructions.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Instructions:")]
        public string Instructions { get; set; }


        /// <summary>
        /// Gets or sets the Deadline.
        /// </summary>
        /// <value>The Deadline.</value>
        [DataType(DataType.DateTime)]
        [Display(Name = "Deadline:")]
        public Nullable<System.DateTime> Deadline { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Total Score:")]
        public Nullable<int> Score { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<QuestionViewModel> questions { get; set; }


        #endregion
    }
}

