// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseEntity.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  BaseEntity abstract base class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// The Base Entity Class
    /// </summary>
    public abstract class BaseEntity
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntity"/> class.
        /// </summary>
        public BaseEntity()
        {
            DateCreated = DateTime.Now;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>The date created.</value>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the publish from.
        /// </summary>
        /// <value>The publish from.</value>
        public DateTime? PublishFrom { get; set; }

        /// <summary>
        /// Gets or sets the publish to.
        /// </summary>
        /// <value>The publish to.</value>
        public DateTime? PublishTo { get; set; }

        #endregion
    }
}
