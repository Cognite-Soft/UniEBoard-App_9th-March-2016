// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for File Operations
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
    /// IFileDomainService interface definition - Contains Methods for File Operations
    /// </summary>
    public interface IFileDomainService : IBaseDomainService<File>
    {
        /// <summary>
        /// Gets the file by id and identity token.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="IdentityToken">The identity token.</param>
        /// <returns></returns>
        File GetFileByIdAndIdentityToken(int id, Guid IdentityToken);

        /// <summary>
        /// Gets the file by id unit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <returns>File</returns>
        List<File> GetFileByUnitId(int unitId);

        /// <summary>
        /// Removes the file by id and identity token.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="IdentityToken">The identity token.</param>
        void RemoveFileByIdAndIdentityToken(int id, Guid IdentityToken);
    }
}
