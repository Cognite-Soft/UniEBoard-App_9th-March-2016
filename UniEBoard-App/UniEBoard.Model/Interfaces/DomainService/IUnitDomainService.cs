// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Task Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;

namespace UniEBoard.Model.Interfaces.DomainService
{
    /// <summary>
    /// ITaskDomainService Interface definition - Contains Methods for Task Operations
    /// </summary>
    public interface IUnitDomainService : IBaseDomainService<Unit>
    {
        /// <summary>
        /// Gets the units by user.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        List<Unit> GetUnitsModulesByCourse(int courseId);

        /// <summary>
        /// Finds the units by staff id.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<Unit> FindUnitsByStaffId(int staffId, int view = 0);

        /// <summary>
        /// Finds all units with modules included.
        /// </summary>
        /// <returns>List of all units with their modules included.</returns>
        List<Unit> FindAll(List<string> associations);

        /// <summary>
        /// Finds the units by module Id.
        /// </summary>
        /// <param name="staffId">The module id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<Unit> FindUnitsByModuleId(int moduleId, int view);

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
        bool RemoveAssignmentFromunit(int unitId, int assignmentId);


        /// <summary>
        /// Removes the document from unit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <returns></returns>
        bool RemoveDocumentFromUnit(int unitId);

        /// <summary>
        /// Removes the schedule fromunit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <param name="scheduleId">The schedule id.</param>
        /// <returns></returns>
        bool RemoveScheduleFromunit(int unitId, int scheduleId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="asset"></param>
        Unit AddAssetForUnit(string assetName, int unitId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="asset"></param>
        void RemoveAssetForUnit(Unit unit, Asset asset);


    }
}
