// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for File Operations
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
    /// FileDomainService class definition - Contains Methods for File Operations
    /// </summary>
    public class FileDomainService : BaseDomainService<File, IFileRepository>, IFileDomainService
    {
        #region Properties

        /// <summary>
        /// File Repository Instance
        /// </summary>
        public IFileRepository FileRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileDomainService"/> class.
        /// </summary>
        /// <param name="fileRepository">The file repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public FileDomainService(IFileRepository fileRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(fileRepository, exceptionManager, loggingService)
        {
            FileRepository = fileRepository;
        }

        #endregion

        #region Methods


        /// <summary>
        /// Gets the file by id and identity token.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="IdentityToken">The identity token.</param>
        /// <returns></returns>
        public File GetFileByIdAndIdentityToken(int id, Guid IdentityToken)
        {
            File file = null;
            try
            {
                file = FileRepository.FindFileByIdAndIdentityToken(id, IdentityToken);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return file;
        }

        /// <summary>
        /// Get the File by Unit Id
        /// </summary>
        /// <param name="unitId">the unit Id</param>
        /// <returns>File</returns>
        public List<File> GetFileByUnitId(int unitId)
        {
            List<File> files = new List<File>();
            try
            {
                files = FileRepository.FindFileByUnitId(unitId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return files;
        }
        
        /// <summary>
        /// Removes the file by id and identity token.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="IdentityToken">The identity token.</param>
        public void RemoveFileByIdAndIdentityToken(int id, Guid IdentityToken)
        {
            try
            {
                 File file = FileRepository.FindFileByIdAndIdentityToken(id, IdentityToken);
                if (file != null)
                {
                    FileRepository.Remove(file);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
        }

        #endregion


    }
}
