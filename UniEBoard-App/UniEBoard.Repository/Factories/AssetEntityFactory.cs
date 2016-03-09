// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssetEntityFactory.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  AssetEntityFactory class definition
//  Contains methods to build Asset Entities
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Interfaces.Adapter;

namespace UniEBoard.Repository.Factories
{
    /// <summary>
    /// 
    /// </summary>
    public static class AssetEntityFactory
    {
        #region Methods

        /// <summary>
        /// Creates the asset entity.
        /// </summary>
        /// <param name="asset">The asset.</param>
        /// <returns></returns>
        public static Model.Entities.Asset CreateFromDataModel(Asset asset, IObjectMapperAdapter objectMapper)
        {
            if (asset is Video)
            {
                return objectMapper.Map<Video, Model.Entities.Video>((Video)asset);
            }
            else if (asset is Document)
            {
                return objectMapper.Map<Document, Model.Entities.Document>((Document)asset);
            }
            else if (asset is Image)
            {
                return objectMapper.Map<Image, Model.Entities.Image>((Image)asset);
            }
            else
            {
                return objectMapper.Map<Asset, Model.Entities.Asset>(asset);
            }
        }

        /// <summary>
        /// Creates from data model.
        /// </summary>
        /// <param name="asset">The asset.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static List<Model.Entities.Asset> CreateFromDataModel(List<Asset> asset, IObjectMapperAdapter objectMapper)
        {
            return asset.Select(a => CreateFromDataModel(a, objectMapper)).ToList<Model.Entities.Asset>();
        }

        /// <summary>
        /// Creates from domain model.
        /// </summary>
        /// <param name="asset">The asset.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static Repository.Asset CreateFromDomainModel(Model.Entities.Asset asset, IObjectMapperAdapter objectMapper)
        {
            if (asset is Model.Entities.Video)
            {
                return objectMapper.Map<Model.Entities.Video, Video>((Model.Entities.Video)asset);
            }
            else if (asset is Model.Entities.Document)
            {
                return objectMapper.Map<Model.Entities.Document, Document>((Model.Entities.Document)asset);
            }
            else if (asset is Model.Entities.Image)
            {
                return objectMapper.Map<Model.Entities.Image, Image>((Model.Entities.Image)asset);
            }
            else
            {
                return objectMapper.Map<Model.Entities.Asset, Asset>(asset);
            }
        }

        /// <summary>
        /// Creates from domain model.
        /// </summary>
        /// <param name="asset">The asset.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static List<Asset> CreateFromDomainModel(List<Model.Entities.Asset> asset, IObjectMapperAdapter objectMapper)
        {
            return asset.Select(a => CreateFromDomainModel(a, objectMapper)).ToList<Asset>();
        }

        
        #endregion
    }
}
