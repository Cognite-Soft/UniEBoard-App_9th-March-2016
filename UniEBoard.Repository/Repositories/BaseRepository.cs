// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Base methods for Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.Repository;
using System.Linq.Expressions;
using UniEBoard.Model.Entities;

namespace UniEBoard.Repository.Repositories
{
    /// <summary>
    /// The Base Repository Class
    /// </summary>
    /// <typeparam name="TDbContext">The type of the db context.</typeparam>
    /// <typeparam name="TContextEntity">The type of the context entity.</typeparam>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public abstract class BaseRepository<TDbContext, TContextEntity, TModel> : IBaseRepository<TModel>
        where TDbContext : DbContext, new()
        where TContextEntity : class
        where TModel : class
    {
        #region Members
        
        /// <summary>
        /// Instance of the DbContext
        /// </summary>
        private TDbContext _context;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the object mapper.
        /// </summary>
        /// <value>The object mapper.</value>
        public IObjectMapperAdapter ObjectMapper { get; set; }

        /// <summary>
        /// Gets or sets the exception manager.
        /// </summary>
        /// <value>The exception manager.</value>
        public IExceptionManagerAdapter ExceptionManager { get; set; }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        public virtual TDbContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new TDbContext();
                }
                return _context;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository&lt;TDbContext, TContextEntity, TModel&gt;"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        public BaseRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
        {
            this.ObjectMapper = objectMapper;
            this.ExceptionManager = exceptionManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual TModel Add(TModel model)
        {
            TContextEntity newEntity = ObjectMapper.Map<TModel, TContextEntity>(model);
            DbEntityEntry entry = Context.Entry<TContextEntity>(newEntity);
            if (entry.State == System.Data.Entity.EntityState.Detached)
            {
                entry.State = System.Data.Entity.EntityState.Added;
                Context.SaveChanges();
            }
            return ObjectMapper.Map<TContextEntity, TModel>(newEntity);
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public virtual void Update(TModel model)
        {
            // Detach existing Entity
            TContextEntity existingEntity = Context.Set<TContextEntity>().Find(ObjectMapper.GetEntityIdentifier<TModel>(model));
            System.Data.Entity.EntityState existingState = Context.Entry<TContextEntity>(existingEntity).State;
            if (existingState != System.Data.Entity.EntityState.Detached)
            {
                Context.Entry<TContextEntity>(existingEntity).State = System.Data.Entity.EntityState.Detached;
            }

            TContextEntity updatedEntity = ObjectMapper.Map<TModel, TContextEntity>(model);
            DbEntityEntry entry = Context.Entry<TContextEntity>(updatedEntity);
            if (entry.State == System.Data.Entity.EntityState.Detached)
            {
                //Context.Set<TContextEntity>().Attach(updatedEntity);
                entry.State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
            }       
        }

        /// <summary>
        /// Removes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Remove(TModel model)
        {
            TContextEntity entity = Context.Set<TContextEntity>().Find(ObjectMapper.GetEntityIdentifier<TModel>(model));
            Context.Set<TContextEntity>().Remove(entity);
            Context.SaveChanges();
        }

        /// <summary>
        /// Removes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        public void Remove(int id)
        {
            TContextEntity entity = Context.Set<TContextEntity>().Find(id);
            Context.Set<TContextEntity>().Remove(entity);
            Context.SaveChanges();
        }

        /// <summary>
        /// Finds by the specified Id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public virtual TModel FindBy(int id)
        {
            TContextEntity entity = Context.Set<TContextEntity>().Find(id);
            return ObjectMapper.Map<TContextEntity, TModel>(entity);
        }

        /// <summary>
        /// Finds by the specified Id and includes their associations.
        /// This method is used for selective eager loading when lazy loading is off.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <param name="includeAssociations">The include associations.</param>
        /// <returns></returns>
        public virtual TModel FindBy(int objectId, List<string> includeAssociations)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds by the specified Id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="includeAssociations">The include associations.</param>
        /// <returns></returns>
        public virtual TModel FindBy(Expression<Func<TModel, bool>> predicate, List<string> includeAssociations)
        {
            DbQuery<TContextEntity> dbSet = Context.Set<TContextEntity>();
            if (dbSet != null)
            {
                includeAssociations.ForEach(p => dbSet = dbSet.Include(p));
            }
            ObjectMapper.CreateMap<Expression<Func<TModel, bool>>, Expression<Func<TContextEntity, bool>>>();
            Expression<Func<TContextEntity, bool>> pred = ObjectMapper.Map<Expression<Func<TModel, bool>>, Expression<Func<TContextEntity, bool>>>(predicate);
            TContextEntity entity = dbSet.FirstOrDefault(pred);
            return ObjectMapper.Map<TContextEntity, TModel>(entity);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns></returns>
        /// public IQueryable<TModel> FindAll(Expression<Func<TContextEntity, bool>> predicate = null)
        public virtual IQueryable<TModel> FindAll()
        {
            DbSet dbSet = Context.Set<TContextEntity>();
            return GetEntitiesInDbSet(dbSet);
        }

        /// <summary>
        /// Finds all entities.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public IQueryable<TModel> FindAll<T>(Expression<Func<T, bool>> predicate)
        {
            ///Context.Set<TContextEntity>().Where(predicate.);


            //IQueryable dbSet = Context.Set<TContextEntity>();
            //IQueryable<Student> students = this.Context.Set<Student>().AsQueryable().Where(predicate);
            //DbSet dbSet = Context.Set<TContextEntity>()
            //.Where(predicate);
            return null;
        }

        /// <summary>
        /// Finds all models and includes their associations
        /// This method is used for selective eager loading when lazy loading is off.
        /// </summary>
        /// <param name="includeAssociations">The include associations. I.e Navigational property names</param>
        /// <returns></returns>
        //public IQueryable<TModel> FindAll(List<string> includeAssociations, Expression<Func<TContextEntity, bool>> predicate = null)
        public IQueryable<TModel> FindAll(List<string> includeAssociations)
        {
            IQueryable dbSet = Context.Set<TContextEntity>();
            if (dbSet != null)
            {
                includeAssociations.ForEach(p => dbSet = dbSet.Include(p));
            }
            return GetEntitiesInDbSet(dbSet);
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return Context.Set<TContextEntity>().Count();
        }

        /// <summary>
        /// Includes the property associations.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="includeAssociations">The include associations.</param>
        protected IQueryable<TContextEntity> IncludePropertyAssociations(IQueryable<TContextEntity> query, List<string> includeAssociations)
        {
            includeAssociations.ForEach(p => query = query.Include(p));
            return query;
        }

        /// <summary>
        /// Gets the entities in db set.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        protected IQueryable<TModel> GetEntitiesInDbSet(IQueryable query)
        {
            IList<TModel> models = new List<TModel>();
            if (query != null)
            {
                foreach (TContextEntity entity in query)
                {
                    var model = ObjectMapper.Map<TContextEntity, TModel>(entity);
                    models.Add(model);
                }
            }
            return models.AsQueryable();
        }

        /// <summary>
        /// Reload the data from datastore into the context.
        /// </summary>
        /// <param name="entity">entity id</param>
        /// 
        [Obsolete]
        public void RemoveRefresh(int id)
        {
            TDbContext context = new TDbContext();
            DbSet dbSet = context.Set<TContextEntity>();
            TContextEntity entity = dbSet.Find(id) as TContextEntity;
            context.Set<TContextEntity>().Remove(entity);
            context.SaveChanges();
            //Context.Entry<TContextEntity>(entity).Reload();
        }

        #endregion

    }
}
