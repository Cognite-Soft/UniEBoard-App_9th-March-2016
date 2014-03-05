// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuizEntryRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for QuizEntry Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;

namespace UniEBoard.Model.Interfaces.Repository
{
    /// <summary>
    /// The QuizEntry Repository Interface
    /// </summary>
    public interface IQuizEntryRepository : IBaseRepository<QuizEntry>
    {
        /// <summary>
        /// Finds the QuizEntry by student and quiz.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="quizId">The quiz id.</param>
        /// <returns> QuizEntry<Model.Entities.Quiz></returns>
        QuizEntry GetQuizEntryByStudentAndQuiz(int quizId, int studentId);

        /// <summary>
        /// Get the num of times the student did the quiz
        /// </summary>
        /// <param name="quizId">The quiz Id. </param>
        /// <param name="studentId">The student Id</param>
        /// <returns></returns>
        int NumAttemptsSoFar(int quizId, int studentId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StudentId"></param>
        /// <returns></returns>
        List<Model.Entities.QuizEntry> GetQuizEntriesForStudent(int studentId, int courseId);
    }
}
