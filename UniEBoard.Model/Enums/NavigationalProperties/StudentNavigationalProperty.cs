// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StudentNavigationalProperty.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  StudentNavigationalProperty Enum Type
//  Used to specify Student entity associations for eager loading
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Enums
{
    /// <summary>
    /// Student Navigational Property Types
    /// </summary>
    public enum StudentNavigationalProperty
    {
        Groups,
        Permissions,
        Tasks,
        CourseRegistrations,
        Alerts,
        Submissions,
        QuizEntries,
        Alerts_StudentViewedAlerts,
        Groups_Alerts_StudentViewedAlerts
    }
}
