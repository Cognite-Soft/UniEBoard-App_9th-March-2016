// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StudentAssignmentFilterType.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Student Assignment Filter Enum Type
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Cognite.Utility.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Enums
{
    /// <summary>
    /// Student Assignment Filter Types
    /// </summary>
    public enum StudentAssignmentFilterType
    {
        [DisplayAs("All")]
        All = 1,
        [DisplayAs("Active")]
        Active = 2,
        [DisplayAs("Submitted")]
        Submitted = 3
    }
}
