// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleQuizRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for ModuleQuiz Repository CRUD operations.
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
    /// The ModuleQuiz Repository Class
    /// </summary>
    public class ModuleQuizRepository : BaseRepository<UniEBoardDbContext, Repository.ModuleQuiz, Model.Entities.ModuleQuiz>, IModuleQuizRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleQuizRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        public ModuleQuizRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        #endregion





    }
}
