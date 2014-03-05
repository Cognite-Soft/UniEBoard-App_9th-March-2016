using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Model.Interfaces.Repository;

namespace UniEBoard.Model.DomainServices
{
    public class CourseRegistrationDomainService : BaseDomainService<CourseRegistration, ICourseRegistrationRepository>, ICourseRegistrationDomainService
    {
        #region Properties

        /// <summary>
        /// Course Repository Instance
        /// </summary>
        public ICourseRegistrationRepository CourseRegistrationRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseDomainService"/> class.
        /// </summary>
        /// <param name="courseRepository">The course repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public CourseRegistrationDomainService(ICourseRegistrationRepository courseRegistrationRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(courseRegistrationRepository, exceptionManager, loggingService)
        {
            CourseRegistrationRepository = courseRegistrationRepository;
        }

        #endregion

        #region methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        public List<CourseRegistration> CourseRegistrationsByTeacher(int teacherId)
        {

            List<CourseRegistration> courseRegistrations = new List<CourseRegistration>();
            try
            {
                courseRegistrations = CourseRegistrationRepository.CourseRegistrationsByTeacher(teacherId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            
            return courseRegistrations;
        }
        #endregion
    }
}
