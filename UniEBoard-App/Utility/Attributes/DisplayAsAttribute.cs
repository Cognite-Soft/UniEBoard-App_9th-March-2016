// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DisplayAsAttribute.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  DisplayAsAttribute Class Definition.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognite.Utility.Attributes
{
    /// <summary>
    /// Display Name attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public  sealed class DisplayAsAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayAsAttribute"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public DisplayAsAttribute(string name)
        {
            this.Name = name;
        }
    }
}
