// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEventLogService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for Object Mapping.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Interfaces.Adapter
{
    /// <summary>
    /// The Object Mapper Interface
    /// </summary>
    public interface IObjectMapperAdapter
    {
        /// <summary>
        /// Creates the map.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        void CreateMap<TSource, TDestination>();

        /// <summary>
        /// Maps the specified source entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="sourceEntity">The source entity.</param>
        /// <returns>A TEntity model mapped from the source entity</returns>
        TModel Map<TEntity, TModel>(TEntity sourceEntity);

        /// <summary>
        /// Maps the specified source entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="sourceEntityList">The source List entity.</param>
        /// <returns>A List of TEntity model mapped from the source List entity</returns>
        List<TModel> Map<TEntity, TModel>(List<TEntity> sourceEntityList);

        /// <summary>
        /// Gets the entity identifier.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>The Integer Id Property object Identifier </returns>
        int GetEntityIdentifier<TEntity>(TEntity entity);
    }
}
