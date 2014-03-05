using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Entities
{
    public class ModuleGrade : BaseEntity
    {

        #region Properties
        
        /// <summary>
        /// Gets or sets the module.
        /// </summary>
        /// <value>The module.</value>
        public Module Module { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Grade { get; set; }
        
        #endregion
    }
}
