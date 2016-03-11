// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnswerDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Answer Operations
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
    /// AnswerDomainService class definition - Contains Methods for Answer Operations
    /// </summary>
    public class AnswerDomainService : BaseDomainService<Answer, IAnswerRepository>, IAnswerDomainService
    {
        #region Properties

        /// <summary>
        /// AnswerRepository instance
        /// </summary>
        public IAnswerRepository AnswerRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Answer the domain service.
        /// </summary>
        /// <param name="taskRepository">The task repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public AnswerDomainService(IAnswerRepository answerRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(answerRepository, exceptionManager, loggingService)
        {
            AnswerRepository = answerRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the QuizEntry by student and quizId
        /// </summary>
        /// <param name="moduleId">The module id.</param>
        /// <returns>QuizEntry</returns>
        public List<Answer> GetAnswersByQuizEntryId(int QuizEntryId)
        {
            List<Answer> answers = new List<Answer>();
            try
            {
                answers = AnswerRepository.GetAnswerByQuizEntryId(QuizEntryId);
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
