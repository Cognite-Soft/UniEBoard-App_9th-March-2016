// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Group.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Group class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// Group class definition
    /// </summary>
    public class Group : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the student number.
        /// </summary>
        /// <value>The student number.</value>
        public string StudentNumber { get; set; }

        /// <summary>
        /// Gets or sets the user groups.
        /// </summary>
        /// <value>The user groups.</value>
        public ICollection<UserGroup> UserGroups { get; set; }

        #endregion
    }
}
