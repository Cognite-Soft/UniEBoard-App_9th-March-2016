// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VideoLecturesViewModel.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  VideoLecturesViewModel class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Service.Models.Courses
{
    /// <summary>
    //  VideoLecturesViewModel class definition
    /// </summary>
    public class VideoLecturesViewModel
    {

        #region properties
        /// <summary>
        /// Gets or sets the Module Id.
        /// </summary>
        /// <value>The Module Id.</value>
        public string ModuleId { get; set; }
       
        /// <summary>
        /// Gets or sets the Module Title.
        /// </summary>
        /// <value>The Module title.</value>
        public string ModuleTitle { get; set; }

        /// <summary>
        /// Gets or sets Listo of Units models
        /// </summary>
        /// <value>List of UnitViewModel</value>
        public ICollection<UnitViewModel> Units { get; set; }

        #endregion
    }
}
