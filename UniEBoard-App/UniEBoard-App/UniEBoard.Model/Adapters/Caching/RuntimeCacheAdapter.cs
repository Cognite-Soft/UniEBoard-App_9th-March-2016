// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RuntimeCacheAdapter.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Caching using System.Runtime.Caching. Available to all .NET applications and not limited to Web App
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using UniEBoard.Model.Interfaces.Adapter;

namespace UniEBoard.Model.Adapters.Caching
{
    /// <summary>
    /// System Runtime Cache class
    /// </summary>
    public class RuntimeCacheAdapter : ICacheAdapter
    {
        #region Methods

        /// <summary>
        /// Removes an item from the cache using the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Remove(string key)
        {
            MemoryCache.Default.Remove(key);
        }

        /// <summary>
        /// Stores an item in the cache using the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="data">The data.</param>
        public void Store(string key, object data)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddDays(1);
            MemoryCache.Default.Add(new CacheItem(key, data), policy);
        }

        /// <summary>
        /// Retrieves an item from the cache using the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public T Retrieve<T>(string key)
        {
            CacheItem item = MemoryCache.Default.GetCacheItem(key);
            return (item != null && item.Value != null) ? (T)item.Value : default(T);
        }

        #endregion
    }
}
