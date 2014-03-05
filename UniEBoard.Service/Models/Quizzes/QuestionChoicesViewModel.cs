// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestionChoicesViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  QuestionChoicesViewModel class definition
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
    ///  QuestionChoicesViewModel class definition
    /// </summary>
    public class QuestionChoicesViewModel : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionChoicesViewModel"/> class.
        /// </summary>
        public QuestionChoicesViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionChoicesViewModel"/> class.
        /// </summary>
        /// <param name="showAddButton">if set to <c>true</c> [show add button].</param>
        /// <param name="isCorrect">if set to <c>true</c> [is correct].</param>
        public QuestionChoicesViewModel(bool showAddButton, bool isCorrect = false)
        {
            ShowAddButton = showAddButton;
            CorrectAnswer = isCorrect;
        }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>The Name.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Answer")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the PointsValue.
        /// </summary>
        /// <value>The PointsValue.</value>
        [Display(Name = "PointsValue")]
        public short PointsValue { get; set; }

        /// <summary>
        /// Gets or sets the DisplayOrder.
        /// </summary>
        /// <value>The DisplayOrder.</value>
        [Display(Name = "DisplayOrder")]
        public short DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the CorrectAnswer.
        /// </summary>
        /// <value>The CorrectAnswer.</value>
        [Display(Name = "CorrectAnswer")]
        public bool CorrectAnswer { get; set; }

        /// <summary>
        /// Gets or sets the Question_Id.
        /// </summary>
        /// <value>The Question_Id.</value>
        [Display(Name = "Question_Id")]
        public int Question_Id { get; set; }

        /// <summary>
        /// Gets a value indicating whether [show add button].
        /// </summary>
        /// <value><c>true</c> if [show add button]; otherwise, <c>false</c>.</value>
        public bool ShowAddButton { get; set; }

    }
}
