// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAssetDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Asset Operations
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
    /// IAssetDomainService Interface definition - Contains Methods for Asset Operations
    /// </summary>
    public interface IAssetDomainService : IBaseDomainService<Asset>
    {
        /// <summary>
        /// Gets all assets by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<Asset> GetAllAssetsByCompany(int companyId, int view, List<String> tagsFiltering);

        /// <summary>
        /// Finds the with tags by.
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        /// <returns></returns>
        Asset FindWithTagsBy(int entityId);

        /// <summary>
        /// Gets the videos assets by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <returns></returns>
        List<Asset> GetVideosAssetsByCompany(int companyId);

        /// <summary>
        /// Gets the document assets by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <returns></returns>
        List<Asset> GetDocumentAssetsByCompany(int companyId);

        /// <summary>
        /// Removes the tag from asset.
        /// </summary>
        /// <param name="assetId">The asset id.</param>
        /// <param name="tagId">The tag id.</param>
        void RemoveTagFromAsset(int assetId, int tagId);

        /// <summary>
        /// Removes documents associated with an asset.
        /// </summary>
        /// <param name="companyId">The assetId.</param>
        /// <returns>true if successfully deleted and false otherwise</returns>
        bool RemoveDocuments(int assetId);

        /// <summary>
        /// Removes videos associated with an asset.
        /// </summary>
        /// <param name="companyId">The assetId.</param>
        /// <returns>true if successfully deleted and false otherwise</returns>
        bool RemoveVideos(int assetId);

        /// <summary>
        /// Removes images associated with an asset.
        /// </summary>
        /// <param name="companyId">The assetId.</param>
        /// <returns>true if successfully deleted and false otherwise</returns>
        bool RemoveImages(int assetId);

        /// <summary>
        /// Removes tags associated with an asset.
        /// </summary>
        /// <param name="companyId">The assetId.</param>
        /// <returns>true if successfully deleted and false otherwise</returns>
        bool RemoveTags(int assetId);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Tag> GetAllTags();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        Asset GetAssetByName(string assetName);
    }
}
