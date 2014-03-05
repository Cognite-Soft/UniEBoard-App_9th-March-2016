// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuizDomainService.cs" company="Cognite Ltd">
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
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Factories;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Model.Interfaces.Repository;

namespace UniEBoard.Model.DomainServices
{
    /// <summary>
    /// QuizDomainService class definition - Contains Methods for Quiz Operations
    /// </summary>
    public class QuizDomainService : BaseDomainService<Quiz, IQuizRepository>, IQuizDomainService
    {
        #region Properties

        /// <summary>
        /// QuizRepository instance
        /// </summary>
        public IQuizRepository QuizRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Students the domain service.
        /// </summary>
        /// <param name="taskRepository">The task repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public QuizDomainService(IQuizRepository quizRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(quizRepository, exceptionManager, loggingService)
        {
            QuizRepository = quizRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the quizes with upcoming deadlines.
        /// </summary>
        /// <param name="moduleId">The module id.</param>
        /// <returns></returns>
        public List<Quiz> GetQuizzesByModule(int moduleId)
        {
            List<Quiz> quizzes = new List<Quiz>();
            try
            {
                quizzes = QuizRepository.FindQuizzesByModule(moduleId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return quizzes;
        }


        /// <summary>
        /// Get the quiz by Id
        /// </summary>
        /// <param name="quizId"></param>
        /// <returns></returns>
        public Quiz GetQuizById(int quizId)
        {
            Quiz quizz = new Quiz();
            try
            {
                quizz = QuizRepository.FindBy(quizId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return quizz;

        }

        /// <summary>
        /// Gets all quizzes for teacher courses.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<Quiz> GetAllQuizzesForTeacherCourses(int teacherId, int view)
        {
            List<Quiz> quizzes = new List<Quiz>();
            try
            {
                quizzes = QuizRepository.FindQuizzesForTeacherCourses(teacherId, view);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return quizzes;
        }

        /// <summary>
        /// Gets all quizzes for teacher courses.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<Quiz> GetAllQuizzesForTeacherCourses(int teacherId, string filter)
        {
            List<Quiz> quizzes = new List<Quiz>();
            try
            {
                quizzes = QuizRepository.FindQuizzesForTeacherCourses(teacherId, filter);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return quizzes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quizId"></param>
        /// <returns></returns>
        /// 
        /*
        public Quiz CalculateGradeForQuiz(int quizId)
        {
            Quiz quiz = new Quiz();
            quiz = QuizRepository.FindAll(new List<String>() { "Questions", "Questions.QuestionChoices" }).Where(q => q.Id.Equals(quizId)).FirstOrDefault();
            quiz.Score = quiz.Questions.Sum(p => p.TotalPoints);        
            
            return quiz;
        }
        */

        #endregion
     
    }
}
