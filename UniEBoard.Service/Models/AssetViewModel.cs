using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UniEBoard.Service.Models
{
    public class AssetViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets or sets the identity token.
        /// </summary>
        /// <value>The identity token.</value>
        [Display(Name = "IdentityToken")]
        public Guid IdentityToken { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Display(Name = "Name")]
        [AllowHtml]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the asset.
        /// </summary>
        /// <value>The type of the asset.</value>
        [Display(Name = "Asset Type")]
        [Required(ErrorMessage = "{0} is required.")]
        public int AssetType { get; set; }

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>The file path.</value>
        [Display(Name = "Asset Path")]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the company id.
        /// </summary>
        /// <value>The company id.</value>
        [Display(Name = "Company Id")]
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        /// <value>The type of the content.</value>
        [Display(Name = "Content Type")]
        [AllowHtml]
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is web URL.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is web URL; otherwise, <c>false</c>.
        /// </value>
        [Display(Name = "Is Web Url")]
        public bool IsWebUrl { get; set; }

        /// <summary>
        /// Gets the type of the asset.
        /// </summary>
        /// <value>The type of the asset.</value>
        [Display(Name = "Type")]
        public string AssetTypeName { get; set; }

        /// <summary>
        /// Gets the asset format.
        /// </summary>
        /// <value>The asset format.</value>
        [Display(Name = "Format")]
        public string AssetExtension { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>The tags.</value>
        public ICollection<TagViewModel> Tags { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>The tags.</value>
        public ICollection<UnitViewModel> Units1 { get; set; }
    }
}
