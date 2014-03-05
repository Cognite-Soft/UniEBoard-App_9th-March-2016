// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnswerAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Answer Application Service Operations
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

namespace UniEBoard.Service.ApplicationServices
{
    /// <summary>
    /// Quiz AnswerAppService Service Class - Contains Methods for Answer and AnswerQuestionsChoices Application Service Operations
    /// </summary>
    public class AnswerAppService : BaseAppService, IAnswerAppService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the answer manager.
        /// </summary>answer manager.</value>
        public IAnswerDomainService AnswerManager { get; set; }

        /// <summary>
        /// Gets or sets the answerquestionChoice manager.
        /// </summary>
        /// <value>The answerquestionChoice manager.</value>
        public IAnswerQuestionChoiceDomainService AnswerQuestionChoiceManager { get; set; }


        /// <summary>
        /// Gets or sets the Question manager.
        /// </summary>
        /// <value>The Question manager.</value>
        public IQuestionChoiceDomainService QuestionChoiceManager { get; set; }



        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuizAppService"/> class.
        /// </summary>
        /// <param name="staffManager">The staff manager.</param>
        /// <param name="objectMapper">The object mapper.</param>
        public AnswerAppService(
            IAnswerDomainService answerManager,
            IAnswerQuestionChoiceDomainService answerQuestionChoiceManager,
             IQuestionChoiceDomainService questionchoiceManager,
            IObjectMapperAdapter objectMapper,
            ICacheAdapter cacheService,
            IExceptionManagerAdapter exceptionManager,
            ILoggingServiceAdapter loggingService)
            : base(objectMapper, cacheService, exceptionManager, loggingService)
        {
            this.AnswerManager = answerManager;
            this.AnswerQuestionChoiceManager = answerQuestionChoiceManager;
            this.QuestionChoiceManager = questionchoiceManager;


        }

        #endregion

        #region Methods

        /// <summary>
        /// Add Answer.
        /// </summary>
        /// <returns></returns>
        public void AddAnswer(AnswerViewModel answerentry)
        {
            try
            {
                Answer _answer = ObjectMapper.Map<AnswerViewModel, Model.Entities.Answer>(answerentry);
                //Add Answer
                _answer.Question_Id = answerentry.Question_Id;
                _answer.QuizEntryId = answerentry.QuizEntryId;
                Answer newanswer = AnswerManager.Add(_answer);
                int answerId = newanswer.Id;

                //add Answer Questions Choices
                if (answerentry.Answers.Count() > 0)
                {
                    foreach (var item in answerentry.Answers)
                    {
                        AnswerQuestionChoice _answerquestion = ObjectMapper.Map<AnswerQuestionChoiceViewModel, Model.Entities.AnswerQuestionChoice>(item);
                        _answerquestion.AnswerId = answerId;
                        _answerquestion.QuestionChoiceId = item.QuestionChoiceId;
                        AnswerQuestionChoiceManager.Add(_answerquestion);

                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        /// <summary>
        /// Add list of answers Id
        /// </summary>
        /// <param name="idAnswer"></param>
        public string[] AddListAnswer(string[] results, AnswerViewModel answer, string questionType)
        {
            try
            {
                if (questionType == "choice")
                {
                    //build the list of answer choices for the student
                    if (results.Length > 0)
                        for (int i = 0; i < results.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(results[i]))
                            {
                                AnswerQuestionChoiceViewModel answerchoice = new AnswerQuestionChoiceViewModel();
                                answerchoice.QuestionChoiceId = Convert.ToInt32(results[i]);
                                answer.Answers.Add(answerchoice);
                            }
                        }
                }
                else //Free Text 
                {
                    if (results.Length > 0)
                    {
                        List<QuestionChoice> questionchoices = QuestionChoiceManager.GetQuestionsChoicesByQuestionId(answer.Question_Id);
                        foreach (var item in questionchoices)
                        {
                            if (item.Name.Trim().ToUpper() == results[0].Trim().ToUpper())
                            {
                                AnswerQuestionChoiceViewModel answerchoice = new AnswerQuestionChoiceViewModel();
                                answerchoice.QuestionChoiceId = Convert.ToInt32(item.Id);
                                answer.Answers.Add(answerchoice);
                                results[0] = item.Id.ToString();
                            }

                        }
                    }
                }

                //Add the answer
                AddAnswer(answer);

                return results;

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
                return results;
            }
        }


        #endregion

    }
}
