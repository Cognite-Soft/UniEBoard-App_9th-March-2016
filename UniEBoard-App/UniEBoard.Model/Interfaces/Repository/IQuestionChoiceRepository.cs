// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuestionChoiceRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for QuestionChoices Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;

namespace UniEBoard.Model.Interfaces.Repository
{
    /// <summary>
    /// The QuestionChoices Repository Interface
    /// </summary>
    public interface IQuestionChoiceRepository : IBaseRepository<QuestionChoice>
    {
        /// <summary>
        /// Gets the questions choices by question id.
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <returns> List of Question</returns>
        List<QuestionChoice> GetQuestionsChoicesByQuestionId(int questionId);

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns> List of Questions</returns>
        List<QuestionChoice> GetAll();

         /// <summary>
        /// Get questionsChoices By quizId
        /// </summary>
        /// <param name="quizId">The quiz id.</param>
        /// <returns> List of QuestionChoices</returns>
        List<QuestionChoice> GetQuestionChoicesByQuizId(int quizId);


        /// <summary>
        /// Get all questions correct for Unique choice
        /// </summary>
        /// <returns> List of Question</returns>
        List<QuestionChoice> GetCorrectQuestionForUnique();

        /// <summary>
        /// Get all questions correct for Multiple choice
        /// </summary>
        /// <returns> List of Question</returns>
        List<QuestionChoice> GetCorrectQuestionForMultiple();

        /// <summary>
        /// Get the list of questionsId for Multiple questions
        /// </summary>
        /// <param name="quizId">The quiz id.</param>
        /// <returns> List of int</returns>
        List<int> GetQuestionsMultiples(int quizId);

        /// <summary>
        /// Get list of question choices by questionId
        /// </summary>
        /// <param name="questionId">The question Id.</param>
        /// <returns>List of question choices</returns>
        List<QuestionChoice> GetCorrectQuestionChoices(int questionId);
    
    }
}
