// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseFileDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Base File Operations
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
    /// BaseFileDomainService class definition - Contains Methods for Base File Operations
    /// </summary>
    public class BaseFileDomainService : BaseDomainService<BaseFile, IBaseFileRepository>, IBaseFileDomainService
    {
        #region Properties

        /// <summary>
        /// Base File Repository Instance
        /// </summary>
        public IBaseFileRepository BaseFileRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseFileDomainService"/> class.
        /// </summary>
        /// <param name="baseFileRepository">The base file repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public BaseFileDomainService(IBaseFileRepository baseFileRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(baseFileRepository, exceptionManager, loggingService)
        {
            BaseFileRepository = baseFileRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the files by submission.
        /// </summary>
        /// <param name="submissionId">The submission id.</param>
        /// <returns></returns>
        public List<BaseFile> GetFilesBySubmission(int submissionId)
        {
            List<BaseFile> files = new List<BaseFile>();
            try
            {
                files = BaseFileRepository.GetAllFilesBySubmission(submissionId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return files;
        }

        #endregion
    }
}
