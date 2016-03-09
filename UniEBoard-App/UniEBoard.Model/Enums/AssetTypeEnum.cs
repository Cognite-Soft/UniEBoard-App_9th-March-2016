// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PriorityType.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  PriorityType Enum Type
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
    /// Priority Types
    /// </summary>
    public enum AssetTypeEnum
    {
        [DisplayAs("Video")]
        Video = 1,
        [DisplayAs("Document")]
        Document = 2,
        [DisplayAs("Image")]
        Image = 3,
        [DisplayAs("Web Page")]
        WebPage = 4
    }
}
