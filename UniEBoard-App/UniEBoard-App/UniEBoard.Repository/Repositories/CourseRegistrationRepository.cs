using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.Repository;

namespace UniEBoard.Repository.Repositories
{
    public class CourseRegistrationRepository : 
        BaseRepository<UniEBoardDbContext, Repository.CourseRegistration, Model.Entities.CourseRegistration>, ICourseRegistrationRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        public CourseRegistrationRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion
        
        #region methods
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        public List<Model.Entities.CourseRegistration> CourseRegistrationsByTeacher(int teacherId)
        {
            List<Model.Entities.CourseRegistration> courseRegistrationsEntities = new List<Model.Entities.CourseRegistration>();

            try 
            {
                IQueryable<CourseRegistration> courseRegistrations = from c in this.Context.Set<Course>()
                                                                     join sc in this.Context.Set<StaffCourse>() 
                                                                        on c.Id equals sc.Staff_Id
                                                                        where sc.Staff_Id == teacherId
                                                                     join cr in this.Context.Set<CourseRegistration>()
                                                                        on c.Id equals cr.Course_Id
                                                                     select cr;

                courseRegistrationsEntities = ObjectMapper.Map<CourseRegistration, Model.Entities.CourseRegistration>(courseRegistrations.ToList());
            }

            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }

            return courseRegistrationsEntities;
        }
        #endregion

    }
}
