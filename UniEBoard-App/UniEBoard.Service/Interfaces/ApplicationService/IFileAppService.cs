// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for File Application Service Operations
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

namespace UniEBoard.Service.Interfaces.ApplicationService
{
    /// <summary>
    /// IFileAppService Interface - Contains Methods for File Application Service Operations
    /// </summary>
    public interface IFileAppService : IBaseAppService
    {
        /// <summary>
        /// Gets or sets the file manager.
        /// </summary>
        /// <value>The file manager.</value>
        IFileDomainService FileManager { get; set; }

        /// <summary>
        /// Gets the file by id and identity token.
        /// </summary>
        /// <param name="fileId">The file id.</param>
        /// <param name="identityToken">The identity token.</param>
        /// <returns></returns>
        FileViewModel GetFileByIdAndIdentityToken(int fileId, Guid identityToken);
     
        /// <summary>
        /// Removes the file by id and identity token.
        /// </summary>
        /// <param name="fileId">The file id.</param>
        /// <param name="identityToken">The identity token.</param>
        void RemoveFileByIdAndIdentityToken(int fileId, Guid identityToken);

        /// <summary>
        /// Gets the files by submission.
        /// </summary>
        /// <param name="submissionId">The submission id.</param>
        /// <returns></returns>
        List<BaseFileViewModel> GetFilesBySubmission(int submissionId);

        /// <summary>
        /// Gets the file by id unit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <returns>FileViewModel</returns>
        List<FileViewModel> GetFileByUnitId(int unitId);
    }
}
