// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HttpContextCacheAdapter.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Caching using System.Web.HttpContext
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using UniEBoard.Model.Interfaces.Adapter;

namespace UniEBoard.Model.Adapters.Caching
{
    /// <summary>
    /// HttpContext Cache class
    /// </summary>
    public class HttpContextCacheAdapter : ICacheAdapter
    {
        #region Methods

        /// <summary>
        /// Removes an item from the cache using the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Remove(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }

        /// <summary>
        /// Stores an item in the cache using the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="data">The data.</param>
        public void Store(string key, object data)
        {
            HttpContext.Current.Cache.Insert(key, data);
        }

        /// <summary>
        /// Retrieves an item from the cache using the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public T Retrieve<T>(string key)
        {
            T item = (T)HttpContext.Current.Cache.Get(key);
            return item;
        }

        #endregion
    }
}
