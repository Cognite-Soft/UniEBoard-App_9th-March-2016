// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenderType.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  GenderType Enum Type
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
    /// Gender Types
    /// </summary>
    public enum GenderType
    {
        [DisplayAs("Not Specified")]  
        NotSpecified = 1,
        [DisplayAs("Male")]  
        Male = 2,
        [DisplayAs("Female")]  
        Female = 3
    }
}
