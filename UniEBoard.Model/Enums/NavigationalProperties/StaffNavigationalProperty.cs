// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaffNavigationalProperty.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  StaffNavigationalProperty Enum Type
//  Used to specify Staff entity associations for eager loading
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Enums
{
    /// <summary>
    /// Staff Navigational Property Types
    /// </summary>
    public enum StaffNavigationalProperty
    {
        Groups,
        Permissions,
        Tasks,
        Department,
        StaffCourses,
        Modules,
        Units,
        Alerts
    }
}

