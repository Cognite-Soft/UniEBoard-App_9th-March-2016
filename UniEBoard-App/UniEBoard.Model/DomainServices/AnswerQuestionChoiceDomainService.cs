// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnswerQuestionChoiceDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for AnswerQuestionChoice Operations
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
    /// AnswerQuestionChoiceDomainService class definition - Contains Methods for AnswerQuestionChoice Operations
    /// </summary>
    public class AnswerQuestionChoiceDomainService : BaseDomainService<AnswerQuestionChoice, IAnswerQuestionChoiceRepository>, IAnswerQuestionChoiceDomainService
    {
        #region Properties

        /// <summary>
        /// AnswerQuestionChoice instance
        /// </summary>
        public IAnswerQuestionChoiceRepository AnswerQuestionChoiceRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// AnswerQuestionChoice the domain service.
        /// </summary>
        /// <param name="taskRepository">The task repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public AnswerQuestionChoiceDomainService(IAnswerQuestionChoiceRepository answerQuestionChoiceRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(answerQuestionChoiceRepository, exceptionManager, loggingService)
        {
            AnswerQuestionChoiceRepository = answerQuestionChoiceRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the QuizEntry by student and quizId
        /// </summary>
        /// <param name="moduleId">The module id.</param>
        /// <returns>QuizEntry</returns>
        public List<AnswerQuestionChoice> GetAll()
        {
            List<AnswerQuestionChoice> answers = new List<AnswerQuestionChoice>();
            try
            {
                answers = AnswerQuestionChoiceRepository.GetAll();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return answers;
        }

        #endregion


    }
}
