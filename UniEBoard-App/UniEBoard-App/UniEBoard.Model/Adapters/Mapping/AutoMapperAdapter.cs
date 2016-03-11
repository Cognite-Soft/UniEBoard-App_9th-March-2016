// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoMapperAdapter.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Adapter for AutoMapper
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UniEBoard.Model.Interfaces.Adapter;

namespace UniEBoard.Model.Adapters.Mapping
{
    /// <summary>
    /// AutoMapper Adapter class
    /// </summary>
    public class AutoMapperAdapter : IObjectMapperAdapter
    {
        #region Methods

        /// <summary>
        /// Creates the map.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        public void CreateMap<TSource, TDestination>()
        {
            Mapper.CreateMap<TSource, TDestination>();
        }

        /// <summary>
        /// Maps the specified source entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="sourceEntity">The source entity.</param>
        /// <returns>A TEntity model mapped from the source entity</returns>
        public TModel Map<TEntity, TModel>(TEntity sourceEntity)
        {
            TModel model = default(TModel);
            if (sourceEntity != null)
            {
                model = Mapper.Map<TEntity, TModel>(sourceEntity);
            }
            return model;
        }

        /// <summary>
        /// Maps the specified source entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="sourceEntityList">The source List entity.</param>
        /// <returns>A List of TEntity model mapped from the source List entity</returns>
        public List<TModel> Map<TEntity, TModel>(List<TEntity> sourceEntityList)
        {
            var models = new List<TModel>();
            if (sourceEntityList != null)
            {
                models.AddRange(sourceEntityList.Select(Map<TEntity, TModel>));
            }
            return models;
        }

        /// <summary>
        /// Gets the entity identifier.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>The Integer Id Property object Identifier </returns>
        public int GetEntityIdentifier<TEntity>(TEntity entity)
        {
            int identifier = 0;
            if (entity != null)
            {
                Type t = entity.GetType();
                PropertyInfo propertyInfo = t.GetProperty("Id");
                if (propertyInfo != null && propertyInfo.PropertyType == typeof (int))
                {
                    int.TryParse((propertyInfo.GetValue(entity, null)).ToString(), out identifier);
                }
            }
            return identifier;
        }

        #endregion
    }
}
