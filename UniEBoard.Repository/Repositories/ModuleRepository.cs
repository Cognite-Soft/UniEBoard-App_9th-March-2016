// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for Course Repository CRUD operations.
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
using System.Data.Entity.Infrastructure;

namespace UniEBoard.Repository.Repositories
{
    /// <summary>
    /// The Course Repository Class
    /// </summary>
    public class ModuleRepository : BaseRepository<UniEBoardDbContext, Repository.Module, Model.Entities.Module>, IModuleRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        public ModuleRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public override Model.Entities.Module Add(Model.Entities.Module model)
        {
            Module newModuleEntity = ObjectMapper.Map<Model.Entities.Module, Module>(model);
            
            //Adding Course Module to the Module
            ICollection<CourseModule> courseModules = new List<CourseModule>();
            CourseModule newCourseModuleEntity = new CourseModule();
            newCourseModuleEntity.Course_Id = model.Course_Id;
            courseModules.Add(newCourseModuleEntity);
            newModuleEntity.CourseModules = courseModules;
            //-----------
            
            DbEntityEntry entry = Context.Entry<Module>(newModuleEntity);
            if (entry.State == System.Data.Entity.EntityState.Detached)
            {
                Context.Entry<Module>(newModuleEntity).State = System.Data.Entity.EntityState.Added;
                Context.SaveChanges();
            }
            return ObjectMapper.Map<Module, Model.Entities.Module>(newModuleEntity);
        }

