// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for Task Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Repository;
using UniEBoard.Model.Interfaces.Adapter;

namespace UniEBoard.Repository.Repositories
{
    /// <summary>
    /// The Task Repository Class
    /// </summary>
    public class QuizRepository : BaseRepository<UniEBoardDbContext, Repository.Quiz, Model.Entities.Quiz>, IQuizRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        public QuizRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Finds the active Quiz by module.
        /// </summary>
        /// <param name="moduleId">The module id.</param>
        /// <returns></returns>
        public List<Model.Entities.Quiz> FindQuizzesByModule(int moduleId)
        {
            List<Model.Entities.Quiz> quizModelList = new List<Model.Entities.Quiz>();
            try
            {
                // Fetch Active Tasks
                IQueryable<Quiz> quizzes = from modQ in this.Context.Set<ModuleQuiz>().Where(modQ => modQ.ModuleId == moduleId)
                                           join q in this.Context.Set<Quiz>() on modQ.QuizId equals q.Id
                                           where q.PublishFrom < DateTime.Now 
                                           && q.PublishTo > DateTime.Now
                                           select q;
                List<Quiz> quizEntityList = quizzes.ToList();


                // Return Tasks
                quizModelList = ObjectMapper.Map<Quiz, Model.Entities.Quiz>(quizEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return quizModelList;
        }

        /// <summary>
        /// Finds the quizzes for teacher courses.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<Model.Entities.Quiz> FindQuizzesForTeacherCourses(int teacherId, int view)
        {
            List<Model.Entities.Quiz> quizList = new List<Model.Entities.Quiz>();
            try
            {
                // Select Quizzes
                IQueryable<Quiz> quizzForTeacherModuleQuery = from sc in this.Context.Set<StaffCourse>().Where(sc => sc.Staff_Id == teacherId)
                                           join c in this.Context.Set<Course>() on sc.Course_Id equals c.Id
                                           join cm in this.Context.Set<CourseModule>() on c.Id equals cm.Course_Id
                                           join m in this.Context.Set<Module>() on cm.Module_Id equals m.Id
                                           join mq in this.Context.Set<ModuleQuiz>() on m.Id equals mq.ModuleId
                                           join q in this.Context.Set<Quiz>() on mq.QuizId equals q.Id
                                           select q;
                IQueryable<Quiz> quizzForModuleCreatedByTeacher = from m in this.Context.Set<Module>().Where(m => m.CreatedByStaff_Id.Equals(teacherId))
                                                                  join mq in this.Context.Set<ModuleQuiz>() on m.Id equals mq.ModuleId
                                                                  join q in this.Context.Set<Quiz>() on mq.QuizId equals q.Id
                                                                  select q;
                quizzForTeacherModuleQuery = quizzForTeacherModuleQuery.Union(quizzForModuleCreatedByTeacher);
                // Ensure No Duplicates
                quizzForTeacherModuleQuery = quizzForTeacherModuleQuery.Distinct();
                quizzForTeacherModuleQuery = IncludePropertyAssociations(quizzForTeacherModuleQuery, new List<string> { "ModuleQuizs", "ModuleQuizs.Module" });

                // handle no of results
                if (view != 0)
                {
                    quizzForTeacherModuleQuery = quizzForTeacherModuleQuery.Take(view);
                }

                // Return Quizzes
                quizList = ObjectMapper.Map<Quiz, Model.Entities.Quiz>(quizzForTeacherModuleQuery.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return quizList;

        }

        /// <summary>
        /// Finds the quizzes for teacher courses.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<Model.Entities.Quiz> FindQuizzesForTeacherCourses(int teacherId, string filter)
        {
            List<Model.Entities.Quiz> quizList = new List<Model.Entities.Quiz>();

            try
            {
                IQueryable<Quiz> quizzForTeacherModuleQuery;
                IQueryable<Quiz> quizzForModuleCreatedByTeacher;

                if (String.IsNullOrEmpty(filter))
                {
                    // Select Quizzes
                    quizzForTeacherModuleQuery =
                        from sc in this.Context.Set<StaffCourse>()
                        .Where(sc => sc.Staff_Id == teacherId)
                        join c in this.Context.Set<Course>() on sc.Course_Id equals c.Id
                        join cm in this.Context.Set<CourseModule>() on c.Id equals cm.Course_Id
                        join m in this.Context.Set<Module>() on cm.Module_Id equals m.Id
                        join mq in this.Context.Set<ModuleQuiz>() on m.Id equals mq.ModuleId
                        join q in this.Context.Set<Quiz>() on mq.QuizId equals q.Id
                        select q;

                    quizzForModuleCreatedByTeacher =
                        from m in this.Context.Set<Module>().Where(m => m.CreatedByStaff_Id.Equals(teacherId))
                        join mq in this.Context.Set<ModuleQuiz>() on m.Id equals mq.ModuleId
                        join q in this.Context.Set<Quiz>() on mq.QuizId equals q.Id
                        select q;

                }
                else 
                {
                    // Select Quizzes
                    quizzForTeacherModuleQuery =
                        from sc in this.Context.Set<StaffCourse>()
                        .Where(sc => sc.Staff_Id == teacherId)
                        join c in this.Context.Set<Course>() on sc.Course_Id equals c.Id
                        join cm in this.Context.Set<CourseModule>() on c.Id equals cm.Course_Id
                        join m in this.Context.Set<Module>() on cm.Module_Id equals m.Id
                        join mq in this.Context.Set<ModuleQuiz>() on m.Id equals mq.ModuleId
                        join q in this.Context.Set<Quiz>().Where(q => q.Title.ToLower().Contains(filter.ToLower()))
                            on mq.QuizId equals q.Id
                        select q;

                    quizzForModuleCreatedByTeacher =
                        from m in this.Context.Set<Module>().Where(m => m.CreatedByStaff_Id.Equals(teacherId))
                        join mq in this.Context.Set<ModuleQuiz>() on m.Id equals mq.ModuleId
                        join q in this.Context.Set<Quiz>().Where(q => q.Title.ToLower().Contains(filter.ToLower()))
                            on mq.QuizId equals q.Id
                        select q;
                }
                
                
                
                quizzForTeacherModuleQuery = quizzForTeacherModuleQuery.Union(quizzForModuleCreatedByTeacher);
                // Ensure No Duplicates
                quizzForTeacherModuleQuery = quizzForTeacherModuleQuery.Distinct();
                quizzForTeacherModuleQuery = IncludePropertyAssociations(quizzForTeacherModuleQuery, new List<string> { "ModuleQuizs", "ModuleQuizs.Module" });

               
                // Return Quizzes
                quizList = ObjectMapper.Map<Quiz, Model.Entities.Quiz>(quizzForTeacherModuleQuery.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }

            return quizList;
        }
       

        #endregion

       
    }
}
