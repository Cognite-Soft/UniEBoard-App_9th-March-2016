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
    public enum PriorityType
    {
        [DisplayAs("High")]
        High = 1,
        [DisplayAs("Medium")]
        Medium = 2,
        [DisplayAs("Low")]
        Low = 3,
        [DisplayAs("None")]
        None = 4
    }
}
