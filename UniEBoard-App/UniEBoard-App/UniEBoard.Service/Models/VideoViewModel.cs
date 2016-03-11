using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace UniEBoard.Service.Models
{
    public class VideoViewModel : AssetViewModel
    {
        /// <summary>
        /// Gets or sets the alternate path.
        /// </summary>
        /// <value>The alternate path.</value>
        [Display(Name = "Alternate Path")]
        public string AlternatePath { get; set; }

        /// <summary>
        /// Gets or sets the type of the alternate content.
        /// </summary>
        /// <value>The type of the alternate content.</value>
        [Display(Name = "Alternate Content Type")]
        public string AlternateContentType { get; set; }
    }
}
