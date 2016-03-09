// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScheduleNavigationalProperty.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  ScheduleNavigationalProperty Enum Type
//  Used to specify Schedule entity associations for eager loading
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Enums
{
    /// <summary>
    /// Schedule Navigational Property Types
    /// </summary>
    public enum ScheduleNavigationalProperty
    {
        Course,
        Unit,
        UnitAndModule
    }
}
