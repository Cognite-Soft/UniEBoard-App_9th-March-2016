// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssetViewModelFactory.cs" company="Cognite Ltd">
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
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Service.Models;

namespace UniEBoard.Service.Factories
{
    /// <summary>
    /// 
    /// </summary>
    public static class AssetViewModelFactory
    {
        #region Methods

        /// <summary>
        /// Creates from domain model.
        /// </summary>
        /// <param name="asset">The asset.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static AssetViewModel CreateFromDomainModel(Asset asset, IObjectMapperAdapter objectMapper)
        {
            if (asset is Video)
            {
                return objectMapper.Map<Video, VideoViewModel>((Video)asset);
            }
            else if (asset is Document)
            {
                return objectMapper.Map<Document, DocumentViewModel>((Document)asset);
            }
            else if (asset is Image)
            {
                return objectMapper.Map<Image, ImageViewModel>((Image)asset);
            }
            else
            {
                return objectMapper.Map<Asset, AssetViewModel>(asset);
            }
        }

        /// <summary>
        /// Creates from domain model.
        /// </summary>
        /// <param name="asset">The asset.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static List<AssetViewModel> CreateFromDomainModel(List<Asset> asset, IObjectMapperAdapter objectMapper)
        {
            return asset.Select(a => CreateFromDomainModel(a, objectMapper)).ToList<AssetViewModel>();
        }

        /// <summary>
        /// Creates from view model model.
        /// </summary>
        /// <param name="asset">The asset.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static Asset CreateFromViewModelModel(AssetViewModel asset, IObjectMapperAdapter objectMapper)
        {
            if (asset is VideoViewModel)
            {
                return objectMapper.Map<VideoViewModel, Video>((VideoViewModel)asset);
            }
            else if (asset is DocumentViewModel)
            {
                return objectMapper.Map<DocumentViewModel, Document>((DocumentViewModel)asset);
            }
            else if (asset is ImageViewModel)
            {
                return objectMapper.Map<ImageViewModel, Image>((ImageViewModel)asset);
            }
            else
            {
                return objectMapper.Map<AssetViewModel, Asset>(asset);
            }
        }

        /// <summary>
        /// Creates from view model model.
        /// </summary>
        /// <param name="asset">The asset.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static List<Asset> CreateFromViewModelModel(List<AssetViewModel> asset, IObjectMapperAdapter objectMapper)
        {
            return asset.Select(a => CreateFromViewModelModel(a, objectMapper)).ToList<Asset>();
        }

        /// <summary>
        /// Creates the asset view model from create asset view model.
        /// </summary>
        /// <param name="createAssetViewModel">The create asset view model.</param>
        /// <param name="uploadPath">The upload path.</param>
        /// <param name="companyId">The company id.</param>
        /// <param name="fileManagerAdapter">The file manager adapter.</param>
        /// <returns></returns>
        public static AssetViewModel CreateAssetViewModelFromCreateAssetViewModel(CreateAssetViewModel createAssetViewModel, string uploadPath, int companyId, IFileManagerAdapter fileManagerAdapter)
        {
            AssetViewModel assetViewModel = CreateAssetViewModelFromCreateAssetViewModel(createAssetViewModel);
            if (assetViewModel != null)
            {
                bool isWebUrl = !string.IsNullOrEmpty(createAssetViewModel.Path) ? true : false;
                assetViewModel.AssetType = createAssetViewModel.AssetType;
                assetViewModel.Name = createAssetViewModel.Name;
                assetViewModel.CompanyId = companyId;
                assetViewModel.Path = isWebUrl
                        ? createAssetViewModel.Path
                        : fileManagerAdapter.Save(createAssetViewModel.UploadFile, uploadPath);
                assetViewModel.ContentType = fileManagerAdapter.GetContentType(createAssetViewModel.UploadFile);
                if (assetViewModel is VideoViewModel)
                {
                    ((VideoViewModel)assetViewModel).AlternatePath = fileManagerAdapter.Save(createAssetViewModel.AlternateUploadFile, uploadPath);
                    ((VideoViewModel)assetViewModel).AlternateContentType = fileManagerAdapter.GetContentType(createAssetViewModel.AlternateUploadFile);
                }
            }
            return assetViewModel;
        }

        /// <summary>
        /// Creates the asset view model from create asset view model.
        /// </summary>
        /// <param name="createAssetViewModel">The create asset view model.</param>
        /// <returns></returns>
        private static AssetViewModel CreateAssetViewModelFromCreateAssetViewModel(CreateAssetViewModel createAssetViewModel)
        {
            if (createAssetViewModel != null && (!string.IsNullOrEmpty(createAssetViewModel.Path) || createAssetViewModel.UploadFile != null))
            {
                switch (createAssetViewModel.AssetType)
                {
                    case (int)AssetTypeEnum.Image:
                        return new ImageViewModel();
                    case (int)AssetTypeEnum.Document:
                        return new DocumentViewModel();
                    case (int)AssetTypeEnum.Video:
                        return new VideoViewModel();
                }
            }
            return null;
        }

        
        #endregion
    }
}
