using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;

namespace UniEBoard.Model.Interfaces.Repository
{
    public interface IStaffCourseRepository : IBaseRepository<StaffCourse>
    {
        bool RemoveStaffForCourse(int courseId);
    }
}
