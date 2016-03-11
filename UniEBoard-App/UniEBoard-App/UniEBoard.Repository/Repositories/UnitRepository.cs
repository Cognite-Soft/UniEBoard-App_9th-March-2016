// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for Unit CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Entity;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.Repository;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Entities;
using System.Data.Entity.Infrastructure;

namespace UniEBoard.Repository.Repositories
{
    /// <summary>
    /// The Unit Repository Class
    /// </summary>
    public class UnitRepository : BaseRepository<UniEBoardDbContext, Repository.Unit, Model.Entities.Unit>, IUnitRepository
    {

        #region Properties
        /// <summary>
        /// Gets or sets the object video Repository.
        /// </summary>
        /// <value>The object video repository.</value>
        public IVideoRepository VideoRepository { get; set; }

        #endregion 
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        public UnitRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager, IVideoRepository videorepository)
            : base(objectMapper, exceptionManager)
        {
            VideoRepository = videorepository;
        }

        #endregion

        #region Properties
        #endregion
        #region Methods
        /// <summary>
        /// Finds the units by course.
        /// </summary>
        /// <param name="courseId">The unit id.</param>
        /// <returns></returns>
        public List<Model.Entities.Unit> FindModulesUnitByCourse(int courseId)
        {
            List<Model.Entities.Unit> UnitModelList = new List<Model.Entities.Unit>();
            try
            {

                IQueryable<Unit> unitQuery = from u in this.Context.Set<Unit>()
                                                     join m in this.Context.Set<Module>().Where(m => m.Course_Id.Equals(courseId)) on u.ModuleId equals m.Id
                                                     select u;
                unitQuery = IncludePropertyAssociations(unitQuery, new List<string>() { "Video", "Module","Document" });

        
                UnitModelList = ObjectMapper.Map<Unit, Model.Entities.Unit>(unitQuery.ToList());
               

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return UnitModelList;
        }

        /// <summary>
        /// Finds the units by staff id.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<Model.Entities.Unit> FindUnitsByStaffId(int staffId, int view = 0)
        {
            List<Model.Entities.Unit> unitModelList = new List<Model.Entities.Unit>();
            try
            {
                //IQueryable<Unit> unitQuery = this.Context.Set<Unit>().Where(p => p.CreatedByStaff.Id.Equals(staffId));

                IQueryable<Unit> unitQuery = from sc in this.Context.Set<StaffCourse>().Where(sc => sc.Staff_Id.Equals(staffId))
                                                 join c in this.Context.Set<Course>() on sc.Course_Id equals c.Id
                                                 join cm in this.Context.Set<CourseModule>() on c.Id equals cm.Course_Id
                                                 join m in this.Context.Set<Module>() on cm.Module_Id equals m.Id
                                                 join u in this.Context.Set<Unit>() on m.Id equals u.ModuleId
                                                 select u;

               unitQuery= unitQuery.Include(p => p.Video)
                    .Include(p => p.Document)
                    .Include(p => p.Assignments)
                    .Include(p => p.Schedules)
                    .Include(p => p.Module.CourseModules.Select(x => x.Course.Department)).Distinct();

               // handle no of results
               if (view != 0)
               {
                   unitQuery = unitQuery.Take(view);
               }

                unitModelList = ObjectMapper.Map<Unit, Model.Entities.Unit>(unitQuery.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return unitModelList;
        }

        /// <summary>
        /// Finds the units by staff id.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<Model.Entities.Unit> FindUnitsByModuleId(int moduleId, int view = 0)
        {
            List<Model.Entities.Unit> unitModelList = new List<Model.Entities.Unit>();
            try
            {
                //IQueryable<Unit> unitQuery = this.Context.Set<Unit>().Where(p => p.CreatedByStaff.Id.Equals(staffId));

                IQueryable<Unit> unitQuery = from sc in this.Context.Set<StaffCourse>()
                                             join c in this.Context.Set<Course>() on sc.Course_Id equals c.Id
                                             join cm in this.Context.Set<CourseModule>() on c.Id equals cm.Course_Id
                                             join m in this.Context.Set<Module>() on cm.Module_Id equals m.Id
                                             join u in this.Context.Set<Unit>() on m.Id equals u.ModuleId
                                             where u.ModuleId == moduleId
                                             select u;

                unitQuery = unitQuery.Include(p => p.Video)
                     .Include(p => p.Document)
                     .Include(p => p.Assignments)
                     .Include(p => p.Schedules)
                     .Include(p => p.Module.CourseModules.Select(x => x.Course.Department)).Distinct();

                // handle no of results
                if (view != 0)
                {
                    unitQuery = unitQuery.Take(view);
                }

                unitModelList = ObjectMapper.Map<Unit, Model.Entities.Unit>(unitQuery.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return unitModelList;
        }

        /// <summary>
        /// Finds the units by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Model.Entities.Unit FindUnitById(int id)
        {
            return ObjectMapper.Map<Unit, Model.Entities.Unit>(
                this.Context.Set<Unit>().FirstOrDefault(p => p.Id.Equals(id)));
        }

        /// <summary>
        /// Finds the units by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Model.Entities.Unit FindUnitById(int id, List<string> associations)
        {
            Unit unit = this.Context.Set<Unit>().Include(p => p.Assets).FirstOrDefault(p => p.Id.Equals(id));
            return ObjectMapper.Map<Unit, Model.Entities.Unit>(unit);
            /*IQueryable<Model.Entities.Unit> units = FindAll();
            associations.ForEach(s => units = units.Include(s));
            return units.Where(u => u.Id.Equals(id)).FirstOrDefault();*/
        }

        /// <summary>
        /// Removes the video from unit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <returns></returns>
        public bool RemoveVideoFromUnit(int unitId)
        {
            try
            {
                Unit unit = this.Context.Set<Unit>().Include(p => p.Video).FirstOrDefault(p => p.Id.Equals(unitId));
                unit.Video = null;
                Context.Entry(unit).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
                return false;
            }

        }

        /// <summary>
        /// Removes the assignment fromunit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <param name="assignmentId">The assignment id.</param>
        /// <returns></returns>
        public bool RemoveAssignmentFromunit(int unitId,int assignmentId)
        {
            try
            {
                Unit unit = this.Context.Set<Unit>().Include(p => p.Assignments).FirstOrDefault(p => p.Id.Equals(unitId));
                Assignment obj = this.Context.Set<Assignment>().FirstOrDefault(p => p.Id.Equals(assignmentId));
                if (obj == null)
                {
                    return false;
                }

                unit.Assignments.Remove(obj);
                Context.Entry(unit).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
                return false;
            }
        }


        /// <summary>
        /// Removes the document from unit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <returns></returns>
        public bool RemoveDocumentFromUnit(int unitId)
        {
            try
            {
                Unit unit = this.Context.Set<Unit>().Include(p => p.Document).FirstOrDefault(p => p.Id.Equals(unitId));
                unit.Document = null;
                Context.Entry(unit).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
                return false;
            }

        }


        /// <summary>
        /// Removes the schedule fromunit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <param name="scheduleId">The schedule id.</param>
        /// <returns></returns>
        public bool RemoveScheduleFromunit(int unitId, int scheduleId)
        {
            try
            {
                Unit unit = this.Context.Set<Unit>().Include(p => p.Schedules).FirstOrDefault(p => p.Id.Equals(unitId));

                Schedule obj = unit.Schedules.FirstOrDefault(p => p.Id.Equals(scheduleId));//this.Context.Set<Schedule>().FirstOrDefault(p => p.Id.Equals(scheduleId));
                if (obj == null)
                {
                    return false;
                }

                unit.Schedules.Remove(obj);
                Context.Entry(unit).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="asset"></param>
        public Model.Entities.Unit AddAssetForUnit(int unitId, Model.Entities.Asset asset)
        {               
            Unit unitEntity = this.Context.Set<Unit>().Include(u => u.Assets).FirstOrDefault(u => u.Id.Equals(unitId));         
            Asset assetEntity = Context.Set<Asset>().Find(asset.Id);
                    
            // if the unit already has the asset, return
            if (unitEntity.Assets.Contains(assetEntity)) { return default(Model.Entities.Unit); }

            //updating
            Context.Entry<Unit>(unitEntity).State = System.Data.Entity.EntityState.Modified;
            unitEntity.Assets.Add(assetEntity);
            Context.SaveChanges();
            return ObjectMapper.Map<Unit, Model.Entities.Unit>(unitEntity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="asset"></param>
        public void RemoveAssetForUnit(Model.Entities.Unit unit, Model.Entities.Asset asset)
        {
            Unit unitEntity = this.Context.Set<Unit>().Include(u => u.Assets).FirstOrDefault(u => u.Id.Equals(unit.Id));
            Asset assetEntity = Context.Set<Asset>().Find(ObjectMapper.GetEntityIdentifier<Model.Entities.Asset>(asset));

            unitEntity.Assets.Remove(assetEntity);
            Context.SaveChanges();
        }


        #endregion
    }
        
}
