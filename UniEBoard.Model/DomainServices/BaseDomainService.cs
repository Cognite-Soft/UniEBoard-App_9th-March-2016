// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Base Service Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq.Expressions;
using Cognite.Utility.Helpers.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Builders;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Model.Interfaces.Repository;

namespace UniEBoard.Model.DomainServices
{
    /// <summary>
    /// BaseDomainService abstract class definition - Contains Methods for Base Service Operations
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TRepository">The type of the repository.</typeparam>
    public abstract class BaseDomainService<TModel, TRepository> : IBaseDomainService<TModel>
        where TModel : class
        where TRepository : IBaseRepository<TModel>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the entity repository.
        /// </summary>
        /// <value>The entity repository.</value>
        protected TRepository EntityRepository { get; set; }

        /// <summary>
        /// Gets or sets the exception manager.
        /// </summary>
        /// <value>The exception manager.</value>
        public IExceptionManagerAdapter ExceptionManager { get; set; }

        /// <summary>
        /// Gets or sets the event log service.
        /// </summary>
        /// <value>The event log service.</value>
        public ILoggingServiceAdapter LoggingService { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDomainService&lt;TModel, TRepository&gt;"/> class.
        /// </summary>
        /// <param name="entityRepository">The entity repository.</param>
        public BaseDomainService(TRepository entityRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
        {
            this.EntityRepository = entityRepository;
            this.ExceptionManager = exceptionManager;
            this.LoggingService = loggingService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Finds all <typeparamref name="TModel"/>  models.
        /// </summary>
        /// <returns></returns>
        public List<TModel> FindAll()
        {
            List<TModel> modelList = new List<TModel>();
            try
            {
                modelList = this.EntityRepository.FindAll().ToList<TModel>();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return modelList;
        }

        /// <summary>
        /// Finds <typeparamref name="TModel"/> the by  entity Id
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        /// <returns></returns>
        public virtual TModel FindBy(int entityId)
        {
            TModel model = default(TModel);
            try
            {
                model = this.EntityRepository.FindBy(entityId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return model;
        }

        /// <summary>
        /// Finds the entity by id including association.
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        /// <returns>Entity</returns>
        public TModel FindBy(int entityId, List<string> associations)
        {
            TModel model = default(TModel);
            try
            {
                model = this.EntityRepository.FindBy(entityId, associations);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return model;
        }

        /// <summary>
        /// Finds the entity by id including association.
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        /// <returns>Entity</returns>
        public TModel FindBy(Expression<Func<TModel, bool>> predicate, List<string> associations)
        {
            TModel model = default(TModel);
            try
            {
                model = this.EntityRepository.FindBy(predicate, associations);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return model;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(TModel entity)
        {
            try
            {
                this.EntityRepository.Update(entity);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual TModel Add(TModel entity)
        {
            TModel model = default(TModel);
            try
            {
                model = this.EntityRepository.Add(entity);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return model;
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(TModel entity)
        {
            try
            {
                this.EntityRepository.Remove(entity);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
        }

        /// <summary>
        /// Removes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        public void Remove(int id)
        {
            try
            {
                this.EntityRepository.Remove(id);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
        }


        /// <summary>
        /// Gets the dictionary values of enum.
        /// </summary>
        /// <typeparam name="TEnumType">The type of the enum type.</typeparam>
        /// <returns></returns>
        public Dictionary<int, string> GetDictionaryValuesOfEnum<TEnumType>()
        {
            Dictionary<int, string> enumDictionary = new Dictionary<int, string>();
            try
            {
                enumDictionary = EnumHelper.DictionaryOf<TEnumType>();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return enumDictionary;
        }

        /// <summary>
        /// Get navigational properties associations.
        /// </summary>
        /// <returns></returns>
        public List<string> GetpropertyAssociations<T>(params Expression<Func<T, string>>[] associationExpressions) where T : C.NavigationalProperties.BaseNavigationalProperty, new()
        {
            PropertyAssociationBuilder<T> builder = null;
            try
            {
                builder = new PropertyAssociationBuilder<T>(associationExpressions);
            }
            catch (Exception)
            {
            }
            return builder != null ? builder.BuildAssociation() : new List<string>();
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            try
            {
                return this.EntityRepository.Count();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
                return 0;
            }
        }

        #endregion


        IQueryable<TModel> IBaseDomainService<TModel>.FindAll(List<string> associations)
        {
            return this.EntityRepository.FindAll(associations);
        }
    }
}
