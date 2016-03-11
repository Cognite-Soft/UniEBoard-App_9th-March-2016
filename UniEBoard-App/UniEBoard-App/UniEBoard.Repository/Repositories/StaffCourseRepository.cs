using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.Repository;

namespace UniEBoard.Repository.Repositories
{
    public class StaffCourseRepository : BaseRepository<UniEBoardDbContext, Repository.StaffCourse, Model.Entities.StaffCourse>, IStaffCourseRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        public StaffCourseRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        public bool RemoveStaffForCourse(int courseId)
        {
            try
            {
                var staffCourses = FindAll().Where(sc => sc.Course_Id.Equals(courseId));
                foreach (var staffCourse in staffCourses)
                {
                    Remove(staffCourse);
                }
                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return false;
        }
    }
}
