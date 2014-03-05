// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseModuleAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for all Units and module related operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Service.Interfaces.ApplicationService;
using UniEBoard.Service.Models;
using UniEBoard.Service.Factories;
using UniEBoard.Model.Adapters.Logging;
using UniEBoard.Service.Models.Courses;
using UniEBoard.Service.Models.Units;
using System.Web.Mvc;

namespace UniEBoard.Service.ApplicationServices
{
    /// <summary>
    /// Course And Module and unit Application Service Class - Contains Methods for all Course and module, unit related operations
    /// </summary>
    public class UnitModuleAppService : BaseAppService, IUnitModuleAppService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the unit manager.
        /// </summary>
        /// <value>The unit manager.</value>
        public IUnitDomainService UnitManager { get; set; }

        /// <summary>
        /// Gets or sets the unit manager.
        /// </summary>
        /// <value>The unit manager.</value>
        public IModuleDomainService ModuleManager { get; set; }

        /// <summary>
        /// Gets or sets the course manager.
        /// </summary>
        /// <value>The course manager.</value>
        public ICourseDomainService CourseManager { get; set; }

        /// <summary>
        /// Gets or sets the video manager.
        /// </summary>
        /// <value>The video manager.</value>
        public IVideoDomainService VideoManager { get; set; }

        /// <summary>
        /// Gets or sets the video manager.
        /// </summary>
        /// <value>The video manager.</value>
        public IFileDomainService FileManager { get; set; }

        public IQuizAppService _quizAppService { get; set; }

