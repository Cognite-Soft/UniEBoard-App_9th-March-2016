
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Question.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Question class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;
using Cognite.Utility.Helpers.Methods;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// Question class definition
    /// </summary>
    public class Question : BaseEntity
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Task"/> class.
        /// </summary>
        public Question()
            : base()
        {

        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public Quiz Quiz { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>The Name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the AllowMultipleSelections.
        /// </summary>
        /// <value>The AllowMultipleSelections.</value>
        public bool AllowMultipleSelections { get; set; }


        /// <summary>
        /// Gets or sets the HelpText.
        /// </summary>
        /// <value>The HelpText.</value>
        public string HelpText { get; set; }

        /// <summary>
        /// Gets or sets the Quiz_Id.
        /// </summary>
        /// <value>The Quiz_Id.</value>
        public int Quiz_Id { get; set; }

        /// <summary>
        /// Gets or sets the Sort Order.
        /// </summary>
        /// <value>The Sort Order.</value>
        public int SortOrder { get; set; }

        /// <summary>
        ///  Gets or sets the Explanation.
        /// </summary>
        public string Explanation { get; set; }

        /// <summary>
        /// Gets or sets the QuestionType_Id.
        /// </summary>
        /// <value>The QuestionType_Id.</value>
        public QuestionQuizType QuestionType_Id { get; set; }

        /// <summary>
        /// Gets the question type text.
        /// </summary>
        /// <value>The question type text.</value>
        public string QuestionTypeText
        {
            get
            {
                return EnumHelper.DiscriptionFor((QuestionQuizType)QuestionType_Id);
            }
        }

        /// <summary>
        /// Gets or sets the question choices.
        /// </summary>
        /// <value>The question choices.</value>
        public ICollection<QuestionChoice> QuestionChoices { get; set; }

        /// <summary>
        /// Gets the question type text.
        /// </summary>
        /// <value>The question type text.</value>
        public int TotalPoints
        {
            get
            {
                int total = 0;
                if (QuestionChoices != null)
                {
                    total = QuestionChoices.Sum(p => p.PointsValue);
                }
                return total;
            }
        }

        #endregion
    }
}
