// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScheduleRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for Schedule Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Repository;
using UniEBoard.Model.Interfaces.Adapter;
using System.Data.Entity;
using System.Data.Objects.DataClasses;

namespace UniEBoard.Repository.Repositories
{
    /// <summary>
    /// The Schedule Repository Class
    /// </summary>
    public class ScheduleRepository : BaseRepository<UniEBoardDbContext, Repository.Schedule, Model.Entities.Schedule>, IScheduleRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        public ScheduleRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Finds the schedules by course.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <param name="includeAssociations"></param>
        /// <returns></returns>
        public List<Model.Entities.Schedule> FindSchedulesByCourse(int courseId,  List<string> includeAssociations)
        {
            List<Model.Entities.Schedule> ScheduleList = new List<Model.Entities.Schedule>();
            try
            {
                IQueryable<Schedule> scheduleQuery = Context.Set<Schedule>().Where(s => s.CourseId.Equals(courseId));
                scheduleQuery = IncludePropertyAssociations(scheduleQuery, includeAssociations);
                List<Schedule> ScheduleEntityList = scheduleQuery.ToList();

                // Return Schedules
                ScheduleList = ObjectMapper.Map<Schedule, Model.Entities.Schedule>(ScheduleEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return ScheduleList;
        }

        /// <summary>
        /// Finds the schedules by student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="includeAssociations">The include associations.</param>
        /// <returns></returns>
        public List<Model.Entities.Schedule> FindSchedulesByStudent(int studentId, List<string> includeAssociations)
        {
            List<Model.Entities.Schedule> ScheduleList = new List<Model.Entities.Schedule>();
            try
            {
                IQueryable<Schedule> scheduleQuery = from sc in this.Context.Set<Schedule>()
                                                     join cr in this.Context.Set<CourseRegistration>().Where(cr => cr.Student_Id.Equals(studentId)) on sc.CourseId equals cr.Course_Id
                                                     select sc;
                scheduleQuery = IncludePropertyAssociations(scheduleQuery, includeAssociations);

                List<Schedule> ScheduleEntityList = scheduleQuery.ToList();

                // Return Schedules
                ScheduleList = ObjectMapper.Map<Schedule, Model.Entities.Schedule>(ScheduleEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return ScheduleList;
        }

        #endregion
    }
}
