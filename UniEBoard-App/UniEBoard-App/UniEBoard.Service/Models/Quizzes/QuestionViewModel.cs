// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestionViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  QuestionViewModel class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using UniEBoard.Model.Enums;
using System.Web.Mvc;

namespace UniEBoard.Service.Models.Quizzes
{
    /// <summary>
    ///  QuestionViewModel class definition
    /// </summary>
    public class QuestionViewModel : BaseViewModel
    {

        #region constructor
        /// <summary>
        /// QuestionViewModel constructor
        /// </summary>
        public QuestionViewModel()
        {
            QuestionChoices = new List<QuestionChoicesViewModel>();
            CongratulationMessage = string.Empty;
            StudentChoices = new string[] { "" };

        }
        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>The Name.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Question")]
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or sets the AllowMultipleSelections.
        /// </summary>
        /// <value>The AllowMultipleSelections.</value>
        [Display(Name = "AllowMultipleSelections")]
        public bool AllowMultipleSelections { get; set; }
        
        /// <summary>
        /// Gets or sets the HelpText.
        /// </summary>
        /// <value>The HelpText.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Help")]
        public string HelpText { get; set; }

        /// <summary>
        /// Gets or sets the Quiz_Id.
        /// </summary>
        /// <value>The Quiz_Id.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Quiz_Id")]
        public int Quiz_Id { get; set; }

        /// <summary>
        /// Gets or sets the Sort Order.
        /// </summary>
        /// <value>The Sort Order.</value>
        public int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the QuizEntry_Id.
        /// </summary>
        /// <value>The QuizEntry_Id.</value>
        [DataType(DataType.Text)]
        [Display(Name = "QuizEntry_Id")]
        public int QuizEntry_Id { get; set; }
        
        /// <summary>
        /// Gets or sets the Question Position.
        /// </summary>
        /// <value>The questionPosition.</value>
        [Display(Name = "questionPosition")]
        public int questionPosition { get; set; }

        /// <summary>
        /// Gets or sets the numquestions Position.
        /// </summary>
        /// <value>The numquestions.</value>
        [Display(Name = "numquestions")]
        public int numquestions { get; set; }

        /// <summary>
        /// Gets or sets the QuestionNumber.
        /// </summary>
        /// <value>The QuestionNumber.</value>
        [Display(Name = "QuestionNumber")]
        public int QuestionNumber { get; set; }

        /// <summary>
        /// Gets or sets the Congratulation Message.
        /// </summary>
        /// <value>The Congratulation Message.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Congratulation")]
        public string CongratulationMessage { get; set; }

        /// <summary>
        /// Gets or sets the Congratulation Message.
        /// </summary>
        /// <value>The Congratulation Message.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Result")]
        public int Result { get; set; }

        /// <summary>
        /// Gets or sets the Congratulation Message.
        /// </summary>
        /// <value>The Congratulation Message.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Solution")]
        public string QuestionMessageSolution { get; set; }

        /// <summary>
        /// Gets or sets the Congratulation Message.
        /// </summary>
        /// <value>The Congratulation Message.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Explanation")]
        public string Explanation { get; set; }

        /// <summary>
        /// Gets or sets the question type_ id.
        /// </summary>
        /// <value>The question type_ id.</value>
        [Display(Name = "Answer Type")]
        public QuestionQuizType QuestionType_Id { get; set; }

        /// <summary>
        /// Gets the question type text.
        /// </summary>
        /// <value>The question type text.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Type")]
        public string QuestionTypeText { get; set; }

        /// <summary>
        /// All the student choices 
        /// </summary>
        public string[] StudentChoices { get; set; }

        /// <summary>
        /// list of questions choices
        /// </summary>
        public List<QuestionChoicesViewModel> QuestionChoices { get; set; }

        /// <summary>
        /// Answer 
        /// </summary>
        public AnswerViewModel Answers { get; set; }

        /// <summary>
        /// Gets the question type text.
        /// </summary>
        /// <value>The question type text.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Total Points")]
        public int TotalPoints { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SelectList QuestionQuizTypeChoices { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int QuestionQuizTypeSelected { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public QuizzesViewModel Quiz { get; set; }

        #endregion
    }
}
