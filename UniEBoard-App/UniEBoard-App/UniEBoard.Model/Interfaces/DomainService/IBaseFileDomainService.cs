// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBaseFileDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for Base File Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;

namespace UniEBoard.Model.Interfaces.DomainService
{
    /// <summary>
    /// IBaseFileDomainService interface definition - Contains Methods for Base File Operations
    /// </summary>
    public interface IBaseFileDomainService : IBaseDomainService<BaseFile>
    {
        /// <summary>
        /// Gets the files by submission.
        /// </summary>
        /// <param name="submissionId">The submission id.</param>
        /// <returns></returns>
        List<BaseFile> GetFilesBySubmission(int submissionId);
    }
}
