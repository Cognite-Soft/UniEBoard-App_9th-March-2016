// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskFilterType.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Task Filter Enum Type
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
    /// Task Filter Types
    /// </summary>
    public enum TaskFilterType
    {
        [DisplayAs("All")]
        All = 1,
        [DisplayAs("Active")]
        Active = 2,
        [DisplayAs("Completed")]
        Completed = 3,
        [DisplayAs("Upcoming Deadlines")]
        ActiveWithDeadlines = 4
    }
}
