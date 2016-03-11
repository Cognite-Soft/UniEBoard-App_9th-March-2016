// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssetDomainService.cs" company="Cognite Ltd">
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
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Factories;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Model.Interfaces.Repository;

namespace UniEBoard.Model.DomainServices
{
    /// <summary>
    /// AssetDomainService class definition - Contains Methods for Asset Operations
    /// </summary>
    public class AssetDomainService : BaseDomainService<Asset, IAssetRepository>, IAssetDomainService
    {
        #region Properties

        /// <summary>
        /// AssetRepository instance
        /// </summary>
        public IAssetRepository AssetRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Asset the domain service.
        /// </summary>
        /// <param name="taskRepository">The task repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public AssetDomainService(IAssetRepository assetRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(assetRepository, exceptionManager, loggingService)
        {
            AssetRepository = assetRepository;
            //base.FindBy(int entityId)
        }

        #endregion

        #region Methods

        /// <summary>
        /// Finds the by.
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        /// <returns></returns>
        public override Asset FindBy(int entityId)
        {
            Asset asset = null;
            try
            {
                asset = AssetRepository.GetAssetById(entityId, new List<string>());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return asset;
        }

        /// <summary>
        /// Finds the with tags by.
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        /// <returns></returns>
        public Asset FindWithTagsBy(int entityId)
        {
            Asset asset = null;
            try
            {
                asset = AssetRepository.GetAssetById(entityId, new List<string> { "Tags"});
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return asset;
        }

        /// <summary>
        /// Gets all assets by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<Asset> GetAllAssetsByCompany(int companyId, int view, List<String> tagsFiltering)
        {
            List<Asset> assets = new List<Asset>();
            try
            {
                assets = AssetRepository.FindAssetsByCompany(companyId, view, tagsFiltering);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return assets;
        }

        /// <summary>
        /// Gets the videos assets by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <returns></returns>
        public List<Asset> GetVideosAssetsByCompany(int companyId)
        {
            List<Asset> assets = new List<Asset>();
            try
            {
                assets = AssetRepository.FindVideoAssetsByCompany(companyId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return assets;
        }

        /// <summary>
        /// Gets the document assets by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <returns></returns>
        public List<Asset> GetDocumentAssetsByCompany(int companyId)
        {
            List<Asset> assets = new List<Asset>();
            try
            {
                assets = AssetRepository.FindDocumentAssetsByCompany(companyId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return assets;
        }

        /// <summary>
        /// Removes the tag from asset.
        /// </summary>
        /// <param name="assetId">The asset id.</param>
        /// <param name="tagId">The tag id.</param>
        public void RemoveTagFromAsset(int assetId, int tagId)
        {
            try
            {
                AssetRepository.RemoveTagFromAsset(assetId, tagId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
        }

        /// <summary>
        /// Removes documents associated with an asset.
        /// </summary>
        /// <param name="companyId">The assetId.</param>
        /// <returns>true if successfully deleted and false otherwise</returns>
        public bool RemoveDocuments(int assetId)
        {
            try
            {
                AssetRepository.RemoveDocuments(assetId);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return false;
        }

        /// <summary>
        /// Removes videos associated with an asset.
        /// </summary>
        /// <param name="companyId">The assetId.</param>
        /// <returns>true if successfully deleted and false otherwise</returns>
        public bool RemoveVideos(int assetId)
        {
            try
            {
                AssetRepository.RemoveVideos(assetId);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return false;
        }

        /// <summary>
        /// Removes images associated with an asset.
        /// </summary>
        /// <param name="companyId">The assetId.</param>
        /// <returns>true if successfully deleted and false otherwise</returns>
        public bool RemoveImages(int assetId)
        {
            try
            {
                AssetRepository.RemoveImages(assetId);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return false;
        }

        /// <summary>
        /// Removes tags associated with an asset.
        /// </summary>
        /// <param name="companyId">The assetId.</param>
        /// <returns>true if successfully deleted and false otherwise</returns>
        public bool RemoveTags(int assetId)
        {
            try
            {
                AssetRepository.RemoveTags(assetId);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Tag> GetAllTags()
        {
            List<Tag> tags = new List<Tag>();
            try
            {
                tags = AssetRepository.GetAllTags();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return tags;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public Asset GetAssetByName(string assetName)
        {
            Asset asset = new Asset();
            try
            {
                asset = AssetRepository.GetAssetByName(assetName);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return asset;

        }

        #endregion
    }
}
