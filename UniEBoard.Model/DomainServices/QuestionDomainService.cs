// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestionDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for question Operations
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
    /// QuestionDomainService class definition - Contains Methods for question Operations
    /// </summary>
    public class QuestionDomainService : BaseDomainService<Question, IQuestionRepository>, IQuestionDomainService
    {
        #region Properties

        /// <summary>
        /// QuizRepository instance
        /// </summary>
        public IQuestionRepository QuestionRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Students the domain service.
        /// </summary>
        /// <param name="taskRepository">The task repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public QuestionDomainService(IQuestionRepository questionRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(questionRepository, exceptionManager, loggingService)
        {
            QuestionRepository = questionRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets teh questions by quiz. 
        /// </summary>
        /// <param name="quizId">The quiz id.</param>
        /// <returns>List<Question></returns>
        public List<Question> GetQuestionsByQuizId(int quizId)
        {
            List<Question> questions= new List<Question>();
            try
            {
                questions = QuestionRepository.GetQuestionsByQuizId(quizId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return questions;
        }


        /// <summary>
        /// Gets the quiz questions by teacher and quiz.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <param name="quizId">The quiz id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<Question> GetQuizQuestionsByTeacherAndQuiz(int teacherId, int quizId, int view)
        {
            List<Question> questions = new List<Question>();
            try
            {
                questions = QuestionRepository.FindQuizQuestionsByTeacherAndQuiz(teacherId, quizId, view);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return questions;
        }

        
        /// <summary>
        /// Gets the question for the Id and its Question Choices.
        /// </summary>
        /// <param name="entityId">The question id.</param>
        /// <returns></returns>
        public Question FindBy(int entityId)
        {
            Question question = new Question();
            try
            {
                question = QuestionRepository.FindBy(entityId, new List<string> { "QuestionChoices" });
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return question;
        }

        /// <summary>
        /// Removes the question
        /// </summary>
        /// <param name="questionId">question id</param>
        /// <returns>true if delete otherwise returns false</returns>
        public bool RemoveQuestion(int questionId)
        {
            try
            {
                QuestionRepository.RemoveQuestion(questionId);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return false;
        }

        #endregion
  
    }
}
