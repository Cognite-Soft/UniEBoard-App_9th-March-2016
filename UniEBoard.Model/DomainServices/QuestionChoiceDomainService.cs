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
    public class QuestionChoiceDomainService : BaseDomainService<QuestionChoice, IQuestionChoiceRepository>, IQuestionChoiceDomainService
    {
        #region Properties

        /// <summary>
        /// QuizRepository instance
        /// </summary>
        public IQuestionChoiceRepository QuestionChoiceRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Students the domain service.
        /// </summary>
        /// <param name="taskRepository">The task repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public QuestionChoiceDomainService(IQuestionChoiceRepository questionchoiceRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(questionchoiceRepository, exceptionManager, loggingService)
        {
            QuestionChoiceRepository = questionchoiceRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the questions by quiz. 
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <returns>List<QuestionChoices></returns>
         public List<QuestionChoice> GetQuestionsChoicesByQuestionId(int questionId)
        {
            List<QuestionChoice> questions = new List<QuestionChoice>();
            try
            {
                questions = QuestionChoiceRepository.GetQuestionsChoicesByQuestionId(questionId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return questions;
        }

        /// <summary>
        /// Get all teh question choices 
        /// </summary>
        /// <returns></returns>
         public List<QuestionChoice> GetAll()
         {
             List<QuestionChoice> questions = new List<QuestionChoice>();
             try
             {
                 questions = QuestionChoiceRepository.GetAll();
             }
             catch (Exception ex)
             {
                 ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
             }
             return questions;
         }

       
        
        /// <summary>
        /// Get correct questions for Unique choice
        /// </summary>
        /// <returns></returns>
         public List<QuestionChoice> GetCorrectQuestionForUnique()
         {
             List<QuestionChoice> questions = new List<QuestionChoice>();
             try
             {
                 questions = QuestionChoiceRepository.GetCorrectQuestionForUnique();
             }
             catch (Exception ex)
             {
                 ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
             }
             return questions;
         }


        /// <summary>
         /// Get correct questions for Multiple choice
        /// </summary>
        /// <returns></returns>
         public List<QuestionChoice> GetCorrectQuestionForMultiple()
         {
             List<QuestionChoice> questions = new List<QuestionChoice>();
             try
             {
                 questions = QuestionChoiceRepository.GetCorrectQuestionForMultiple();
             }
             catch (Exception ex)
             {
                 ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
             }
             return questions;
         }

        /// <summary>
        /// Get the list of QuestionId which are Multiple choice
        /// </summary>
        /// <param name="quizId">The quiz Id.</param>
         /// <returns>List<int></returns>
         public List<int> GetQuestionsMultiples(int quizId)
         {
             List<int> QuestionsId = new List<int>();
             try
             {
                 QuestionsId = QuestionChoiceRepository.GetQuestionsMultiples(quizId);

             }
             catch (Exception ex)
             {
                 ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
             }
             return QuestionsId;
         }

        /// <summary>
        /// Get Quuestion Choices by quizId
        /// </summary>
        /// <param name="quizId"></param>
        /// <returns></returns>
         public List<QuestionChoice> GetQuestionChoicesByQuizId(int quizId)
         {
             List<QuestionChoice> questions = new List<QuestionChoice>();
             try
             {
                 questions = QuestionChoiceRepository.GetQuestionChoicesByQuizId(quizId);
             }
             catch (Exception ex)
             {
                 ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
             }
             return questions;
         }



        /// <summary>
        /// Get correct question choices by questionId
        /// </summary>
        /// <param name="questionId">The question Id</param>
        /// <returns>List of QuestionChoices</returns>
        public List<QuestionChoice> GetCorrectQuestionChoices(int questionId)
         {
             List<QuestionChoice> questions = new List<QuestionChoice>();
             try
             {
                 questions = QuestionChoiceRepository.GetCorrectQuestionChoices(questionId);
             }
             catch (Exception ex)
             {
                 ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
             }
             return questions;
         }

        #endregion

    }
}
