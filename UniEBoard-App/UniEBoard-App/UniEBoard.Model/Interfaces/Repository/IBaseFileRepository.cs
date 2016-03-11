// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBaseFileRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for Base File Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;

namespace UniEBoard.Model.Interfaces.Repository
{
    /// <summary>
    /// The Base File Repository Interface
    /// </summary>
    public interface IBaseFileRepository : IBaseRepository<BaseFile>
    {
        /// <summary>
        /// Gets all files by submission.
        /// </summary>
        /// <param name="submissionId">The submission id.</param>
        /// <returns></returns>
        List<Model.Entities.BaseFile> GetAllFilesBySubmission(int submissionId);
    }
}
