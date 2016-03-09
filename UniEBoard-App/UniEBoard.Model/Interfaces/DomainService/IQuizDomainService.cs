// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuizDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Quiz Operations
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
    /// IQuizDomainService Interface definition - Contains Methods for Quiz Operations
    /// </summary>
    public interface IQuizDomainService : IBaseDomainService<Quiz>
    {
        /// <summary>
        /// Gets the Quiz by moduleId.
        /// </summary>
        /// <param name="moduleId">The module id.</param>
        /// <returns>  List<Quiz></returns>
        List<Quiz> GetQuizzesByModule(int moduleId);

        /// <summary>
        /// Get Quiz by Id
        /// </summary>
        /// <param name="quizId"> quiz Id </param>
        /// <returns>Quiz </returns>
        Quiz GetQuizById(int quizId);

        /// <summary>
        /// Gets all quizzes for teacher courses.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<Quiz> GetAllQuizzesForTeacherCourses(int teacherId, int view);

        /// <summary>
        /// Gets all quizzes for teacher courses.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<Quiz> GetAllQuizzesForTeacherCourses(int teacherId, string filter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quizId"></param>
        /// <returns></returns>
        //Quiz CalculateGradeForQuiz(int quizId);
    }
}
