// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitModuleAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for all Unit and modules related operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Service.Models;
using UniEBoard.Service.Models.Courses;
using UniEBoard.Service.Models.Units;

namespace UniEBoard.Service.Interfaces.ApplicationService
{
    /// <summary>
    /// IUnitModuleAppService Interface - Contains Methods for all Unit and module related operations
    /// </summary>
    public interface IUnitModuleAppService : IBaseAppService
    {
        /// <summary>
        /// Gets or sets the unit manager.
        /// </summary>
        /// <value>The unit manager.</value>
        IUnitDomainService UnitManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        List<UnitViewModel> GetUnitsByStudent(int studentId);

        /// <summary>
        /// Gets all units modules by course.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        List<VideoLecturesViewModel> GetUnitsByCourse(int courseId);

        /// <summary>
        /// Finds the units by staff id.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        /// <returns></returns>
        List<ClassViewModel> FindClassesByStaffId(int staffId);

        /// <summary>
        /// Finds the units for staff courses by staff id.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<UnitViewModel> FindUnitsByStaffId(int staffId, int view);

        /// <summary>
        /// Finds the units by module Id.
        /// </summary>
        /// <param name="staffId">The module id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<UnitViewModel> FindUnitsByModuleId(int moduleId, int view);

        /// <summary>
        /// Reomves the video from unit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <returns></returns>
        bool ReomveVideoFromUnit(int unitId);

        /// <summary>
        /// Removes the assignment fromunit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <param name="assignmentId">The assignment id.</param>
        /// <returns></returns>
        bool DeleteAssignmentFromunit(int unitId, int assignmentId);


        /// <summary>
        /// Removes the document from unit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <returns></returns>
        bool DeleteDocumentFromUnit(int unitId);

        /// <summary>
        /// Removes the schedule fromunit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <param name="scheduleId">The schedule id.</param>
        /// <returns></returns>
        bool RemoveScheduleFromunit(int unitId, int scheduleId);

        /// <summary>
        /// Creates the unit.
        /// </summary>
        /// <param name="unitViewModel">The unit view model.</param>
        bool CreateUnit(UnitViewModel unitViewModel);

        /// <summary>
        /// Gets the unit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <returns></returns>
        UnitViewModel GetUnit(int unitId);

        /// <summary>
        /// Updates the unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        void UpdateUnit(UnitViewModel unitViewModel);

        /// <summary>
        /// Returns a list of units assigned to and created by staff
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>List of UnitViewModels</returns>
        List<UnitViewModel> GetUnitsForStaff(int userId);

        /// <summary>
        /// Gets the duration list i.e. 30 minutes, 1 hour, 1.5 hours, 2 hours, 2.5 hours, 3 hours, 3.5 hours etc..
        /// </summary>
        /// <value>The asset types.</value>
        IEnumerable<SelectListItem> GetCourseDurations();
    }
}
