// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseFileRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for Base File Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Repository;
using UniEBoard.Model.Interfaces.Adapter;
using System.Data.Entity;
using System.Data.Objects.DataClasses;

namespace UniEBoard.Repository.Repositories
{
    /// <summary>
    /// The Base File Repository Class
    /// </summary>
    public class BaseFileRepository : BaseRepository<UniEBoardDbContext, Repository.BaseFile, Model.Entities.BaseFile>, IBaseFileRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseFileRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        public BaseFileRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all files by submission.
        /// </summary>
        /// <param name="submissionId">The submission id.</param>
        /// <returns></returns>
        public List<Model.Entities.BaseFile> GetAllFilesBySubmission(int submissionId)
        {
            List<Model.Entities.BaseFile> fileList = new List<Model.Entities.BaseFile>();
            try
            {
                // Fetch Files
                IQueryable<BaseFile> files = this.Context.Set<BaseFile>().Where(f => f.SubmissionId == submissionId);

                // Return Messages
                fileList = ObjectMapper.Map<BaseFile, Model.Entities.BaseFile>(files.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return fileList;
        }

        #endregion
    }
}
