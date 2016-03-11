// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PageViewAllFilterViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  PageViewAllFilterViewModel Model class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace UniEBoard.Service.Models
{
    /// <summary>
    //  PageViewAllFilterViewModel class definition
    /// </summary>
    public class PageViewAllFilterViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageViewAllFilterViewModel"/> class.
        /// </summary>
        public PageViewAllFilterViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageViewAllFilterViewModel"/> class.
        /// </summary>
        /// <param name="targetUrl">The target URL.</param>
        /// <param name="defaultSelectedFilter">The default selected filter.</param>
        public PageViewAllFilterViewModel(string targetUrl, int defaultSelectedFilter = 0)
        {
            SelectedFilter = defaultSelectedFilter;
            TargetUrl = targetUrl;
        }

        #region Properties

        /// <summary>
        /// Gets or sets the active filter.
        /// </summary>
        /// <value>The active filter.</value>
        public int SelectedFilter { get; set; }

        /// <summary>
        /// Gets or sets the target URL.
        /// </summary>
        /// <value>The target URL.</value>
        public string TargetUrl { get; set; }

        #endregion
    }
}
