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
    public enum QuestionQuizType
    {
        [DisplayAs("Multiple Choice")]
        MultipleSelection = 1,
        [DisplayAs("Single Choice")]
        SingleSelection = 2,
        [DisplayAs("Free Text")]
        FreeText = 3
    }
}
