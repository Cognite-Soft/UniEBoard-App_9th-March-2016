// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICacheAdapter.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for Caching operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Interfaces.Adapter
{
    /// <summary>
    /// The File Adapter Interface
    /// </summary>
    public interface IFileManagerAdapter
    {
        /// <summary>
        /// Saves the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>the path of the uploaded file</returns>
        string Save(System.Web.HttpPostedFileBase file,  string uploadPathlocation);

        /// <summary>
        /// Gets the type of the content.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        string GetContentType(System.Web.HttpPostedFileBase file);
    }
}
