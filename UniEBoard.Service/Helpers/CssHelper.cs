// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CssHelper.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Css Helper Methods with presentation logic
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;
using UniEBoard.Resource;

namespace UniEBoard.Service.Helpers
{
    /// <summary>
    /// CssHelper Class
    /// </summary>
    public static class CssHelper
    {
        /// <summary>
        /// Gets the CSS class for low priority labels.
        /// </summary>
        /// <param name="priority">The priority.</param>
        /// <returns></returns>
        public static string GetCssClassForLowPriorityLabels(int priority)
        {
            PriorityType priorityType = priority != 0 ? (PriorityType)priority :  PriorityType.None;
            switch (priorityType)
            {
                case PriorityType.High:
                    return ResourceCSSStyles.HighPriorityLablelCss;
                case PriorityType.Medium:
                    return ResourceCSSStyles.MediumPriorityLablelCss;
                case PriorityType.Low:
                    return ResourceCSSStyles.LowPriorityLabelCss;
                default:
                    return ResourceCSSStyles.NoPriorityLablelCss;
            }
        }

        /// <summary>
        /// Gets the CSS class for completed Tasks.
        /// </summary>
        /// <param name="priority">The task status.</param>
        /// <returns></returns>
        public static string GetCssClassForCompletedTasks(bool isCompleted)
        {
            return isCompleted ? ResourceCSSStyles.CompletedTasks : string.Empty;
        }

        /// <summary>
        /// Gets the CSS class for low priority labels.
        /// </summary>
        /// <param name="priority">The priority.</param>
        /// <returns></returns>
        public static string GetCssClassForQuestionStatus(QuestionTopicStatusType status)
        {
            switch (status)
            {
                case QuestionTopicStatusType.New:
                    return ResourceCSSStyles.StatusQuestionNew;
                case QuestionTopicStatusType.Updated:
                    return ResourceCSSStyles.StatusQuestionUpdated;
                case QuestionTopicStatusType.Answered:
                    return ResourceCSSStyles.StatusQuestionAnswered;
                case QuestionTopicStatusType.Closed:
                    return ResourceCSSStyles.StatusQuestionClosed;
                default:
                    return ResourceCSSStyles.StatusQuestionNew;
            }
        }

        /// <summary>
        /// Gets the CSS class for post not exsits.
        /// </summary>
        /// <returns></returns>
        public static string GetCssClassForPostNotExsits()
        {
            return ResourceCSSStyles.HideCSSClass;
        }
    }
}
