// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for Unit Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;


namespace UniEBoard.Model.Interfaces.Repository
{
    /// <summary>
    /// The Course Repository Interface
    /// </summary>
    public interface IUnitRepository : IBaseRepository<Unit>
    {

        /// <summary>
        /// Finds the units in a course.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        List<Model.Entities.Unit> FindModulesUnitByCourse(int courseId);


        /// <summary>
        /// Finds the units by staff id.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<Model.Entities.Unit> FindUnitsByStaffId(int staffId, int view = 0);

        /// <summary>
        /// Finds the units by module id.
        /// </summary>
        /// <param name="staffId">The module id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<Model.Entities.Unit> FindUnitsByModuleId(int moduleId, int view = 0);

        /// <summary>
        /// Finds the unit by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        Model.Entities.Unit FindUnitById(int id);

        /// <summary>
        /// Finds the unit by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        Model.Entities.Unit FindUnitById(int id, List<string> associations);

        /// <summary>
        /// Removes the video from unit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <returns></returns>
        bool RemoveVideoFromUnit(int unitId);


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
        Unit AddAssetForUnit(int unitId, Asset asset);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="asset"></param>
        void RemoveAssetForUnit(Unit unit, Asset asset);

    }
}
