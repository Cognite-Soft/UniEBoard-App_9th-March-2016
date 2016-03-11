// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageType.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  MessageType Enum Type
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
    /// Message Types
    /// </summary>
    public enum MessageType
    {
        [DisplayAs("Notification")]  
        Notification = 1,
        [DisplayAs("Question")]  
        Question = 2,
        [DisplayAs("Discussion")]  
        Discussion = 3,
        [DisplayAs("AssignmentAlert")]  
        Assignment = 4,
        [DisplayAs("Task")]  
        Task = 5,
        [DisplayAs("Message")]
        Message = 6
    }
}
