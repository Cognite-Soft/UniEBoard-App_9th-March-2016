// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssetRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for Asset Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Repository;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Repository.Factories;

namespace UniEBoard.Repository.Repositories
{
    /// <summary>
    /// The Asset Repository Class
    /// </summary>
    public class AssetRepository : BaseRepository<UniEBoardDbContext, Repository.Asset, Model.Entities.Asset>, IAssetRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        public AssetRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public override Model.Entities.Asset Add(Model.Entities.Asset model)
        {
            Asset newEntity = AssetEntityFactory.CreateFromDomainModel(model, ObjectMapper);
            DbEntityEntry entry = Context.Entry<Asset>(newEntity);
            if (entry.State == System.Data.Entity.EntityState.Detached)
            {
                Context.Entry<Asset>(newEntity).State = System.Data.Entity.EntityState.Added;
                Context.SaveChanges();
            }
            return AssetEntityFactory.CreateFromDataModel(newEntity, ObjectMapper);
        }

        /// <summary>
        /// Gets the asset by id.
        /// </summary>
        /// <param name="moduleId">The module id.</param>
        /// <returns></returns>
        public Model.Entities.Asset GetAssetById(int assetId, List<string> includeAssociations)
        {
            Model.Entities.Asset asset = null;
            try
            {
                IQueryable<Asset> assets = this.Context.Assets.Where(a => a.Id.Equals(assetId));
                assets = IncludePropertyAssociations(assets, includeAssociations);
                Asset assetEntity = assets.ToList().FirstOrDefault();
                asset = AssetEntityFactory.CreateFromDataModel(assetEntity, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return asset;
        }

        /// <summary>
        /// Finds the assets by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <returns></returns>
        public List<Model.Entities.Asset> FindAssetsByCompany(int companyId, int view, List<String> tagsFiltering)
        {
            List<Model.Entities.Asset> assetList = new List<Model.Entities.Asset>();
            try
            {
                IQueryable<Asset> assetQuery = this.Context.Set<Asset>()
                    .Where(a => a.CompanyId.Equals(companyId))
                    .Include("Tags")
                    .OrderByDescending(p => p.Id);           
                
                // Filtering
                if (tagsFiltering != null && tagsFiltering.Count > 0)
                {
                    List<Asset> assetListEntity = assetQuery.ToList();
                    List<Asset> assetListFiltered = new List<Asset>();
                    assetListEntity.ForEach(a => a.Tags.ToList<Tag>()
                        .ForEach(t =>
                        {
                            if (!assetListFiltered.Contains(a))
                            {
                                if (tagsFiltering.Contains(t.Name))
                                {
                                    assetListFiltered.Add(a);
                                }
                            }

                        }
                    ));

                    // Return Assets
                    assetList = AssetEntityFactory.CreateFromDataModel(assetListFiltered, ObjectMapper);
                }
                else 
                {
                    // Return Assets
                    assetList = AssetEntityFactory.CreateFromDataModel(assetQuery.ToList(), ObjectMapper);
                }

                if (view != 0)
                {
                    //assetQuery = assetQuery.Take(view);
                    assetList =  assetList.Take<Model.Entities.Asset>(view).ToList();
                }
                
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return assetList;
        }

       

        /// <summary>
        /// Finds the video assets by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <returns></returns>
        public List<Model.Entities.Asset> FindVideoAssetsByCompany(int companyId)
        {
            List<Model.Entities.Asset> assetList = new List<Model.Entities.Asset>();
            try
            {
                IQueryable<Asset> assetQuery = this.Context.Set<Video>().Where(a => a.CompanyId.Equals(companyId)).OrderByDescending(p => p.Id);

                // Return Assets
                assetList = AssetEntityFactory.CreateFromDataModel(assetQuery.ToList(), ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return assetList;
        }

                /// <summary>
        /// Finds the video assets by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <returns></returns>
        public List<Model.Entities.Asset> FindDocumentAssetsByCompany(int companyId)
        {
            List<Model.Entities.Asset> assetList = new List<Model.Entities.Asset>();
            try
            {
                IQueryable<Asset> assetQuery = this.Context.Set<Document>().Where(a => a.CompanyId.Equals(companyId)).OrderByDescending(p => p.Id);

                // Return Assets
                assetList = AssetEntityFactory.CreateFromDataModel(assetQuery.ToList(), ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return assetList;
        }

        /// <summary>
        /// Removes the tag from asset.
        /// </summary>
        /// <param name="assetId">The asset id.</param>
        /// <param name="tagId">The tag id.</param>
        public void RemoveTagFromAsset(int assetId, int tagId)
        {
            Asset asset = this.Context.Set<Asset>().Where(a => a.Id.Equals(assetId)).Include("Tags").ToList().FirstOrDefault();
            Tag tag = asset.Tags.Where(t => t.Id.Equals(tagId)).FirstOrDefault();
            if (tag != null)
            {
                asset.Tags.Remove(tag);
                Context.Entry(asset).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
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
                List<Document> documents = this.Context.Set<Document>().Where(d => d.Id.Equals(assetId)).ToList();
                foreach (var document in documents)
                {
                    this.Context.Set<Document>().Remove(document);
                }
                this.Context.SaveChanges();
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
                List<Video> videos = this.Context.Set<Video>().Where(d => d.Id.Equals(assetId)).ToList();
                foreach (var video in videos)
                {
                    this.Context.Set<Video>().Remove(video);
                }
                this.Context.SaveChanges();
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
                List<Image> images = this.Context.Set<Image>().Where(d => d.Id.Equals(assetId)).ToList();
                foreach (var image in images)
                {
                    this.Context.Set<Image>().Remove(image);
                }
                this.Context.SaveChanges();
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
                Asset asset = this.Context.Set<Asset>().Where(a => a.Id.Equals(assetId)).Include("Tags").FirstOrDefault();
                if (asset == null) return true;
                List<Tag> tags = asset.Tags.ToList();
                foreach (var tag in tags)
                {
                    asset.Tags.Remove(tag);
                }
                this.Context.SaveChanges();
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
        /// <param name="assetId"></param>
        /// <returns></returns>
        public List<Model.Entities.Tag> GetTagsForAsset(int assetId)
        {
            List<Model.Entities.Tag> tagForAssetlist = new List<Model.Entities.Tag>();
            try
            {
                // Select Courses

                Asset asset = new Asset();
                asset = this.Context.Set<Asset>().Include("Tag").Where(a => a.Id == assetId).ToList<Asset>().FirstOrDefault<Asset>();

                tagForAssetlist = ObjectMapper.Map<Tag, Model.Entities.Tag>(asset.Tags.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return tagForAssetlist;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="asset"></param>
        public void AddTagForAsset(Model.Entities.Tag tag, Model.Entities.Asset asset)
        {
            try
            {
                Asset newAssetEntity = ObjectMapper.Map<Model.Entities.Asset, Asset>(asset);
                Tag newTagEntity = ObjectMapper.Map<Model.Entities.Tag, Tag>(tag);

                newAssetEntity.Tags.Add(newTagEntity);

                DbEntityEntry entry = Context.Entry<Asset>(newAssetEntity);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                {
                    Context.Entry<Asset>(newAssetEntity).State = System.Data.Entity.EntityState.Modified;
                    Context.SaveChanges();
                }
               
                //return ObjectMapper.Map<CourseModule, TModel>(newEntity);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        private Tag GetTagByName(string tagName)
        {
            Tag tagEntity = new Tag();

            try
            {
                tagEntity =
                    this.Context.Set<Tag>().Where(t => t.Name.Equals(tagName)).ToList<Tag>().FirstOrDefault<Tag>();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }

            return tagEntity;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Model.Entities.Tag> GetAllTags()
        {
            List<Model.Entities.Tag> tags = new List<Model.Entities.Tag>();
            try
            {
                tags = ObjectMapper.Map<Tag, Model.Entities.Tag>(this.Context.Set<Tag>().ToList<Tag>());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return tags;
        }
        
        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public override void Update(Model.Entities.Asset model)
        {
            if (model.Tags.Count() == 0)
            {
                base.Update(model);
            }
            else 
            {
                Asset updatedAsset = Context.Set<Asset>().Include("Tags").Where(a => a.Id.Equals(model.Id)).FirstOrDefault();
                ICollection<Tag> modelTags = new List<Tag>();
                modelTags = ObjectMapper.Map<Model.Entities.Tag, Tag>(model.Tags.ToList());
                Tag newTag = GetTagByName(modelTags.FirstOrDefault().Name);
                if (newTag == null)
                {
                    newTag = CreateNewTag(modelTags.FirstOrDefault());
                }                
                updatedAsset.Tags.Add(newTag);
                Model.Entities.Asset asset = ObjectMapper.Map<Asset, Model.Entities.Asset>(updatedAsset);
                Context.SaveChanges();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        private Tag CreateNewTag(Tag newTag)
        {
            //TContextEntity newEntity = ObjectMapper.Map<TModel, TContextEntity>(model);

            Tag newEntity = new Tag();
            newEntity.Name = newTag.Name;
            DbEntityEntry entry = Context.Entry<Tag>(newEntity);
            if (entry.State == System.Data.Entity.EntityState.Detached)
            {
                entry.State = System.Data.Entity.EntityState.Added;
                Context.SaveChanges();
            }

            return newEntity;
            //return ObjectMapper.Map<TContextEntity, TModel>(newEntity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public Model.Entities.Asset GetAssetByName(string assetName)
        {
            Model.Entities.Asset assetEntity = new Model.Entities.Asset();

            try
            {
                assetEntity =
                    ObjectMapper.Map<Asset, Model.Entities.Asset>(this.Context.Set<Asset>().Where(a => a.Name.Equals(assetName)).ToList<Asset>().FirstOrDefault<Asset>());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }

            return assetEntity;

        }
        
        #endregion
    }
}
