using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;

namespace UniEBoard.Model.Interfaces.Repository
{
    public interface ICourseRegistrationRepository : IBaseRepository<CourseRegistration>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        List<CourseRegistration> CourseRegistrationsByTeacher(int teacherId);
    }
}
