// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssetAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Asset Application Service Operations
//  Transforms entity domain models to view models
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Service.Interfaces.ApplicationService;
using UniEBoard.Service.Models;
using UniEBoard.Service.Factories;
using UniEBoard.Model.Adapters.Logging;
using UniEBoard.Service.Models.Courses;
using UniEBoard.Service.Models.Quizzes;
using UniEBoard.Service.Factories;
using System.Web.Mvc;
using Cognite.Utility.Helpers.Methods;

namespace UniEBoard.Service.ApplicationServices
{
    /// <summary>
    /// Asset AssetAppService Service Class - Contains Methods for Asset Application Service Operations
    /// </summary>
    public class AssetAppService : BaseAppService, IAssetAppService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Asset manager.
        /// </summary>Asset manager.</value>
        public IAssetDomainService AssetManager { get; set; }

        /// <summary>
        /// Gets or sets the video manager.
        /// </summary>
        /// <value>The video manager.</value>
        public IVideoDomainService VideoManager { get; set; }

        /// <summary>
        /// Gets or sets the file manager.
        /// </summary>
        /// <value>The file manager.</value>
        public IFileManagerAdapter FileManager { get; set; }

        public IUnitDomainService UnitManager { get; set; }
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetAppService"/> class.
        /// </summary>
        /// <param name="AssetManager">The asset manager.</param>
        /// <param name="VideoManager">The video manager.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="cacheService">The cache service.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public AssetAppService(
            IAssetDomainService assetManager,
            IUnitDomainService unitManager,
            IVideoDomainService videoManager,
            IObjectMapperAdapter objectMapper,
            ICacheAdapter cacheService,
            IFileManagerAdapter fileManager,
            IExceptionManagerAdapter exceptionManager,
            ILoggingServiceAdapter loggingService)
            : base(objectMapper, cacheService, exceptionManager, loggingService)
        {
            this.AssetManager = assetManager;
            this.UnitManager = unitManager;
            this.VideoManager = videoManager;
            this.FileManager = fileManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the asset by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// 

        /// <summary>
        /// Gets the asset by id.
        /// </summary>
        /// <param name="id">The id.</param>
        public AssetViewModel GetAssetById(int id, bool includeTags = false)
        {
            try
            {
                Asset asset = includeTags ? AssetManager.FindWithTagsBy(id) : AssetManager.FindBy(id);
                return AssetViewModelFactory.CreateFromDomainModel(asset, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return null;
        }

        /// <summary>
        /// Gets the asset by name.
        /// </summary>
        /// <param name="id">The asset name.</param>
        public AssetViewModel GetAssetByName(string assetName, bool includeTags = false)
        {
            try
            {
                Asset asset = AssetManager.GetAssetByName(assetName);
                return AssetViewModelFactory.CreateFromDomainModel(asset, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return null;
        }

        /// <summary>
        /// Gets the video by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public VideoViewModel GetVideoById(int id)
        {
            try
            {
                Video asset = VideoManager.FindBy(id);
                return ObjectMapper.Map<Model.Entities.Video, VideoViewModel>(asset);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return null;
        }

        /// <summary>
        /// Gets all assets by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <returns></returns>
        public List<AssetViewModel> GetAllAssetsByCompany(int companyId, int view, List<String> tagsFiltering)
        {
            List<AssetViewModel> models = new List<AssetViewModel>();
            try
            {
                List<Asset> assets = AssetManager.GetAllAssetsByCompany(companyId, view, tagsFiltering);
                models = AssetViewModelFactory.CreateFromDomainModel(assets, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Updates the asset.
        /// </summary>
        /// <param name="asset">The asset.</param>
        /// <returns></returns>
        public void UpdateAsset(AssetViewModel assetViewModel)
        {
            try
            {
                Asset asset = AssetViewModelFactory.CreateFromViewModelModel(assetViewModel, ObjectMapper);
                AssetManager.Update(asset);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        /// <summary>
        /// Creates the asset.
        /// </summary>
        /// <param name="assetViewModel">The asset view model.</param>
        public void CreateAsset(CreateAssetViewModel createAssetViewModel, string uploadPath, int companyId)
        {
            try
            {
                AssetViewModel assetviewModel = AssetViewModelFactory.CreateAssetViewModelFromCreateAssetViewModel(createAssetViewModel, uploadPath, companyId, FileManager);

                if (assetviewModel.AssetType == 1) 
                {
                    if (IsYoutubeVideo(assetviewModel)) 
                    {
                        assetviewModel = embedYoutubeVideo(assetviewModel);
                    }
                
                }


                Asset asset = AssetViewModelFactory.CreateFromViewModelModel(assetviewModel, ObjectMapper);
                AssetManager.Add(asset);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
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
                AssetManager.RemoveTagFromAsset(assetId, tagId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        /// <summary>
        /// Gets the videos assets by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <returns></returns>
        public List<AssetViewModel> GetVideosAssetsByCompany(int companyId)
        {
            List<AssetViewModel> models = new List<AssetViewModel>();
            try
            {
                List<Asset> assets = AssetManager.GetVideosAssetsByCompany(companyId);
                models = AssetViewModelFactory.CreateFromDomainModel(assets, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets the document assets by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <returns></returns>
        public List<AssetViewModel> GetDocumentAssetsByCompany(int companyId)
        {
            List<AssetViewModel> models = new List<AssetViewModel>();
            try
            {
                List<Asset> assets = AssetManager.GetDocumentAssetsByCompany(companyId);
                models = AssetViewModelFactory.CreateFromDomainModel(assets, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets the asset types.
        /// </summary>
        /// <value>The asset types.</value>
        public IEnumerable<SelectListItem> GetAssetTypes()
        {
            return new[]
            {
                new SelectListItem { Value = string.Format("{0}",(int)AssetTypeEnum.Video), Text = EnumHelper.DiscriptionFor(AssetTypeEnum.Video)},
                new SelectListItem { Value = string.Format("{0}",(int)AssetTypeEnum.Document), Text = EnumHelper.DiscriptionFor(AssetTypeEnum.Document) },
                new SelectListItem { Value = string.Format("{0}",(int)AssetTypeEnum.Image), Text = EnumHelper.DiscriptionFor(AssetTypeEnum.Image) },
            };
        }

        /// <summary>
        /// Gets the upload types.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GetUploadTypes()
        {
            return new[]
            {
                new SelectListItem { Value = string.Format("{0}",(int)AssetUploadEnum.Web), Text = EnumHelper.DiscriptionFor(AssetUploadEnum.Web)},
                new SelectListItem { Value = string.Format("{0}",(int)AssetUploadEnum.File), Text = EnumHelper.DiscriptionFor(AssetUploadEnum.File) }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TagViewModel> GetAllTags() 
        {
            List<TagViewModel> tags = new List<TagViewModel>();
            try
            {
                tags = ObjectMapper.Map<Model.Entities.Tag, TagViewModel>(AssetManager.GetAllTags());
               
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return tags;
        }

        public UnitViewModel AddAssetForUnit(string assetName, int unitId) 
        {
            try
            {
                return ObjectMapper.Map<Model.Entities.Unit, UnitViewModel>(UnitManager.AddAssetForUnit(assetName, unitId));
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return null;
        }

        public void RemoveAssetForUnit(int assetId, int unitId)
        {
            try
            {
                Asset asset = AssetManager.FindBy(assetId);
                Unit unit = UnitManager.FindBy(unitId);
                UnitManager.RemoveAssetForUnit(unit, asset);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Checks if a new Asset consists of a Youtube video
        /// </summary>
        /// <param name="createAssetViewModel"></param>
        /// <returns></returns>
        private static bool IsYoutubeVideo(AssetViewModel assetViewModel)
        {
            string lowerpath = assetViewModel.Path.ToLower();
            return (lowerpath.StartsWith("http://www.youtube") || lowerpath.StartsWith("www.youtube"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createAssetViewModel"></param>
        /// <returns></returns>
        private AssetViewModel embedYoutubeVideo(AssetViewModel assetViewModel)
        {
            string lowerpath = assetViewModel.Path.ToLower();

            if (lowerpath.StartsWith("http://www.youtube.com/watch?v=") || lowerpath.StartsWith("www.youtube.com/watch?v="))
            {
                assetViewModel.Path = "http://www.youtube.com/embed/" + assetViewModel.Path.Substring(lowerpath.LastIndexOf("=") + 1);
            }

            return assetViewModel;
        }

        #endregion

    }
}
