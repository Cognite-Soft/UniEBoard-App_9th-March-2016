using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Service.Models
{
    public class CourseModuleViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets or sets the course_ id.
        /// </summary>
        /// <value>The course_ id.</value>
        public int Course_Id { get; set; }

        /// <summary>
        /// Gets or sets the module_ id.
        /// </summary>
        /// <value>The module_ id.</value>
        public int Module_Id { get; set; }

        /// <summary>
        /// Gets or sets the course.
        /// </summary>
        /// <value>The course.</value>
        public CourseViewModel Course { get; set; }

        /// <summary>
        /// Gets or sets the module.
        /// </summary>
        /// <value>The module.</value>
        public ModuleViewModel Module { get; set; }

    }
}
