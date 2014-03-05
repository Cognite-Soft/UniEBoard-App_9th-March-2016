// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for File Repository CRUD operations.
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
    /// The File Repository Class
    /// </summary>
    public class FileRepository : BaseRepository<UniEBoardDbContext, Repository.File, Model.Entities.File>, IFileRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        public FileRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Finds the file by id and identity token.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="IdentityToken">The identity token.</param>
        /// <returns></returns>
        public Model.Entities.File FindFileByIdAndIdentityToken(int id, Guid IdentityToken)
        {
            Model.Entities.File file = null;
            try
            {
                IQueryable<File> files = this.Context.Set<File>().Where(f => f.Id == id && f.IdentityToken == IdentityToken).Take(1);

                // get File
                File fileEntity = files.FirstOrDefault();

                file = ObjectMapper.Map<File, Model.Entities.File>(fileEntity);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return file;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public List<Model.Entities.File> FindFileByUnitId(int unitId)
        {

            List<Model.Entities.File> fileModelList = new List<Model.Entities.File>();
            try
            {
                IQueryable<File> files = this.Context.Set<File>().Where(f => f.UnitId == unitId);

                // get File
                List<File> fileEntity = files.ToList();

                fileModelList = ObjectMapper.Map<File, Model.Entities.File>(fileEntity);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return fileModelList;
        }

        #endregion


      
    }
}
