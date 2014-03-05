// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccreditationType.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  AccreditationType Enum Type
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
    /// Accreditation Types
    /// </summary>
    public enum AccreditationType
    {
        [DisplayAs("NotSpecified")]  
        NotSpecified = 1,
        [DisplayAs("PhD")]  
        PhD = 2,
        [DisplayAs("Masters")]  
        Masters = 3,
        [DisplayAs("Undergraduate")]  
        Undergraduate = 4
    }
}
