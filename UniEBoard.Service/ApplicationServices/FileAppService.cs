// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for File Application Service Operations
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

namespace UniEBoard.Service.ApplicationServices
{
    /// <summary>
    /// File Application Service Class - Contains Methods for File Application Service Operations
    /// </summary>
    public class FileAppService : BaseAppService, IFileAppService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the file manager.
        /// </summary>
        /// <value>The file manager.</value>
        public IFileDomainService FileManager { get; set; }

        /// <summary>
        /// Gets or sets the base file manager.
        /// </summary>
        /// <value>The base file manager.</value>
        public IBaseFileDomainService BaseFileManager { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileAppService"/> class.
        /// </summary>
        /// <param name="fileManager">The file manager.</param>
        /// <param name="baseFileManager">The base file manager.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="cacheService">The cache service.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public FileAppService(
            IFileDomainService fileManager,
            IBaseFileDomainService baseFileManager,
            IObjectMapperAdapter objectMapper,
            ICacheAdapter cacheService,
            IExceptionManagerAdapter exceptionManager,
            ILoggingServiceAdapter loggingService)
            : base(objectMapper, cacheService, exceptionManager, loggingService)
        {
            this.FileManager = fileManager;
            this.BaseFileManager = baseFileManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the file by id and identity token.
        /// </summary>
        /// <param name="fileId">The file id.</param>
        /// <param name="identityToken">The identity token.</param>
        /// <returns></returns>
        public FileViewModel GetFileByIdAndIdentityToken(int fileId, Guid identityToken)
        {

            FileViewModel model = null;
            try
            {
                File file = FileManager.GetFileByIdAndIdentityToken(fileId, identityToken);
                model = ObjectMapper.Map<Model.Entities.File, FileViewModel>(file);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return model;
        }

        /// <summary>
        /// Gets the file by id unit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <returns>FileViewModel</returns>
        public List<FileViewModel> GetFileByUnitId(int unitId)
        {
            List<FileViewModel> model = new List<FileViewModel>();
            try
            {
                List<File> files = FileManager.GetFileByUnitId(unitId);
                model = ObjectMapper.Map<Model.Entities.File, FileViewModel>(files);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return model;
        }

        /// <summary>
        /// Removes the file by id and identity token.
        /// </summary>
        /// <param name="fileId">The file id.</param>
        /// <param name="identityToken">The identity token.</param>
        public void RemoveFileByIdAndIdentityToken(int fileId, Guid identityToken)
        {
            try
            {
                FileManager.RemoveFileByIdAndIdentityToken(fileId, identityToken);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        /// <summary>
        /// Gets the files by submission.
        /// </summary>
        /// <param name="submissionId">The submission id.</param>
        /// <returns></returns>
        public List<BaseFileViewModel> GetFilesBySubmission(int submissionId)
        {
            List<BaseFileViewModel> model = new List<BaseFileViewModel>();
            try
            {
                List<BaseFile> fileList = BaseFileManager.GetFilesBySubmission(submissionId);
                model = ObjectMapper.Map<Model.Entities.BaseFile, BaseFileViewModel>(fileList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return model;
        }

        #endregion


       
    }
}
