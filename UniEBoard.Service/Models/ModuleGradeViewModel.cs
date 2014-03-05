using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Service.Models
{
    public class ModuleGradeViewModel : BaseViewModel
    {

        #region Properties

        /// <summary>
        /// Gets or sets the module.
        /// </summary>
        /// <value>The module.</value>
        public ModuleViewModel Module { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Grade { get; set; }

        #endregion

    }
}
