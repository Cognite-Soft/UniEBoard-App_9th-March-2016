// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestionTopicStatusType.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  QuestionTopicStatusType Enum Type
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Cognite.Utility.Attributes;

namespace UniEBoard.Model.Enums
{
    /// <summary>
    /// QuestionTopicStatus Types
    /// </summary>
    public enum QuestionTopicStatusType
    {
        [DisplayAs("New")]  
        New = 1,
        [DisplayAs("Updated")]  
        Updated = 2,
        [DisplayAs("Answered")]  
        Answered = 3,
        [DisplayAs("Closed")]  
        Closed = 4
    }
}
