// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuizEntryViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  QuizEntryViewModel class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace UniEBoard.Service.Models.Quizzes
{
    /// <summary>
    ///  QuizEntryViewModel class definition
    /// </summary>
    public class QuizEntryViewModel : BaseViewModel
    {

        #region properties


        /// <summary>
        /// Gets or sets the StudentId.
        /// </summary>
        /// <value>The StudentId.</value>
        [Display(Name = "StudentId:")]
        public int Student_Id { get; set; }

        /// <summary>
        /// Gets or sets the Quiz_Id.
        /// </summary>
        /// <value>The Quiz_Id.</value>
        [Display(Name = "QuizId:")]
        public int Quiz_Id { get; set; }

        /// <summary>
        /// Gets or sets the QuizResult.
        /// </summary>
        /// <value>The QuizResult.</value>
        [Display(Name = "QuizResult:")]
        public int QuizResult { get; set; }


        #endregion
    }
}
