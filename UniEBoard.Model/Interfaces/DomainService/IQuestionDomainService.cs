// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuestionDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for question Operations
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
    /// IQuestionDomainService interface definition - Contains Methods for Question Operations
    /// </summary>
    public interface IQuestionDomainService : IBaseDomainService<Question>
    {
        /// <summary>
        /// Gets the questions  by quiz id.
        /// </summary>
        /// <param name="quizId">The quiz id.</param>
        /// <returns></returns>
        List<Question> GetQuestionsByQuizId(int quizId);

        /// <summary>
        /// Gets the quiz questions by teacher and quiz.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <param name="quizId">The quiz id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<Question> GetQuizQuestionsByTeacherAndQuiz(int teacherId, int quizId, int view);

        /// <summary>
        /// Removes the question
        /// </summary>
        /// <param name="questionId">question id</param>
        /// <returns>true if delete otherwise returns false</returns>
        bool RemoveQuestion(int questionId);
    }
}
