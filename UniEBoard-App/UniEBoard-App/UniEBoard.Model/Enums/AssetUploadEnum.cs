// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssetUploadEnum.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  AssetUpload Enum Type
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognite.Utility.Attributes;

namespace UniEBoard.Model.Enums
{
    /// <summary>
    /// Asset Upload Types
    /// </summary>
    public enum AssetUploadEnum
    {
        [DisplayAs("Web Url")]
        Web = 1,
        [DisplayAs("File Upload")]
        File = 2,
    }
}
