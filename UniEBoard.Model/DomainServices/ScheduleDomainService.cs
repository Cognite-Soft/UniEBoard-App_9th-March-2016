// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScheduleDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Schedule Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using UniEBoard.Model.Builders;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Factories;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Model.Interfaces.Repository;

namespace UniEBoard.Model.DomainServices
{
    /// <summary>
    /// ScheduleDomainService class definition - Contains Methods for Schedule Operations
    /// </summary>
    public class ScheduleDomainService : BaseDomainService<Schedule, IScheduleRepository>, IScheduleDomainService
    {
        #region Properties

        /// <summary>
        /// Schedule Repository Instance
        /// </summary>
        public IScheduleRepository ScheduleRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleDomainService"/> class.
        /// </summary>
        /// <param name="ScheduleRepository">The Schedule repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public ScheduleDomainService(IScheduleRepository scheduleRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(scheduleRepository, exceptionManager, loggingService)
        {
            ScheduleRepository = scheduleRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the schedules with units and modules by course.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        public List<Schedule> GetSchedulesWithUnitsAndModulesByCourse(int courseId)
        {
            List<Schedule> scheduleList = new List<Schedule>();
            try
            {
                scheduleList = ScheduleRepository.FindSchedulesByCourse(courseId, GetpropertyAssociations<C.NavigationalProperties.Schedule>(u => u.Course, u => u.Unit, u => u.UnitAndModule));
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return scheduleList;
        }

        /// <summary>
        /// Gets the schedules with units and modules by student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <returns></returns>
        public List<Schedule> GetSchedulesWithUnitsAndModulesByStudent(int studentId)
        {
            List<Schedule> scheduleList = new List<Schedule>();
            try
            {
                scheduleList = ScheduleRepository.FindSchedulesByStudent(studentId, GetpropertyAssociations<C.NavigationalProperties.Schedule>(u => u.Course, u => u.Unit, u => u.UnitAndModule));
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return scheduleList;
        }

        #endregion
    }
}
