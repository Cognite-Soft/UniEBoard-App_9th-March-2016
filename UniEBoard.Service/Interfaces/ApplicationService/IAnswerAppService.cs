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
    public interface IAnswerAppService : IBaseAppService
    {
        /// <summary>
        /// Gets or sets the Answer manager.
        /// </summary>
        /// <value>The Answer manager.</value>
        IAnswerDomainService AnswerManager { get; set; }

        /// <summary>
        /// Gets or sets the Answer manager.
        /// </summary>
        /// <value>The Answer manager.</value>
        IAnswerQuestionChoiceDomainService AnswerQuestionChoiceManager { get; set; }

        /// <summary>
        /// Add a Answer
        /// </summary>
        /// <param name="answerentry"> Answer entry</param>
        void AddAnswer(AnswerViewModel answerentry);


        /// <summary>
        /// Add a List of Answer
        /// </summary>
        /// <param name="answerentry"> Answer entry</param>
        string[] AddListAnswer(string[] results, AnswerViewModel answer, string questionType);



    }
}
