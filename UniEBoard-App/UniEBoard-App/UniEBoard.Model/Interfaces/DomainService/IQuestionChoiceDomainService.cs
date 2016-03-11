// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuestionChoiceDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for questionChoice Operations
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
    /// IQuestionChoiceDomainService interface definition - Contains Methods for QuestionChoices Operations
    /// </summary>
    public interface IQuestionChoiceDomainService : IBaseDomainService<QuestionChoice>
    {
        /// <summary>
        /// Gets the questions choices by question id.
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <returns> List<Question></returns>
        List<QuestionChoice> GetQuestionsChoicesByQuestionId(int questionId);


        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns> List<QuestionChoices></returns>
        List<QuestionChoice> GetAll();

        /// <summary>
        /// GetAll
        /// </summary>
        ///<param name="quizId">The quiz id.</param>
        /// <returns> List of QuestionChoices</returns>
        List<QuestionChoice> GetQuestionChoicesByQuizId(int quizId);

        
        /// <summary>
        /// Get correct questions for unique choice .
        /// </summary>
        /// <returns> List<QuestionChoices></returns>
        List<QuestionChoice> GetCorrectQuestionForUnique();

        /// <summary>
        /// Get correct questions for multiple choice .
        /// </summary>
        /// <returns> List of QuestionChoices</returns>
        List<QuestionChoice> GetCorrectQuestionForMultiple();

        /// <summary>
        /// Get correct questions by questionId.
        /// </summary>
        /// <returns> List of QuestionChoices</returns>
        List<QuestionChoice> GetCorrectQuestionChoices(int questionId);

        /// <summary>
        /// Get ids of the Multiple questions for multiple choice .
        /// </summary>
        /// <returns> List<int></returns>
        List<int> GetQuestionsMultiples(int quizId);
        
    }
}
