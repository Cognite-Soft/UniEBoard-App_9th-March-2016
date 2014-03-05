// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HttpContextCacheAdapter.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Null Object Cache. I.e No Caching Special Case/Null Pattern 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Interfaces.Adapter;

namespace UniEBoard.Model.Adapters.Caching
{
    /// <summary>
    /// Null Caching class
    /// </summary>
    public class NullObjectCacheAdapter : ICacheAdapter
    {
        #region Methods

        /// <summary>
        /// Does not remove an item from the cache using the specified key.
        /// Method has no implementation.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Remove(string key)
        {
            // Do nothing
        }

        /// <summary>
        /// Does not Store an item in the cache using the specified key.
        /// Method has no implementation.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="data">The data.</param>
        public void Store(string key, object data)
        {
            // Do nothing
        }

        /// <summary>
        /// Retrieves default(T)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public T Retrieve<T>(string storageKey)
        {
            return default(T);
        }

        #endregion
    }
}
