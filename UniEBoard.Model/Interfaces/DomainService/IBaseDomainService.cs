// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBaseDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interfcae Methods for Base Service Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using UniEBoard.Model.Interfaces.Adapter;

namespace UniEBoard.Model.Interfaces.DomainService
{
    /// <summary>
    /// IBaseDomainService interface class definition - Contains Methods for Base Service Operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseDomainService<T>
    {
        /// <summary>
        /// Gets or sets the event log service.
        /// </summary>
        /// <value>
        /// The event log service.
        /// </value>
        ILoggingServiceAdapter LoggingService { get; set; }

        /// <summary>
        /// Gets or sets the exception manager.
        /// </summary>
        /// <value>The exception manager.</value>
        IExceptionManagerAdapter ExceptionManager { get; set; }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        T Add(T entity);
        
        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Remove(T entity);

        /// <summary>
        /// Removes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        void Remove(int id);

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns></returns>
        List<T> FindAll();

        /// <summary>
        /// Finds all units with modules included.
        /// </summary>
        /// <returns>List of all units with their modules included.</returns>
        IQueryable<T> FindAll(List<string> associations);

        /// <summary>
        /// Finds the by.
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        /// <returns></returns>
        T FindBy(int entityId);

        /// <summary>
        /// Finds the entity by id including association.
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        /// <returns>Entity</returns>
        T FindBy(int entityId, List<string> associations);

        /// <summary>
        /// Finds the entity by id including association.
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        /// <returns>Entity</returns>
        T FindBy(Expression<Func<T, bool>> predicate, List<string> associations);

        /// <summary>
        /// Gets the dictionary values of enum.
        /// </summary>
        /// <typeparam name="TEnumType">The type of the enum type.</typeparam>
        /// <returns></returns>
        Dictionary<int, string> GetDictionaryValuesOfEnum<TEnumType>();

        /// <summary>
        /// Getproperties the associations.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="associationExpressions">The association expressions.</param>
        /// <returns></returns>
        List<string> GetpropertyAssociations<T>(params Expression<Func<T, string>>[] associationExpressions)
            where T : C.NavigationalProperties.BaseNavigationalProperty, new();

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <returns></returns>
        int GetCount();
    }
}
