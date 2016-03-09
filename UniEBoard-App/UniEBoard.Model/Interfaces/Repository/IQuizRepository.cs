// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuizRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for Quiz Repository CRUD operations.
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
    /// The Quiz Repository Interface
    /// </summary>
    public interface IQuizRepository : IBaseRepository<Quiz>
    {
        /// <summary>
        /// Finds the quizzes in a module.
        /// </summary>
        /// <param name="moduleId">The module id.</param>
        /// <returns> List<Model.Entities.Quiz></returns>
        List<Model.Entities.Quiz> FindQuizzesByModule(int moduleId);

        /// <summary>
        /// Finds the quizzes for teacher courses.
        /// </summary>
        /// <param name="?">The ?.</param>
        /// <param name="?">The ?.</param>
        /// <returns></returns>
        List<Model.Entities.Quiz> FindQuizzesForTeacherCourses(int teacherId, int view);

        /// <summary>
        /// Finds the quizzes for teacher courses.
        /// </summary>
        /// <param name="?">The ?.</param>
        /// <param name="?">The ?.</param>
        /// <returns></returns>
        List<Model.Entities.Quiz> FindQuizzesForTeacherCourses(int teacherId, string filter);
    }
}
