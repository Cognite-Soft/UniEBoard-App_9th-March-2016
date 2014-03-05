// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuizEntryDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for QuizEntry Operations
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
    /// QuizEntryDomainService class definition - Contains Methods for QuizEntry Operations
    /// </summary>
    public class QuizEntryDomainService : BaseDomainService<QuizEntry, IQuizEntryRepository>, IQuizEntryDomainService
    {
        #region Properties

        /// <summary>
        /// QuizRepository instance
        /// </summary>
        public IQuizEntryRepository QuizEntryRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Students the domain service.
        /// </summary>
        /// <param name="taskRepository">The task repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public QuizEntryDomainService(IQuizEntryRepository quizentryRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(quizentryRepository, exceptionManager, loggingService)
        {
            QuizEntryRepository = quizentryRepository;
        }

        #endregion

        #region Methods



        /// <summary>
        /// Gets the QuizEntry by student and quizId
        /// </summary>
        /// <param name="moduleId">The module id.</param>
        /// <returns>QuizEntry</returns>
        public QuizEntry GetQuizEntry(int quizId, int studentId)
        {
            QuizEntry quizEntry = new QuizEntry();
            try
            {
                quizEntry = QuizEntryRepository.GetQuizEntryByStudentAndQuiz(quizId, studentId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return quizEntry;

        }


        /// <summary>
        /// Get num of Attempts for a quiz
        /// </summary>
        /// <param name="quizId"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public int NumAttemptsSoFar(int quizId, int studentId)
        {
            int numattempt = 0;
            try
            {
                numattempt = QuizEntryRepository.NumAttemptsSoFar(quizId, studentId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return numattempt;
        }

        #endregion




    }
}
