// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAnswerQuestionChoiceDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for AnswerQuestionChoice Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;

namespace UniEBoard.Model.Interfaces.DomainService
{
    /// <summary>
    /// IAnswerQuestionChoiceDomainService Interface definition - Contains Methods for AnswerQuestionChoice Operations
    /// </summary>
    public interface IAnswerQuestionChoiceDomainService : IBaseDomainService<AnswerQuestionChoice>
    {
        /// <summary>
        /// Get answer by quizId
        /// </summary>
        /// <param name="quizId">the quiz Id.</param>
        /// <returns>list of Answer</returns>
        List<AnswerQuestionChoice> GetAll();
  
    }
}
