// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuizEntryDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for QuizEntry Operations
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
    /// IQuizEntryDomainService Interface definition - Contains Methods for QuizEntry Operations
    /// </summary>
    public interface IQuizEntryDomainService : IBaseDomainService<QuizEntry>
    {
        /// <summary>
        /// Gets the QuizEntry by quizId, studenId.
        /// </summary>
        /// <param name="quizId">The quiz id.</param>
        ///  <param name="studentId">The student id.</param>
        /// <returns>  QuizEntry</returns>
        QuizEntry GetQuizEntry(int quizId, int studentId);

        /// <summary>
        /// Get the num of times the student did the quiz
        /// </summary>
        /// <param name="quizId">The quiz Id. </param>
        /// <param name="studentId">The student Id</param>
        /// <returns></returns>
        int NumAttemptsSoFar(int quizId, int studentId);
  
    }
}
