// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAssetAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for all asset related operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Service.Models;
using UniEBoard.Service.Models.Courses;
using UniEBoard.Service.Models.Quizzes;
using System.Web.Mvc;

namespace UniEBoard.Service.Interfaces.ApplicationService
{
    /// <summary>
    /// IAssetAppService Interface - Contains Methods for all asset related operations
    /// </summary>
    public interface IAssetAppService : IBaseAppService
    {
        /// <summary>
        /// Gets or sets the Asset manager.
        /// </summary>
        /// <value>The Asset manager.</value>
        IAssetDomainService AssetManager { get; set; }

        /// <summary>
        /// Gets the asset by id.
        /// </summary>
        /// <param name="id">The id.</param>
        AssetViewModel GetAssetById(int id, bool includeTags = false);

        /// <summary>
        /// Gets the asset by name.
        /// </summary>
        /// <param name="id">The asset name.</param>
        AssetViewModel GetAssetByName(string assetName, bool includeTags = false);

        /// <summary>
        /// Updates the asset.
        /// </summary>
        /// <param name="asset">The asset.</param>
        /// <returns></returns>
        void UpdateAsset(AssetViewModel assetViewModel);

        /// <summary>
        /// Creates the asset.
        /// </summary>
        /// <param name="assetViewModel">The asset view model.</param>
        void CreateAsset(CreateAssetViewModel createAssetViewModel, string uploadPath, int companyId);

        /// <summary>
        /// Gets all assets by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <returns></returns>
        List<AssetViewModel> GetAllAssetsByCompany(int companyId, int view, List<String> tagsFiltering);

        /// <summary>
        /// Gets the video by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        VideoViewModel GetVideoById(int id);
        
        /// <summary>
        /// Removes the tag from asset.
        /// </summary>
        /// <param name="assetId">The asset id.</param>
        /// <param name="tagId">The tag id.</param>
        void RemoveTagFromAsset(int assetId, int tagId);

        /// <summary>
        /// Gets the videos assets by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <returns></returns>
        List<AssetViewModel> GetVideosAssetsByCompany(int companyId);

        /// <summary>
        /// Gets the document assets by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <returns></returns>
        List<AssetViewModel> GetDocumentAssetsByCompany(int companyId);

        /// <summary>
        /// Gets the asset types.
        /// </summary>
        /// <value>The asset types.</value>
        IEnumerable<SelectListItem> GetAssetTypes();

        /// <summary>
        /// Gets the upload types.
        /// </summary>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetUploadTypes();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<TagViewModel> GetAllTags();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="unitId"></param>
        UnitViewModel AddAssetForUnit(string assetName, int unitId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assetId"></param>
        /// <param name="unitId"></param>
        void RemoveAssetForUnit(int assetId, int unitId);
    }
}
