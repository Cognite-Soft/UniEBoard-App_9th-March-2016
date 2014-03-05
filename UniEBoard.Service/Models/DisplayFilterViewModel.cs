// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DisplayFilterViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Display FilterView Model class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UniEBoard.Service.Models
{
    /// <summary>
    //  DisplayFilterViewModel class definition
    /// </summary>
    public class DisplayFilterViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the active filter.
        /// </summary>
        /// <value>The active filter.</value>
        public int ActiveFilter { get; set; }

        /// <summary>
        /// Gets or sets the TargetAction
        /// </summary>
        /// <value>The TargetAction value.</value>
        public string TargetActionName { get; set; }

        /// <summary>
        /// Gets or sets the TargetController
        /// </summary>
        /// <value>The TargetController value.</value>
        public string TargetControllerName { get; set; }

        /// <summary>
        /// Gets or sets the UpdateTargetId
        /// </summary>
        /// <value>The UpdateTargetId value.</value>
        public string UpdateTargetId { get; set; }

        /// <summary>
        /// Gets or sets the DisplayLegend
        /// </summary>
        /// <value>The DisplayLegend value.</value>
        public string DisplayLegend { get; set; }

        /// <summary>
        /// Gets or sets the ViewType e.g. student, teacher or admin
        /// </summary>
        public string ViewType { get; set; }

        /// <summary>
        /// Gets or sets the Item 1 value
        /// </summary>
        /// <value>The Item 1 value.</value>
        public string Item1Display { get; set; }

        /// <summary>
        /// Gets or sets the Item 2 value
        /// </summary>
        /// <value>The Item 2 value.</value>
        public string Item2Display { get; set; }

        /// <summary>
        /// Gets or sets the Item 3 value
        /// </summary>
        /// <value>The Item 3 value.</value>
        public string Item3Display { get; set; }

        /// <summary>
        /// Gets or sets the Item 1 Css value
        /// </summary>
        /// <value>The Item 1 Css value.</value>
        public string Item1Css { get; set; }

        /// <summary>
        /// Gets or sets the Item 2 Css value
        /// </summary>
        /// <value>The Item 2 Css value.</value>
        public string Item2Css { get; set; }

        /// <summary>
        /// Gets or sets the Item 3 Css value
        /// </summary>
        /// <value>The Item 3 Css value.</value>
        public string Item3Css { get; set; }

        /// <summary>
        /// Gets or sets the Item 1 value
        /// </summary>
        /// <value>The Item 1 value.</value>
        public int Item1Value { get; set; }

        /// <summary>
        /// Gets or sets the Item 2 Css value
        /// </summary>
        /// <value>The Item 2 Css value.</value>
        public int Item2Value { get; set; }

        /// <summary>
        /// Gets or sets the Item 3 value
        /// </summary>
        /// <value>The Item 3 value.</value>
        public int Item3Value { get; set; }

        #endregion
    }
}
