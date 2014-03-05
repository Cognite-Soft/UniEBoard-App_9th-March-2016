// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnswerQuestionChoice.cs" company="Cognite Ltd">
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

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// AnswerQuestionChoice class definition
    /// </summary>
    public class AnswerQuestionChoice : BaseEntity
    {


        #region Properties


        /// <summary>
        /// Gets or sets the QuestionChoiceId.
        /// </summary>
        /// <value>The QuestionChoiceId.</value>
        public int QuestionChoiceId { get; set; }

        /// <summary>
        /// Gets or sets the AnswerId.
        /// </summary>
        /// <value>The AnswerId.</value>
        public int AnswerId { get; set; }

        
        #endregion
    }
}
