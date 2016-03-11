// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DisplayFilterViewModelFactory.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  DisplayFilterViewModelFactory class definition
//  Contains methods to build Display Filter View Models
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Cognite.Utility.Helpers.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Service.Models;

namespace UniEBoard.Service.Factories
{
    /// <summary>
    /// CourseViewModelFactory - Contains methods to build DisplayFilter View Models
    /// </summary>
    public static class DisplayFilterViewModelFactory
    {
        #region Methods

        /// <summary>
        /// Creates the display filter for tasks.
        /// </summary>
        /// <param name="action">The target action</param>
        /// <param name="controller">The target controller.</param>
        /// <param name="updateTargetId">The update target id.</param>
        /// <param name="displayFilter">The active display filter.</param>
        /// <returns></returns>
        public static DisplayFilterViewModel CreateTaskDisplayFilterViewModel(string action, string controller, string updateTargetId, TaskFilterType activeFilter = TaskFilterType.Active, string view = "")
        {
            DisplayFilterViewModel model = new DisplayFilterViewModel()
            {
                TargetActionName = action,
                TargetControllerName = controller,
                UpdateTargetId = updateTargetId,
                ActiveFilter = (int)activeFilter,
                DisplayLegend = "Show",
                Item1Display = EnumHelper.DiscriptionFor(TaskFilterType.All),
                Item2Display = EnumHelper.DiscriptionFor(TaskFilterType.Active),
                Item3Display = EnumHelper.DiscriptionFor(TaskFilterType.Completed),
                Item1Css = activeFilter == TaskFilterType.All ? "active" : string.Empty,
                Item2Css = activeFilter == TaskFilterType.Active ? "active" : string.Empty,
                Item3Css = activeFilter == TaskFilterType.Completed ? "active" : string.Empty,
                Item1Value = (int)TaskFilterType.All,
                Item2Value = (int)TaskFilterType.Active,
                Item3Value = (int)TaskFilterType.Completed,
                ViewType = view
            };
            return model;
        }

        /// <summary>
        /// Creates the assignment display filter view model.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="updateTargetId">The update target id.</param>
        /// <param name="activeFilter">The active filter.</param>
        /// <returns></returns>
        public static DisplayFilterViewModel CreateAssignmentDisplayFilterViewModel(string action, string controller, string updateTargetId, StudentAssignmentFilterType activeFilter = StudentAssignmentFilterType.Active)
        {
            DisplayFilterViewModel model = new DisplayFilterViewModel()
            {
                TargetActionName = action,
                TargetControllerName = controller,
                UpdateTargetId = updateTargetId,
                ActiveFilter = (int)activeFilter,
                DisplayLegend = "Show",
                Item1Display = EnumHelper.DiscriptionFor(StudentAssignmentFilterType.All),
                Item2Display = EnumHelper.DiscriptionFor(StudentAssignmentFilterType.Active),
                Item3Display = EnumHelper.DiscriptionFor(StudentAssignmentFilterType.Submitted),
                Item1Css = activeFilter == StudentAssignmentFilterType.All ? "active" : string.Empty,
                Item2Css = activeFilter == StudentAssignmentFilterType.Active ? "active" : string.Empty,
                Item3Css = activeFilter == StudentAssignmentFilterType.Submitted ? "active" : string.Empty,
                Item1Value = (int)StudentAssignmentFilterType.All,
                Item2Value = (int)StudentAssignmentFilterType.Active,
                Item3Value = (int)StudentAssignmentFilterType.Submitted
            };
            return model;
        }

        #endregion
    }
}
