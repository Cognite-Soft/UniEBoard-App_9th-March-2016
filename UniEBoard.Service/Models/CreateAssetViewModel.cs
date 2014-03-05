// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateAssetViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  CreateAssetViewModel class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UniEBoard.Service.Helpers;

namespace UniEBoard.Service.Models
{
    /// <summary>
    //  CreateAssetViewModel class definition
    /// </summary>
    public class CreateAssetViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the instructions.
        /// </summary>
        /// <value>The instructions.</value>
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        [Required(ErrorMessage="Asset Name is required")]
        [AllowHtml]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the asset.
        /// </summary>
        /// <value>The type of the asset.</value>
        [Display(Name = "Asset Format")]
        [Required(ErrorMessage = "Asset Type is required")]
        public int AssetType { get; set; }

        /// <summary>
        /// Gets or sets the type of the asset.
        /// </summary>
        /// <value>The type of the asset.</value>
        [Display(Name = "CompanyId")]
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>The file path.</value>
        [Display(Name = "Asset Path")]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the file to upload.
        /// </summary>
        /// <value>The file to upload.</value>
        [Display(Name = "File Upload")]
        public HttpPostedFileBase UploadFile { get; set; }

        /// <summary>
        /// Gets or sets the file to upload.
        /// </summary>
        /// <value>The file to upload.</value>
        [Display(Name = "Optional Alternate Upload")]
        public HttpPostedFileBase AlternateUploadFile { get; set; }

        #endregion
    }
}
