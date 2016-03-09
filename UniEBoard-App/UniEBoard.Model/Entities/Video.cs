// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Video.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Video class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// Video class definition
    /// </summary>
    public class Video : Asset
    {
        #region Properties

        /// <summary>
        /// Gets or sets the alternate path.
        /// </summary>
        /// <value>The alternate path.</value>
        public string AlternatePath { get; set; }

        /// <summary>
        /// Gets or sets the units.
        /// </summary>
        /// <value>The units.</value>
        public ICollection<Unit> Units { get; set; }
        
        #endregion
    }
}
