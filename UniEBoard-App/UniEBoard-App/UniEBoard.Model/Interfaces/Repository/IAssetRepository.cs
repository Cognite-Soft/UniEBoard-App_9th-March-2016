// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAssetRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for Asset Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;

namespace UniEBoard.Model.Interfaces.Repository
{
    /// <summary>
    /// The Asset Repository Interface
    /// </summary>
    public interface IAssetRepository : IBaseRepository<Asset>
    {
        /// <summary>
        /// Gets the asset by id.
        /// </summary>
        /// <param name="assetId">The asset id.</param>
        /// <returns></returns>
        Asset GetAssetById(int assetId, List<string> includeAssociations);

        /// <summary>
        /// Finds the assets by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <returns></returns>
        List<Asset> FindAssetsByCompany(int companyId, int view, List<String> tagsFiltering);

        /// <summary>
        /// Removes the tag from asset.
        /// </summary>
        /// <param name="assetId">The asset id.</param>
        /// <param name="tagId">The tag id.</param>
        void RemoveTagFromAsset(int assetId, int tagId);

        /// <summary>
        /// Finds the video assets by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <returns></returns>
        List<Model.Entities.Asset> FindVideoAssetsByCompany(int companyId);

        /// <summary>
        /// Finds the video assets by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <returns></returns>
        List<Model.Entities.Asset> FindDocumentAssetsByCompany(int companyId);

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
        /// <param name="moduleId"></param>
        /// <returns></returns>
        List<Model.Entities.Tag> GetTagsForAsset(int tagId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseModule"></param>
        void AddTagForAsset(Model.Entities.Tag tag, Model.Entities.Asset asset);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Model.Entities.Tag> GetAllTags();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        Model.Entities.Asset GetAssetByName(string assetName);
    }
}
