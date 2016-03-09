// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Course Operations
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

namespace UniEBoard.Model.DomainServices
{
    /// <summary>
    /// CourseDomainService class definition - Contains Methods for Course Operations
    /// </summary>
    public class ModuleDomainService : BaseDomainService<Module, IModuleRepository>, IModuleDomainService
    {
        #region Properties

        /// <summary>
        /// Module Repository Instance
        /// </summary>
        public IModuleRepository ModuleRepository;

        public ICourseModuleRepository CourseModuleRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="moduleDomainService"/> class.
        /// </summary>
        /// <param name="moduleRepository">The module repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public ModuleDomainService(IModuleRepository moduleRepository, ICourseModuleRepository courseModuleRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(moduleRepository, exceptionManager, loggingService)
        {
            ModuleRepository = moduleRepository;
            CourseModuleRepository = courseModuleRepository;
        }

        #endregion

        #region Methods

      
              /// <summary>
        /// Get the module by Id
        /// </summary>
        /// <param name="moduleId">The module Id</param>
        /// <returns>Module</returns>
        public Module FindModulebyId(int moduleId)
        {
            Module modules = new Module();
            try
            {
                modules = ModuleRepository.GetModuleById(moduleId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return modules;
        }

        /// <summary>
        /// Get Modules By Course Id
        /// </summary>
        /// <param name="courseId">Course Id.</param>
        /// <returns>List<Module></returns>
        public List<Module> GetModulesByCourse(int courseId)
        {
            List<Module> modules = new List<Module>();
            try
            {
                modules = ModuleRepository.GetModuleByCourseId(courseId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return modules;
        }

        /// <summary>
        /// Get moduleQuiz by moduleId. 
        /// </summary>
        /// <param name="moduleId">Module ID.</param>
        /// <returns>List<ModuleQuiz></returns>
        public List<ModuleQuiz> GetModulesQuizByModule(int moduleId)
        {
            List<ModuleQuiz> modulesQuiz = new List<ModuleQuiz>();
            try
            {
                modulesQuiz = ModuleRepository.GetModuleQuizByModuleId(moduleId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return modulesQuiz;
        }

        /// <summary>
        /// Remove Module From Course by moduleId. 
        /// </summary>
        /// <param name="moduleId">Module ID.</param>
        public void RemoveModuleFromCourse(int moduleId)
        {
            try
            {
                var CourseModuleList = CourseModuleRepository.FindAll().Where(x => x.Module_Id == moduleId);
                foreach (var courseModule in CourseModuleList)
                {
                    CourseModuleRepository.Remove(courseModule.Id);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
        }

        #endregion







       
    }
}
