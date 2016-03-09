// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuizAppService.cs" company="Cognite Ltd">
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
using System.Web.SessionState;

namespace UniEBoard.Service.ApplicationServices
{
    /// <summary>
    /// Quiz Application Service Class - Contains Methods for Quiz Application Service Operations
    /// </summary>
    public class QuizAppService : BaseAppService, IQuizAppService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the quiz manager.
        /// </summary>
        /// <value>The quiz manager.</value>
        public IQuizDomainService QuizManager { get; set; }

        /// <summary>
        /// Gets or sets the quizentry manager.
        /// </summary>
        /// <value>The quizentry manager.</value>
        public IQuizEntryDomainService QuizEntryManager { get; set; }


        /// <summary>
        /// Gets or sets the quiz manager.
        /// </summary>
        /// <value>The quiz manager.</value>
        public IModuleDomainService ModuleManager { get; set; }

        /// <summary>
        /// Gets or sets the module quiz manager.
        /// </summary>
        /// <value>The module quiz manager.</value>
        public IModuleQuizDomainService ModuleQuizManager { get; set; }

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
        /// Gets or sets the questionchoice manager.
        /// </summary>QuestionChoice Manager</value>
        public IQuestionChoiceDomainService QuestionChoiceManager { get; set; }

        /// <summary>
        /// Gets or sets the Questio manager.
        /// </summary>Questio Manager</value>
        public IQuestionDomainService QuestionManager { get; set; }


        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuizAppService"/> class.
        /// </summary>
        /// <param name="staffManager">The staff manager.</param>
        /// <param name="objectMapper">The object mapper.</param>
        public QuizAppService(
            IQuizDomainService quizManager,
            IModuleDomainService moduleManager,
            IModuleQuizDomainService moduleQuizManager,
            IQuizEntryDomainService quizentryManager,
            IAnswerDomainService answerManager,
            IAnswerQuestionChoiceDomainService answerQuestionChoiceManager,
            IQuestionChoiceDomainService questionChoiceManager,
            IQuestionDomainService questionManager,
            IObjectMapperAdapter objectMapper,
            ICacheAdapter cacheService,
            IExceptionManagerAdapter exceptionManager,
            ILoggingServiceAdapter loggingService)
            : base(objectMapper, cacheService, exceptionManager, loggingService)
        {
            this.QuizManager = quizManager;
            this.ModuleManager = moduleManager;
            this.QuizEntryManager = quizentryManager;
            this.AnswerManager = answerManager;
            this.AnswerQuestionChoiceManager = answerQuestionChoiceManager;
            this.QuestionChoiceManager = questionChoiceManager;
            this.QuestionManager = questionManager;
            this.ModuleQuizManager = moduleQuizManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines if the quiz is available to the student, depending of the number of attempts
        /// </summary>
        /// <param name="quizId"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public bool QuizAvailableToStudent(int quizId, int studentId)
        {
            QuizzesViewModel quiz = new QuizzesViewModel();
            quiz = ObjectMapper.Map<Model.Entities.Quiz, QuizzesViewModel>(QuizManager.FindBy(quizId));

            return (quiz.MaxAttemptsAllowed < QuizEntryManager.NumAttemptsSoFar(quizId, studentId));
        }

        public QuizzesViewModel GetQuizById(int quizId)
        {
            QuizzesViewModel quiz = new QuizzesViewModel();
            quiz = ObjectMapper.Map<Model.Entities.Quiz, QuizzesViewModel>(QuizManager.FindBy(quizId));

            return quiz;
        }

        /// <summary>
        /// Gets all the staff.
        /// </summary>
        /// <returns></returns>
        public List<QuizzesViewModel> GetQuizByCourse(int courseId, int studentId)
        {

            List<QuizzesViewModel> models = new List<QuizzesViewModel>();
            try
            {
                //Get modules by course
                List<Module> module = ModuleManager.GetModulesByCourse(courseId);
                foreach (var item in module)
                {

                    List<Quiz> quizzes = QuizManager.GetQuizzesByModule(item.Id);
                    if (quizzes.Count != 0)//If we have quizzes for the module
                    {
                        foreach (var item2 in quizzes)
                        {
                            QuizzesViewModel viewmodel = new QuizzesViewModel();
                            viewmodel = ObjectMapper.Map<Model.Entities.Quiz, QuizzesViewModel>(item2);
                            viewmodel.AttemptsSoFar = QuizEntryManager.NumAttemptsSoFar(item2.Id, studentId);
                            //set Up module and course2.
                            viewmodel.ModuleId = item.Id;
                            viewmodel.ModuleTitle = item.Title;
                            viewmodel.CourseId = item.Course_Id;
                            models.Add(viewmodel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Add a new quiz entry for a new Quizz and student
        /// </summary>
        /// <param name="quizentry">QuizEntryViewModel object </param>
        public int AddQuizEntry(QuizEntryViewModel quizentry)
        {
            try
            {
                QuizEntry _quizEntryEntity = ObjectMapper.Map<QuizEntryViewModel, Model.Entities.QuizEntry>(quizentry);

                _quizEntryEntity.Quiz_Id = quizentry.Quiz_Id;
                _quizEntryEntity.Student_Id = quizentry.Student_Id;
                QuizEntry NewQuizEntry = QuizEntryManager.Add(_quizEntryEntity);
                return NewQuizEntry.Id;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
                return 0;
            }
        }

        /// <summary>
        /// Get Results of the quiz
        /// </summary>
        /// <param name="idquiz"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public ResultQuizzModel GetResult(int quizEntryID, int quizId)
        {
            ResultQuizzModel results = new ResultQuizzModel();
            try
            {
                //Quiz
                Quiz quiz = QuizManager.GetQuizById(quizId);

                //Build the model result
                results.Results = GetResultsForUniqueQuestions(quizId, quizEntryID) + GetResultsForMultipleQuestions(quizId, quizEntryID);
                results.PointValueTotal = GetMaxPointOfQuiz(quizId);
                results.Percent = ((results.Results * 100) / (results.PointValueTotal));
                results.QuestionIncorrect = results.PointValueTotal - results.Results;
                // results.MaxScoreSuccess = quiz.MaxScoreSuccess.HasValue ? quiz.MaxScoreSuccess.Value : 0;

                //Pass of Fail??? if the result > MaxScoreSucess = Pass if not Fail
                if (results.Results > results.PointValueTotal / 2)//PASS
                {
                    results.ResultMessage = "Success";
                }
                else//Fail
                {
                    results.ResultMessage = "Fail";
                }
                results.QuizId = quizId;
                return results;

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }

            return results;
        }

        /// <summary>
        /// Update the quizEntry
        /// </summary>
        /// <param name="quizentry">The quizEntryId.</param>
        public void updateQuizEntry(QuizEntryViewModel quizentry)
        {
            try
            {
                QuizEntry _quizEntryEntity = ObjectMapper.Map<QuizEntryViewModel, Model.Entities.QuizEntry>(quizentry);

                _quizEntryEntity.QuizResult = quizentry.QuizResult;
                QuizEntryManager.Update(_quizEntryEntity);

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);

            }
        }

        /// <summary>
        /// Get the quizEntry
        /// </summary>
        /// <param name="quizId">The quizId.</param>
        public List<QuizEntryViewModel> GetQuizEntry(int quizId)
        {
            List<QuizEntryViewModel> models = new List<QuizEntryViewModel>();
            try
            {
                List<QuizEntry>  _quizEntry = QuizEntryManager.FindAll().Where(x => x.Quiz_Id == quizId).ToList();
                models = (ObjectMapper.Map<Model.Entities.QuizEntry, QuizEntryViewModel>(_quizEntry)).ToList();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }
        /// <summary>
        /// Get the quizModule
        /// </summary>
        /// <param name="quizId">The quizId.</param>
        public List<ModuleQuizViewModel> GetModuleQuizs(int quizId)
        {
            List<ModuleQuizViewModel> models = new List<ModuleQuizViewModel>();
            try
            {
                List<ModuleQuiz>  _quizModule = ModuleQuizManager.FindAll().Where(x => x.QuizId == quizId).ToList();
                models = (ObjectMapper.Map<Model.Entities.ModuleQuiz, ModuleQuizViewModel>(_quizModule)).ToList();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets all quiz for teacher courses.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<QuizzesViewModel> GetAllQuizzesForTeacherCourses(int teacherId, int view)
        {
            List<QuizzesViewModel> models = new List<QuizzesViewModel>();
            try
            {
                List<Quiz> quizzes = QuizManager.GetAllQuizzesForTeacherCourses(teacherId, view);
                models = QuizViewModelFactory.CreateFromDomainModel(quizzes, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets all quiz for teacher courses.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<QuizzesViewModel> GetAllQuizzesForTeacherCourses(int teacherId, string filter)
        {
            List<QuizzesViewModel> models = new List<QuizzesViewModel>();
            try
            {
                List<Quiz> quizzes = QuizManager.GetAllQuizzesForTeacherCourses(teacherId, filter);
                models = QuizViewModelFactory.CreateFromDomainModel(quizzes, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets all quiz for teacher courses.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<QuizzesViewModel> GetAllQuizzes()
        {
            List<QuizzesViewModel> models = new List<QuizzesViewModel>();
            try
            {
                List<Quiz> quizzes = QuizManager.FindAll();
                models = QuizViewModelFactory.CreateFromDomainModel(quizzes, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Creates the quiz.
        /// </summary>
        /// <param name="createQuizViewModel">The create quiz view model.</param>
        public void CreateQuiz(QuizzesViewModel createQuizViewModel)
        {
            try
            {
                if (createQuizViewModel != null)
                {
                    Quiz quiz = ObjectMapper.Map<QuizzesViewModel, Model.Entities.Quiz>(createQuizViewModel);
                    quiz = QuizManager.Add(quiz);
                    if (quiz != null && quiz.Id != 0)
                    {
                        ModuleQuizManager.Add(new ModuleQuiz(quiz.Id, createQuizViewModel.ModuleId));
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get the point results for Unique questions in a quizEntry
        /// </summary>
        /// <param name="quizId">The quiz Id</param>
        /// <param name="quizEntryID">Teh Quiz Entry ID</param>
        /// <returns>Points Result for unique questions in a quizEntry</returns>
        private int GetResultsForUniqueQuestions(int quizId, int quizEntryID)
        {
            int result = 0;
            try
            {

                //AnswerQuestionChoices
                List<AnswerQuestionChoice> answerquestionList = AnswerQuestionChoiceManager.GetAll();

                //answer 
                List<Answer> answerList = AnswerManager.GetAnswersByQuizEntryId(quizEntryID);

                //Questionchoices for unique answer
                List<QuestionChoice> questionschoicesUniqueList = QuestionChoiceManager.GetCorrectQuestionForUnique();

                //Question
                List<Question> questionlist = QuestionManager.GetQuestionsByQuizId(quizId);

                //Get the Results for UNIQUE CHOICE QUESTION
                result =
                 (from Aq in answerquestionList
                  join a in answerList on Aq.AnswerId equals a.Id
                  join qc in questionschoicesUniqueList on Aq.QuestionChoiceId equals qc.Id
                  join q in questionlist on a.Question_Id equals q.Id
                  select qc).Sum(x => x.PointsValue);

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return result;
        }

        /// <summary>
        /// Get the point results for Multiple questions in a quizEntry
        /// </summary>
        /// <param name="quizId">The quiz Id</param>
        /// <param name="quizEntryID">Teh Quiz Entry ID</param>
        /// <returns>Points Result for Multiple questions in a quizEntry</returns>
        private int GetResultsForMultipleQuestions(int quizId, int quizEntryID)
        {
            int result = 0;
            try
            {

                //Get the ids of the multiple answer
                List<int> QuestionIdsMultiple = QuestionChoiceManager.GetQuestionsMultiples(quizId);

                //AnswerQuestionChoices
                List<AnswerQuestionChoice> answerquestionList = AnswerQuestionChoiceManager.GetAll();

                //answer 
                List<Answer> answerList = AnswerManager.GetAnswersByQuizEntryId(quizEntryID);


                //Question
                List<Question> questionlist = QuestionManager.GetQuestionsByQuizId(quizId);

                //Questionchoices 
                List<QuestionChoice> questionschoicesList = QuestionChoiceManager.GetAll();

                //Questionchoices for multiple answer
                List<QuestionChoice> questionschoicesMultipleList = QuestionChoiceManager.GetCorrectQuestionForMultiple();

                int multipleresult = 0;

                //Get the Results for MULTIPLE CHOICE QUESTION
                foreach (var item in QuestionIdsMultiple)
                {
                    //Get the answer for the student for each multiple question
                    List<string> studentchoices =
                       (from Aq in answerquestionList
                        join a in answerList on Aq.AnswerId equals a.Id
                        join qc in questionschoicesList on Aq.QuestionChoiceId equals qc.Id
                        join q in questionlist on a.Question_Id equals q.Id
                        where qc.Question_Id == item
                        select qc.Id.ToString()).ToList();

                    //Get the correct Answer

                    List<string> correctanswer =
                      (from qc in questionschoicesMultipleList
                       where qc.Question_Id == item
                       select qc.Id.ToString()).ToList();

                    if (Extensions.AreEqual(studentchoices, correctanswer)) //Correct Answer
                    {
                        multipleresult += (from qc in questionschoicesMultipleList
                                           where qc.Question_Id == item
                                           select qc).Sum(x => x.PointsValue);
                    }

                    result = multipleresult;

                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return result;
        }

        /// <summary>
        /// Get the Maximun points possible for a quiz
        /// </summary>
        /// <param name="quizId">The quiz Id</param>
        /// <param name="quizEntryID">Teh Quiz Entry ID</param>
        /// <returns>int: Max points in a quiz</returns>
        private int GetMaxPointOfQuiz(int quizId)
        {
            int result = 0;
            try
            {
                //Questionchoices 
                List<QuestionChoice> questionschoicesList = QuestionChoiceManager.GetAll();

                //Question
                List<Question> questionlist = QuestionManager.GetQuestionsByQuizId(quizId);

                //Get the MaxPoint of the quizz
                result =
                      (from qc in questionschoicesList
                       join q in questionlist on qc.Question_Id equals q.Id
                       select qc).Sum(x => x.PointsValue);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return result;
        }

        #endregion

    }
}
