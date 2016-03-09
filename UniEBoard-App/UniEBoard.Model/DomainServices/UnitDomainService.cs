// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Unit Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Factories;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Model.Interfaces.Repository;
using System.Linq.Expressions;

namespace UniEBoard.Model.DomainServices
{
    /// <summary>
    /// UnitDomainService class definition - Contains Methods for Unit Operations
    /// </summary>
    public class UnitDomainService : BaseDomainService<Unit, IUnitRepository>, IUnitDomainService
    {
        #region Properties

        /// <summary>
        /// StudentRepository instance
        /// </summary>
        public IUnitRepository UnitRepository;

        private IAssetDomainService AssetManager;


        #endregion

        #region Constructors

        /// <summary>
        /// Students the domain service.
        /// </summary>
        /// <param name="taskRepository">The task repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public UnitDomainService(IUnitRepository unitRepository, IAssetDomainService assetManager, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(unitRepository, exceptionManager, loggingService)
        {
            UnitRepository = unitRepository;
            AssetManager = assetManager;
        }

        #endregion

        #region Methods

            /// <summary>
        /// Get All units by course
        /// </summary>
        /// <param name="courseId">course id</param>
        /// <returns>list of units</returns>
        public List<Unit> GetUnitsModulesByCourse(int courseId)
        {
            List<Unit> units = new List<Unit>();
            try
            {
                units = UnitRepository.FindModulesUnitByCourse(courseId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return units;
        }

        /// <summary>
        /// Finds the units by staff id.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<Unit> FindUnitsByStaffId(int staffId, int view = 0)
        {
            List<Unit> units = new List<Unit>();

            try
            {
                units = UnitRepository.FindUnitsByStaffId(staffId, view);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }

            return units;
        }

        /// <summary>
        /// Finds the units by module id.
        /// </summary>
        /// <param name="staffId">The module id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<Unit> FindUnitsByModuleId(int moduleId, int view = 0)
        {
            List<Unit> units = new List<Unit>();
            try
            {
                units = UnitRepository.FindUnitsByModuleId(moduleId, view);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }

            return units;
        }

        /// <summary>
        /// Finds all units with modules included.
        /// </summary>
        /// <returns>List of all units with their modules included.</returns>
        public List<Unit> FindAll(List<string> associations)
        {
            List<Unit> units = new List<Unit>();
            try
            {
                units = UnitRepository.FindAll(associations).ToList();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }

            return units;
        }

        /// <summary>
        /// Reomves the video from unit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <param name="videoId">The video id.</param>
        /// <returns></returns>
        public bool ReomveVideoFromUnit(int unitId)
        {
           return  UnitRepository.RemoveVideoFromUnit(unitId);

        }

        /// <summary>
        /// Removes the assignment fromunit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <param name="assignmentId">The assignment id.</param>
        /// <returns></returns>
        public bool RemoveAssignmentFromunit(int unitId, int assignmentId)
        {

            return UnitRepository.RemoveAssignmentFromunit(unitId, assignmentId);
        }


        /// <summary>
        /// Removes the document from unit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <returns></returns>
        public bool RemoveDocumentFromUnit(int unitId)
        {
            return UnitRepository.RemoveDocumentFromUnit(unitId);
        }

        /// <summary>
        /// Removes the schedule fromunit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <param name="scheduleId">The schedule id.</param>
        /// <returns></returns>
        public bool RemoveScheduleFromunit(int unitId, int scheduleId)
        {
            return UnitRepository.RemoveScheduleFromunit(unitId,scheduleId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="asset"></param>
        public Unit AddAssetForUnit(string assetName, int unitId)
        {
            Unit model = new Unit();
            try
            {
                Asset asset = AssetManager.GetAssetByName(assetName);
                return UnitRepository.AddAssetForUnit(unitId, asset);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="asset"></param>
        public void RemoveAssetForUnit(Unit unit, Asset asset)
        {
            try
            {
                UnitRepository.RemoveAssetForUnit(unit, asset);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }


        #endregion
        
    }
}
