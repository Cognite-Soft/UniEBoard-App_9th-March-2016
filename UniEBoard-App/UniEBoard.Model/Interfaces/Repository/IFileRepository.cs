// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for File Repository CRUD operations.
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
    /// The File Repository Interface
    /// </summary>
    public interface IFileRepository : IBaseRepository<File>
    {
        /// <summary>
        /// Finds the file by id and identity token.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="IdentityToken">The identity token.</param>
        /// <returns></returns>
        File FindFileByIdAndIdentityToken(int id, Guid IdentityToken);


        /// <summary>
        /// Finds the file by unit Id.
        /// </summary>
        /// <param name="unitId">The unit Id</param>
        /// <returns>File</returns>
        List<File> FindFileByUnitId(int unitId);
    }
}
