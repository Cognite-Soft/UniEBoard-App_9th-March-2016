// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubmissionStatusType.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Submission Status Enum Type
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
    /// Submission Status Types
    /// </summary>
    public enum SubmissionStatusType
    {
        [DisplayAs("New")]  
        New = 1,
        [DisplayAs("Submitted")] 
        Submitted = 2,
        [DisplayAs("Pending")] 
        Pending = 3
    }
}