        /// <summary>
        /// Get module By Id
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns>Module</returns>
        public Model.Entities.Module GetModuleById(int moduleId)
        {
            Model.Entities.Module modulelist = new Model.Entities.Module();
            try
            {
                IQueryable<Module> courses = from cr in this.Context.Set<Module>().Where(cr => cr.Id == moduleId)
                                             select cr;

                Module moduleEntityList = courses.ToList().FirstOrDefault();

                // Return Courses
                modulelist = ObjectMapper.Map<Module, Model.Entities.Module>(moduleEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return modulelist;
        }

        /// <summary>
        /// Get modules By course Id
        /// </summary>
        /// <param name="courseId">course Id.</param>
        /// <returns>List<Model.Entities.Module></returns>
        public List<Model.Entities.Module> GetModuleByCourseId(int courseId)
        {
            List<Model.Entities.Module> modulelist = new  List<Model.Entities.Module>();
            try
            {
                IQueryable<Module> modules = from cr in this.Context.Set<Module>().Where(cr => cr.Course_Id == courseId)
                                             select cr;

                List<Module> moduleEntityList = modules.ToList();


                modulelist = ObjectMapper.Map<Module, Model.Entities.Module>(moduleEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return modulelist;
        }

        /// <summary>
        /// Get modules By course Id
        /// </summary>
        /// <param name="courseId">course Id.</param>
        /// <returns>List<Model.Entities.Module></returns>
        public List<Model.Entities.Module> GetModulesAndQuizzesByCourseAndStudent(int studentId, int courseId)
        {
            List<Model.Entities.Module> modulelist = new List<Model.Entities.Module>();
            try
            {
                IQueryable<Module> modules = from m in this.Context.Set<Module>()
                                             join cm in this.Context.Set<CourseModule>() on m.Id equals cm.Module_Id
                                             where(cm.Course_Id == courseId)
                                             select m;

                List<Module> moduleEntityList = modules
                                                .Distinct()
                                                .Include("ModuleQuizs")
                                                .Include("ModuleQuizs.Quiz")
                                                .Include("ModuleQuizs.Quiz.QuizEntries")
                                                .Select(m => m)
                                                .ToList();

                modulelist = ObjectMapper.Map<Module, Model.Entities.Module>(moduleEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return modulelist;
        }


        /// <summary>
        /// Get ModuleQuiz By module Id
        /// </summary>
        /// <param name="moduleId">module Id.</param>
        /// <returns>List<Model.Entities.ModuleQuiz></returns>
        public List<Model.Entities.ModuleQuiz> GetModuleQuizByModuleId(int moduleId)
        {
            List<Model.Entities.ModuleQuiz> modulelist = new List<Model.Entities.ModuleQuiz>();
            try
            {
                IQueryable<ModuleQuiz> modules = from cr in this.Context.Set<ModuleQuiz>().Where(cr => cr.ModuleId == moduleId)
                                             select cr;

                List<ModuleQuiz> moduleEntityList = modules.ToList();


                modulelist = ObjectMapper.Map<ModuleQuiz, Model.Entities.ModuleQuiz>(moduleEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return modulelist;
        }

        /// <summary>
        /// Gets the modules by teacher.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <returns></returns>
        public List<Model.Entities.Module> GetModulesByTeacher(int teacherId, int view = 0)
        {
            List<Model.Entities.Module> modulelist = new List<Model.Entities.Module>();
            try
            {
                // Select Quizzes
                IQueryable<Module> moduleQuery = from sc in this.Context.Set<StaffCourse>().Where(sc => sc.Staff_Id.Equals(teacherId))
                                              join c in this.Context.Set<Course>() on sc.Course_Id equals c.Id
                                              join cm in this.Context.Set<CourseModule>() on c.Id equals cm.Course_Id
                                              join m in this.Context.Set<Module>() on cm.Module_Id equals m.Id
                                              select m;
                moduleQuery = moduleQuery.Include("CourseModules")
                    .Include("CourseModules.Course")
                    .Include("CourseModules.Course.CourseRegistrations")
                    .Include("CourseModules.Course.CourseRegistrations.Student")
                    .Include("Assignments");
                
                if (view != 0)
                {
                    moduleQuery = moduleQuery.Include("CourseModules").Include("CourseModules.Course").Take(view);
                }
                else
                {
                    moduleQuery = moduleQuery.Include("CourseModules").Include("CourseModules.Course");
                }
                
                List<Module> moduleList = moduleQuery.ToList();


                modulelist = ObjectMapper.Map<Module, Model.Entities.Module>(moduleList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return modulelist;
        }

        /// <summary>
        /// Gets the modules by student.
        /// </summary>
        /// <param name="teacherId">The student id.</param>
        /// <returns></returns>
        public List<Model.Entities.Module> GetModulesByStudent(int studentId, int view = 0)
        {
            List<Model.Entities.Module> modulelist = new List<Model.Entities.Module>();
            try
            {
                // Select Quizzes
                IQueryable<Module> moduleQuery = from cr in this.Context.Set<CourseRegistration>().Where(cr => cr.Student_Id.Equals(studentId))
                                                 join c in this.Context.Set<Course>() on cr.Course_Id equals c.Id
                                                 join cm in this.Context.Set<CourseModule>() on c.Id equals cm.Course_Id
                                                 join m in this.Context.Set<Module>() on cm.Module_Id equals m.Id
                                                 select m;
                moduleQuery = moduleQuery.Include("CourseModules")
                    .Include("CourseModules.Course")
                    .Include("CourseModules.Course.CourseRegistrations")
                    .Include("CourseModules.Course.CourseRegistrations.Student")
                    .Include("Assignments");

                if (view != 0)
                {
                    moduleQuery = moduleQuery.Include("CourseModules").Include("CourseModules.Course").Take(view);
                }
                else
                {
                    moduleQuery = moduleQuery.Include("CourseModules").Include("CourseModules.Course");
                }

                List<Module> moduleList = moduleQuery.ToList();


                modulelist = ObjectMapper.Map<Module, Model.Entities.Module>(moduleList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return modulelist;
        }

        /// <summary>
        /// Gets the modules created by teacher.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <returns></returns>
        public List<Model.Entities.Module> GetModulesCreatedByTeacher(int teacherId, int view = 0)
        {
            List<Model.Entities.Module> modulelist = new List<Model.Entities.Module>();
            try
            {
                // Select Quizzes
                IQueryable<Module> moduleQuery = from m in this.Context.Set<Module>()
                                                 where m.CreatedByStaff_Id.Equals(teacherId)
                                                 select m;
                moduleQuery = moduleQuery.Include("CourseModules");
                moduleQuery = moduleQuery.Include("CourseModules.Course");
                if (view != 0)
                {
                    moduleQuery = moduleQuery.Take(view);
                }

                List<Module> moduleList = moduleQuery.ToList();


                modulelist = ObjectMapper.Map<Module, Model.Entities.Module>(moduleList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return modulelist;
        }

        #endregion
    }
}
