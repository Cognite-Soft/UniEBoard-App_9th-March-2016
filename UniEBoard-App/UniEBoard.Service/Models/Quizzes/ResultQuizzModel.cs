// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResultQuizz.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  ResultQuizz class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace UniEBoard.Service.Models.Quizzes
{
    public class ResultQuizzModel
    {

        #region properties

        /// <summary>
        /// Gets or sets the Results.
        /// </summary>
        /// <value>The Results.</value>
        [Display(Name = "Name:")]
        public string Name { get; set; }


        /// <summary>
        /// Gets or sets the ResultMessage.
        /// </summary>
        /// <value>The ResultMessage.</value>
        [Display(Name = "ResultMessage:")]
        public string ResultMessage { get; set; }


        /// <summary>
        /// Gets or sets the Results.
        /// </summary>
        /// <value>The Results.</value>
        [Display(Name = "Results:")]
        public int Results { get; set; }


        /// <summary>
        /// Gets or sets the PointValueTotal.
        /// </summary>
        /// <value>The PointValueTotal.</value>
        [Display(Name = "PointValueTotal:")]
        public int PointValueTotal { get; set; }

        /// <summary>
        /// Gets or sets the PointValueTotal.
        /// </summary>
        /// <value>The PointValueTotal.</value>
        [Display(Name = "Percent:")]
        public int Percent { get; set; }


        /// <summary>
        /// Gets or sets the QuestionIncorrect.
        /// </summary>
        /// <value>The QuestionIncorrect.</value>
        [Display(Name = "QuestionIncorrect:")]
        public int QuestionIncorrect { get; set; }




        /// <summary>
        /// Gets or sets the MaxScoreSuccess.
        /// </summary>
        /// <value>The MaxScoreSuccess.</value>
        [Display(Name = "MaxScoreSuccess:")]
        public int MaxScoreSuccess { get; set; }

        /// <summary>
        /// Gets or sets the QuizId.
        /// </summary>
        /// <value>The QuizId.</value>
        [Display(Name = "QuizId:")]
        public int QuizId { get; set; }

        /// <summary>
        /// Gets or sets the TimeTaken.
        /// </summary>
        /// <value>The TimeTaken.</value>
        [Display(Name = "TimeTaken:")]
        public TimeSpan TimeTaken { get; set; }

        #endregion
    }
}
