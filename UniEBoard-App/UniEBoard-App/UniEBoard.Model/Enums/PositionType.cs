// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PositionType.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  PositionType Enum Type
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
    /// Position Types
    /// </summary>
    public enum PositionType
    {
        [DisplayAs("Not Specified")]  
        NotSpecified = 1,
        [DisplayAs("Lecturer")]  
        Lecturer = 2,
        [DisplayAs("Professor")]  
        Professor = 3,
        [DisplayAs("Administrator")]  
        Admin = 4
    }
}
