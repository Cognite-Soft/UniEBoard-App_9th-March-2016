// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuizAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for all quizzes related operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Service.Models;
using UniEBoard.Service.Models.Courses;
using UniEBoard.Service.Models.Quizzes;

namespace UniEBoard.Service.Interfaces.ApplicationService
{
    /// <summary>
    /// IQuizAppService Interface - Contains Methods for all quiz and module related operations
    /// </summary>
    public interface IQuizAppService : IBaseAppService
    {
        IQuizDomainService QuizManager { get; set; }
        IQuizEntryDomainService QuizEntryManager { get; set; }
        IModuleQuizDomainService ModuleQuizManager { get; set; }

        /// <summary>
        /// Gets all quiz modules by course.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        List<QuizzesViewModel> GetQuizByCourse(int courseId, int studentId);

        /// <summary>
        /// Add a quizEntry
        /// </summary>
        /// <param name="quizentry">The quizEntry Id. </param>
        ///   <returns> new id</returns>
        int AddQuizEntry(QuizEntryViewModel quizentry);

        /// <summary>
        /// Update the quiz entry, normally add the quizresult of the quiz
        /// </summary>
        /// <param name="quizentry">The quizEntry Id. </param>
        void updateQuizEntry(QuizEntryViewModel quizentry);

        /// <summary>
        /// Build ResultsQuizModel for a quizEntryI and QuizId
        /// </summary>
        /// <param name="quizEntryID">The quiz entry Id.</param>
        /// <param name="quizId">The Quiz Id</param>
        /// <returns>ResultQuizzModel</returns>
        ResultQuizzModel GetResult(int quizEntryID, int quizId);

        /// <summary>
        /// Gets all quiz for teacher courses.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<QuizzesViewModel> GetAllQuizzesForTeacherCourses(int teacherId, int view);

        /// <summary>
        /// Gets all quiz for teacher courses.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<QuizzesViewModel> GetAllQuizzesForTeacherCourses(int teacherId, string filter);

        /// <summary>
        /// Gets all quizes.
        /// </summary>
        /// <returns></returns>
        List<QuizzesViewModel> GetAllQuizzes();

        QuizzesViewModel GetQuizById(int quizId);

        /// <summary>
        /// Creates the quiz.
        /// </summary>
        /// <param name="createQuizViewModel">The create quiz view model.</param>
        void CreateQuiz(QuizzesViewModel createQuizViewModel);

        /// <summary>
        /// Determines if the quiz is available to the student, depending of the number of attempts
        /// </summary>
        /// <param name="quizId"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        bool QuizAvailableToStudent(int quizId, int studentId);

         /// <summary>
        /// Get the quizEntry
        /// </summary>
        /// <param name="quizId">The quizId.</param>
        List<QuizEntryViewModel> GetQuizEntry(int quizId);

        /// <summary>
        /// Get the quizModule
        /// </summary>
        /// <param name="quizId">The quizId.</param>
        List<ModuleQuizViewModel> GetModuleQuizs(int quizId);

    }
}
