// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICacheAdapter.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for Caching operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Interfaces.Adapter
{
    /// <summary>
    /// The Cache Adapter Interface
    /// </summary>
    public interface ICacheAdapter
    {
        /// <summary>
        /// Removes an item from the cache using the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        void Remove(string key);

        /// <summary>
        /// Stores an item in the cache using the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="data">The data.</param>
        void Store(string key, object data);

        /// <summary>
        /// Retrieves an item from the cache using the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        T Retrieve<T>(string key);
    }
}
