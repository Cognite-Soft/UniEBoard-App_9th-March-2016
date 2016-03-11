// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuestionAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for all questions related operations
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
    /// IQuestionAppService Interface - Contains Methods for all question and module related operations
    /// </summary>
    public interface IQuestionAppService : IBaseAppService
    {
        /// <summary>
        /// Gets or sets the question manager.
        /// </summary>
        /// <value>The question manager.</value>
        IQuestionDomainService QuestionManager { get; set; }

        /// <summary>
        /// Gets or sets the question choice manager.
        /// </summary>
        /// <value>The question choice manager.</value>
        IQuestionChoiceDomainService QuestionChoicesManager { get; set; }

        /// <summary>
        /// Gets all questions by quiz.
        /// </summary>
        /// <param name="quizId">The quiz id.</param>
        /// <returns></returns>
        List<QuestionViewModel> GetQuestionsByQuizId(int quizId);


        /// <summary>
        /// Gets all questions by quiz.
        /// </summary>
        /// <param name="quizId">The quiz id.</param>
        /// <returns></returns>
        bool IsCorrectQuestion(QuestionViewModel question, string[] studentanswers, string QuestionType);

        /// <summary>
        /// Get the list of correct question choices 
        /// </summary>
        /// <param name="questionId">question Id</param>
        /// <returns>list of question choices </returns>
        List<QuestionChoicesViewModel> GetCorrectQuestionChoices(int questionId);

        /// <summary>
        /// Get question By IdQuestion
        /// </summary>
        /// <param name="idquestion">The question Id. </param>
        /// <returns></returns>
        QuestionViewModel GetQuestionById(int idquestion);
        
        /// <summary>
        /// Gets the quiz questions by teacher and quiz.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <param name="quizId">The quiz id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<QuestionViewModel> GetQuizQuestionsByTeacherAndQuiz(int teacherId, int quizId, int view);

        /// <summary>
        /// Creates a Question
        /// </summary>
        /// <param name="moduleViewModel">QuestionViewModel</param>
        void CreateQuestion(QuestionViewModel questionViewModel);

        /// <summary>
        /// Edit a Question
        /// </summary>
        /// <param name="moduleViewModel">QuestionViewModel</param>
        void EditQuestion(QuestionViewModel questionViewModel);
    }
}
