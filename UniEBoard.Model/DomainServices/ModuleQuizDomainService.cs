// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleQuizDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for ModuleQuiz Operations
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
using UniEBoard.Model.Interfaces.Repository;

namespace UniEBoard.Model.DomainServices
{
    /// <summary>
    /// ModuleQuizDomainService class definition - Contains Methods for ModuleQuiz Operations
    /// </summary>
    public class ModuleQuizDomainService : BaseDomainService<ModuleQuiz, IModuleQuizRepository>, IModuleQuizDomainService
    {
        #region Properties

        /// <summary>
        /// UserRepository instance
        /// </summary>
        public IModuleQuizRepository ModuleQuizRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleQuizDomainService"/> class.
        /// </summary>
        /// <param name="moduleQuizRepository">The module quiz repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public ModuleQuizDomainService(IModuleQuizRepository moduleQuizRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(moduleQuizRepository, exceptionManager, loggingService)
        {
            ModuleQuizRepository = moduleQuizRepository;
        }

        #endregion
    }
}
