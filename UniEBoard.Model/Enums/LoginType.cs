// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginType.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  LoginType Enum Type
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
    /// Login Types
    /// </summary>
    public enum LoginType
    {
        [DisplayAs("Student")]  
        Student = 1,
        [DisplayAs("Teacher")] 
        Teacher = 2,
        [DisplayAs("Administrator")]
        Administrator = 3
    }
}
