// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnswerQuestionChoiceViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  AnswerQuestionChoice class definition
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
    ///  AnswerQuestionChoiceViewModel class definition
    /// </summary>
    public class AnswerQuestionChoiceViewModel : BaseViewModel
    {

        #region properties


        /// <summary>
        /// Gets or sets the QuestionChoiceId.
        /// </summary>
        /// <value>The QuestionChoiceId.</value>
        [Display(Name = "QuestionChoiceId:")]
        public int QuestionChoiceId { get; set; }

        /// <summary>
        /// Gets or sets the AnswerId.
        /// </summary>
        /// <value>The AnswerId.</value>
        [Display(Name = "AnswerId:")]
        public int AnswerId { get; set; }

        #endregion
    }
}
