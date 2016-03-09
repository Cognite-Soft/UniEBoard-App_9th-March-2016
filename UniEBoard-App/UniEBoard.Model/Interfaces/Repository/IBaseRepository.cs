// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBaseRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using UniEBoard.Model.Interfaces.Adapter;

namespace UniEBoard.Model.Interfaces.Repository
{
    /// <summary>
    /// The Base Repository Interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<TModel>
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        TModel Add(TModel entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(TModel entity);

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Remove(TModel entity);

        /// <summary>
        /// Removes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        void Remove(int id);

        /// <summary>
        /// Finds all entities.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        IQueryable<TModel> FindAll();

        /// <summary>
        /// Finds all entities and includes their associations
        /// This method is used for selective eager loading when lazy loading is off.
        /// </summary>
        /// <param name="includeAssociations">The include associations. I.e Navigational property names</param>
        /// <returns></returns>
        IQueryable<TModel> FindAll(List<string> includeAssociations);

        /// <summary>
        /// Finds all entities.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        IQueryable<TModel> FindAll<TContextEntity>(Expression<Func<TContextEntity, bool>> predicate);

        ///// <summary>
        ///// Finds all entities and includes their associations
        ///// This method is used for selective eager loading when lazy loading is off.
        ///// </summary>
        ///// <param name="includeAssociations">The include associations. I.e Navigational property names</param>
        ///// <returns></returns>
        //IQueryable<TModel> FindAll<TContextEntity>(List<string> includeAssociations, Expression<Func<TEntityModel, bool>> predicate);

        /// <summary>
        /// Finds by the specified Id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns></returns>
        TModel FindBy(int objectId);

        /// <summary>
        /// Finds by the specified Id and includes their associations.
        /// This method is used for selective eager loading when lazy loading is off.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <param name="includeAssociations">The include associations.</param>
        /// <returns></returns>
        TModel FindBy(int objectId, List<string> includeAssociations);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keySelector"></param>
        /// <param name="includeAssociations"></param>
        /// <returns></returns>
        TModel FindBy(Expression<Func<TModel, bool>> predicate, List<string> includeAssociations);

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// Reload the data from datastore into the context.
        /// </summary>
        /// <param name="entity">entity id</param>
        void RemoveRefresh(int id);
    }
}
