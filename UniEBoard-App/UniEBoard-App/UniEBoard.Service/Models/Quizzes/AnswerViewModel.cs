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
    public class AnswerViewModel : BaseViewModel
    {

        #region constructor
        public AnswerViewModel()
        {
            Answers = new List<AnswerQuestionChoiceViewModel>();
        }

        #endregion

        #region properties



        /// <summary>
        /// Gets or sets the Question_Id.
        /// </summary>
        /// <value>The Question_Id.</value>
        [Display(Name = "Question_Id:")]
        public int Question_Id { get; set; }

        /// <summary>
        /// Gets or sets the QuizEntryId.
        /// </summary>
        /// <value>The QuizEntryId.</value>
        [Display(Name = "QuizEntryId:")]
        public int QuizEntryId { get; set; }

        /// <summary>
        /// Gets or sets the Answers.
        /// </summary>
        /// <value>The Answers.</value>
        public List<AnswerQuestionChoiceViewModel> Answers { get; set; }


        #endregion
    }
}