        public ICourseModuleAppService CourseModuleAppService { get; set; }



        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitModuleAppService"/> class.
        /// </summary>
        /// <param name="unitManager">The unit manager.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="cacheService">The cache service.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public UnitModuleAppService(
            IUnitDomainService unitManager,
            IModuleDomainService moduleManager,
            ICourseDomainService courseManager,
            IVideoDomainService videoManager,
             IFileDomainService fileManager,
            IObjectMapperAdapter objectMapper,
            ICacheAdapter cacheService,
            IExceptionManagerAdapter exceptionManager,
            ILoggingServiceAdapter loggingService,
            IQuizAppService quizAppService, ICourseModuleAppService courseModuleAppService)
            : base(objectMapper, cacheService, exceptionManager, loggingService)
        {
            this.UnitManager = unitManager;
            this.ModuleManager = moduleManager;
            this.CourseManager = courseManager;
            this.VideoManager = videoManager;
            this.FileManager = fileManager;
            this._quizAppService = quizAppService;
            this.CourseModuleAppService = courseModuleAppService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="includeModules"></param>
        /// <returns></returns>
        public List<UnitViewModel> GetUnitsByStudent(int studentId) {
            List<UnitViewModel> models = new List<UnitViewModel>();
            List<Unit> entities = new List<Unit>();
            List<string> associations = new List<string>();
            associations.Add("Assets");
            associations.Add("Module");
            associations.Add("Quiz");

            try
            {
                entities = (from m in CourseManager.GetModulesByStudent(studentId)
                            join u in UnitManager.FindAll(associations) on m.Id equals u.ModuleId
                            select u).ToList();
                models = setDuration(ObjectMapper.Map<Unit, UnitViewModel>(entities));
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }


        /// <summary>
        /// Get Units By course Id group by Module Id and Module Title. 
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public List<VideoLecturesViewModel> GetUnitsByCourse(int courseId)
        {
            List<UnitViewModel> models = new List<UnitViewModel>();
            List<VideoLecturesViewModel> videoLectures = new List<VideoLecturesViewModel>();
            try
            {
                List<Unit> units = UnitManager.GetUnitsModulesByCourse(courseId);
                models = ObjectMapper.Map<Model.Entities.Unit, UnitViewModel>(units);


                videoLectures = models.GroupBy(p => new { p.ModuleId, p.ModuleTitle})
                .Select(g => new VideoLecturesViewModel
                {
                    ModuleId = g.Key.ModuleId.ToString(),
                    ModuleTitle = g.Key.ModuleTitle.ToString(),
                    Units = g.Select(x => new UnitViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Description = x.Description,
                        PublishFrom = x.PublishFrom,
                        PublishTo = x.PublishTo,
                        StaffId = x.StaffId,
                        VideoId = x.VideoId.HasValue ? x.VideoId.Value : 0,
                        Video=x.Video,
                        DocumentId = x.DocumentId.HasValue ? x.DocumentId.Value : 0,
                        Document = x.Document,
                        QuizId = x.QuizId,
                        Quiz = _quizAppService.GetQuizById(x.QuizId.HasValue ? x.QuizId.Value : -1)
                    }).ToList()
                })
                .ToList();


                //videoLectures.ToList();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return videoLectures;
        }

        /// <summary>
        /// Finds the units by staff id.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        public List<ClassViewModel> FindClassesByStaffId(int staffId)
        {
            List<ClassViewModel> models = new List<ClassViewModel>();

            try
            {
                List<Unit> units = UnitManager.FindUnitsByStaffId(staffId);

                foreach (Unit unit in units)
                {
                    ClassViewModel obj=new ClassViewModel();
                    obj.Title = unit.Title;
                    obj.Id = unit.Id;
                    obj.VideoAssets = ObjectMapper.Map<Model.Entities.Video, VideoViewModel>(unit.Video);
                    obj.DocumentAssets = ObjectMapper.Map<Model.Entities.Document, DocumentViewModel>(unit.Document);
                    obj.ListAsignment = ObjectMapper.Map<Model.Entities.Assignment, AssignmentViewModel>(unit.Assignments);
                    obj.ListScheduleViewModel = ObjectMapper.Map<Model.Entities.Schedule, ScheduleViewModel>(unit.Schedules);
                    obj.DepartmentViewModel = ObjectMapper.Map<Model.Entities.Department, DepartmentViewModel>(unit.Module.CourseModules.Select(p=>p.Course.Department).ToList());
                    models.Add(obj);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }

            return models;
        }

        /// <summary>
        /// Finds the units for staff courses by staff id.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<UnitViewModel> FindUnitsByStaffId(int staffId, int view)
        {
            List<UnitViewModel> models = new List<UnitViewModel>();
            try
            {
                //Get questions by course
                List<Unit> units = UnitManager.FindUnitsByStaffId(staffId, view);
                models = ObjectMapper.Map<Model.Entities.Unit, UnitViewModel>(units);
                return models;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        public List<UnitViewModel> FindUnitsByModuleId(int moduleId, int view)
        {
            List<UnitViewModel> models = new List<UnitViewModel>();
            try
            {
                List<Unit> units = UnitManager.FindUnitsByModuleId(moduleId, view);
                models = ObjectMapper.Map<Model.Entities.Unit, UnitViewModel>(units);
                return models;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Reomves the video from unit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <returns></returns>
        public bool ReomveVideoFromUnit(int unitId)
        {
            return UnitManager.ReomveVideoFromUnit(unitId);
        }


        /// <summary>
        /// Removes the assignment fromunit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <param name="assignmentId">The assignment id.</param>
        /// <returns></returns>
        public bool DeleteAssignmentFromunit(int unitId, int assignmentId)
        {

            return UnitManager.RemoveAssignmentFromunit(unitId, assignmentId);
        }


        /// <summary>
        /// Removes the document from unit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <returns></returns>
        public bool DeleteDocumentFromUnit(int unitId)
        {
            return UnitManager.RemoveDocumentFromUnit(unitId);
        }

        /// <summary>
        /// Removes the schedule fromunit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <param name="scheduleId">The schedule id.</param>
        /// <returns></returns>
        public bool RemoveScheduleFromunit(int unitId, int scheduleId)
        {
            return UnitManager.RemoveScheduleFromunit(unitId, scheduleId);
        }

        /// <summary>
        /// Creates the unit.
        /// </summary>
        /// <param name="unitViewModel">The unit view model.</param>
        public bool CreateUnit(UnitViewModel unitViewModel)
        {
            try
            {
                if (unitViewModel != null)
                {
                    Unit unit = ObjectMapper.Map<UnitViewModel, Model.Entities.Unit>(unitViewModel);
                    unit = UnitManager.Add(unit);
                    return true;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return false;
        }

        /// <summary>
        /// Gets the unit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <returns></returns>
        public UnitViewModel GetUnit(int unitId)
        {
            UnitViewModel model = default(UnitViewModel);
            try
            {
                Unit unit = UnitManager.FindBy(unitId);
                model = ObjectMapper.Map<Model.Entities.Unit, UnitViewModel>(unit);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return model;
        }

        /// <summary>
        /// Updates the unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        public void UpdateUnit(UnitViewModel unitViewModel)
        {
            try
            {
                Unit unit = ObjectMapper.Map<UnitViewModel, Model.Entities.Unit>(unitViewModel);
                UnitManager.Update(unit);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        /// <summary>
        /// Returns a list of units assigned to and created by staff
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>List of UnitViewModels</returns>
        public List<UnitViewModel> GetUnitsForStaff(int userId)
        {
            List<UnitViewModel> models = new List<UnitViewModel>();
            List<Unit> entities = new List<Unit>();
            List<string> associations = new List<string>();
            associations.Add("Assets");
            associations.Add("Module");
            associations.Add("Quiz");

            try
            {
                entities = (from m in CourseModuleAppService.GetModulesForTeacher(userId)
                 join u in UnitManager.FindAll(associations) on m.Id equals u.ModuleId
                 select u).ToList();
                models = setDuration(ObjectMapper.Map<Unit, UnitViewModel>(entities));
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets the duration list i.e. 30 minutes, 1 hour, 1.5 hours, 2 hours, 2.5 hours, 3 hours, 3.5 hours etc..
        /// </summary>
        /// <value>The asset types.</value>
        public IEnumerable<SelectListItem> GetCourseDurations()
        {
            return new[]
            {
                new SelectListItem { Value = string.Format("{0}",1), Text = "30 Minutes"},
                new SelectListItem { Value = string.Format("{0}",2), Text = "1.0 Hour" },
                new SelectListItem { Value = string.Format("{0}",3), Text = "1.5 Hours" },
                new SelectListItem { Value = string.Format("{0}",4), Text = "2.0 Hours" },
                new SelectListItem { Value = string.Format("{0}",5), Text = "2.5 Hours" },
                new SelectListItem { Value = string.Format("{0}",6), Text = "3.0 Hours" },
                new SelectListItem { Value = string.Format("{0}",7), Text = "3.5 Hours" },
                new SelectListItem { Value = string.Format("{0}",8), Text = "4.0 Hours" },
                new SelectListItem { Value = string.Format("{0}",9), Text = "4.5 Hours" },
                new SelectListItem { Value = string.Format("{0}",10), Text = "5.0 Hours" },
                new SelectListItem { Value = string.Format("{0}",11), Text = "5.5 Hours" },
                new SelectListItem { Value = string.Format("{0}",12), Text = "6.0 Hours" }
            };
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        private List<UnitViewModel> setDuration(List<UnitViewModel> unitList)
        {
            List<UnitViewModel> unitListFormatted = new List<UnitViewModel>();
            foreach(var unit in unitList)
            {
                
                if (unit.Duration == 1)
                {
                    unit.DurationFormatted = "30 Minutes";
                }
                else if (unit.Duration == 2)
                {
                    unit.DurationFormatted = "1.0 Hour";
                }
                else
                {
                    unit.DurationFormatted = unit.Duration.ToString() + " Hours";
                }

                unit.DurationSelectedOption = Convert.ToInt32(unit.Duration);
                unitListFormatted.Add(unit);
            }

            return unitListFormatted;
        }

        private TimeSpan RoundUp(TimeSpan dt, TimeSpan d)
        {
            return new TimeSpan(((dt.Ticks + d.Ticks - 1) / d.Ticks) * d.Ticks);
        }

        #endregion

    }

  
}
