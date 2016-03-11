// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Asset.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Asset class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;
using Io = System.IO;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// Asset class definition
    /// </summary>
    public class Asset : BaseEntity
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Asset"/> class.
        /// </summary>
        public Asset()
        {
            IdentityToken = Guid.NewGuid();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the asset.
        /// </summary>
        /// <value>The type of the asset.</value>
        public AssetTypeEnum AssetType { get; set; }

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>The file path.</value>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        /// <value>The type of the content.</value>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the company id.
        /// </summary>
        /// <value>The company id.</value>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>The tags.</value>
        public ICollection<Tag> Tags { get; set; }

        /// <summary>
        /// Gets or sets the Units.
        /// </summary>
        /// <value>The tags.</value>
        public ICollection<Unit> Units1 { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>The company.</value>
        public Company Company { get; set; }

        /// <summary>
        /// Gets or sets the identity token.
        /// </summary>
        /// <value>The identity token.</value>
        public Guid IdentityToken { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is web URL.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is web URL; otherwise, <c>false</c>.
        /// </value>
        public bool IsWebUrl
        {
            get
            {
                string path = Path.ToLower();
                return path.StartsWith("http") || path.StartsWith("www") ? true : false;
            }
        }

        /// <summary>
        /// Gets the type of the asset.
        /// </summary>
        /// <value>The type of the asset.</value>
        public string AssetTypeName
        {
            get
            {
                switch (AssetType)
                {
                    case AssetTypeEnum.Video:
                        return "Video";
                    case AssetTypeEnum.Document:
                        return "Document";
                    case AssetTypeEnum.Image:
                        return "Image";
                    default:
                        return "Asset";
                }
            }
        }

        /// <summary>
        /// Gets the asset format.
        /// </summary>
        /// <value>The asset format.</value>
        public string AssetExtension
        {
            get
            {
                if (IsWebUrl) { return "url"; }
                return Io.Path.GetExtension(Path);
            }
        }

        #endregion
    }
}
