// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestionAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Quiz Application Service Operations
//  Transforms entity domain models to view models
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Service.Interfaces.ApplicationService;
using UniEBoard.Service.Models;
using UniEBoard.Service.Factories;
using UniEBoard.Model.Adapters.Logging;
using UniEBoard.Service.Models.Courses;
using UniEBoard.Service.Models.Quizzes;
using Cognite.Utility.MethodExtensions.Linq;

namespace UniEBoard.Service.ApplicationServices
{
    /// <summary>
    /// Quiz Application Service Class - Contains Methods for Quiz Application Service Operations
    /// </summary>
    public class QuestionAppService : BaseAppService, IQuestionAppService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the question manager.
        /// </summary>
        /// <value>The question manager.</value>
        public IQuestionDomainService QuestionManager { get; set; }

        /// <summary>
        /// Gets or sets the questionchoices manager.
        /// </summary>
        /// <value>The questionchoices manager.</value>
        public IQuestionChoiceDomainService QuestionChoicesManager { get; set; }


        /// <summary>
        /// Gets or sets the quiz manager.
        /// </summary>
        /// <value>The quiz manager.</value>
        public IModuleDomainService ModuleManager { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionAppService"/> class.
        /// </summary>
        /// <param name="questionManager">The staff manager.</param>
        ///  <param name="moduleManager">The module manager.</param>
        /// <param name="questionChoicesManager">The questionchoices mapper.</param>
        ///  <param name="objectMapper">The object mapper.</param>
        ///   <param name="cacheService">The cache servide.</param>
        ///   <param name="exceptionManager">The exception manager.</param>
        ///   <param name="loggingService">The loggin manager.</param>
        public QuestionAppService(
            IQuestionDomainService questionManager,
            IModuleDomainService moduleManager,
            IQuestionChoiceDomainService questionChoicesManager,
            IObjectMapperAdapter objectMapper,
            ICacheAdapter cacheService,
            IExceptionManagerAdapter exceptionManager,
            ILoggingServiceAdapter loggingService)
            : base(objectMapper, cacheService, exceptionManager, loggingService)
        {
            this.QuestionManager = questionManager;
            this.ModuleManager = moduleManager;
            this.QuestionChoicesManager = questionChoicesManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get List of Questions bye Quiz
        /// </summary>
        /// <param name="quizId">The quiz Id.</param>
        /// <returns>List<QuestionViewModel></returns>
        public List<QuestionViewModel> GetQuestionsByQuizId(int quizId)
        {
            List<QuestionViewModel> questionViewModelList = new List<QuestionViewModel>();
            int count = 0;
            try
            {
                List<Question> questionList = QuestionManager.GetQuestionsByQuizId(quizId);
                questionViewModelList = ObjectMapper.Map<Model.Entities.Question, QuestionViewModel>(questionList);
                
                foreach (var item in questionViewModelList)
                {                    
                    item.questionPosition = count;
                    item.numquestions = questionList.Count();
                    item.QuestionNumber = count + 1;

                    foreach (var questionChoice in item.QuestionChoices)
                    {
                        if (questionChoice.CorrectAnswer)
                            item.QuestionMessageSolution = item.QuestionMessageSolution + " - " + questionChoice.Name;
                    }                    
                    count++;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return questionViewModelList;
        }

        /// <summary>
        /// Check if a question is correct or not
        /// </summary>
        /// <param name="question">QuestionViewModel of the question </param>
        /// <param name="studentanswers">The student solution for the question </param>
        /// <returns>true if is correct false if not</returns>
        public bool IsCorrectQuestion(QuestionViewModel question, string[] studentanswers, string QuestionType)
        {
            bool result = false;
            try
            {
                List<string> correctQuestion = (from qc in question.QuestionChoices.Where(x => x.CorrectAnswer == true)
                                                select qc.Id.ToString()).ToList();

                List<string> StudentSolution = studentanswers.ToList();


                if (Extensions.AreEqual(correctQuestion, StudentSolution)) //Correct Answer
                    result = true;

                else result = false;
            }
            catch (Exception ex)
            {

                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }

            return result;


        }

        /// <summary>
        /// Get the list of the correct questionChoices by question Id
        /// </summary>
        /// <param name="questionId">The question Id</param>
        /// <returns>list of questionChoicesViewModel</returns>
        public List<QuestionChoicesViewModel> GetCorrectQuestionChoices(int questionId)
        {

            List<QuestionChoicesViewModel> models = new List<QuestionChoicesViewModel>();
            try
            {
                //Get questions by course
                List<QuestionChoice> questionschoices = QuestionChoicesManager.GetCorrectQuestionChoices(questionId);
                models = ObjectMapper.Map<Model.Entities.QuestionChoice, QuestionChoicesViewModel>(questionschoices);

                return models;

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }


        /// <summary>
        /// Gets the quiz questions by teacher and quiz.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <param name="quizId">The quiz id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<QuestionViewModel> GetQuizQuestionsByTeacherAndQuiz(int teacherId, int quizId, int view)
        {

            List<QuestionViewModel> models = new List<QuestionViewModel>();
            try
            {
                //Get questions
                List<Question> questions = QuestionManager.GetQuizQuestionsByTeacherAndQuiz(teacherId, quizId, view);
                models = ObjectMapper.Map<Model.Entities.Question, QuestionViewModel>(questions);

                return models;

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Get question By Id question
        /// </summary>
        /// <param name="idquestion">The question Id</param>
        /// <returns></returns>
        public QuestionViewModel GetQuestionById(int idquestion)
        {
            QuestionViewModel models = new QuestionViewModel();
            try
            {

                Question question = QuestionManager.FindBy(idquestion);
                models = ObjectMapper.Map<Model.Entities.Question, QuestionViewModel>(question);

                return models;

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Creates a question for a quiz
        /// </summary>
        /// <param name="questionViewModel">The question created</param>
        public void CreateQuestion(QuestionViewModel questionViewModel)
        {
            try
            {
                if (questionViewModel != null)
                {
                    Question question = ObjectMapper.Map<QuestionViewModel, Model.Entities.Question>(questionViewModel);
                    question = QuestionManager.Add(question);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        /// <summary>
        /// Edits an existing question
        /// </summary>
        /// <param name="questionViewModel">The edited question</param>
        public void EditQuestion(QuestionViewModel questionViewModel)
        {
            try
            {
                if (questionViewModel != null)
                {
                    Question question = ObjectMapper.Map<QuestionViewModel, Model.Entities.Question>(questionViewModel);
                    QuestionManager.Update(question);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        #endregion

    }
}
