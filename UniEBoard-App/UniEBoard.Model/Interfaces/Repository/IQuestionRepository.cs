// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuestionRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for questions Repository CRUD operations.
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
    /// The Question Repository Interface
    /// </summary>
    public interface IQuestionRepository : IBaseRepository<Question>
    {

        /// <summary>
        /// Gets the questions by quiz id.
        /// </summary>
        /// <param name="quizId">The quiz id.</param>
        /// <returns></returns>
        List<Question> GetQuestionsByQuizId(int quizId);

        /// <summary>
        /// Finds the quiz questions by teacher and quiz.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <param name="quizId">The quiz id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<Question> FindQuizQuestionsByTeacherAndQuiz(int teacherId, int quizId, int view);

        /// <summary>
        /// Removes the question
        /// </summary>
        /// <param name="questionId">question id</param>
        /// <returns>true if delete otherwise returns false</returns>
        void RemoveQuestion(int questionId);
    }
}
