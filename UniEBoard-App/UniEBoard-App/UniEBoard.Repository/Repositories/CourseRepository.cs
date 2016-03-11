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
    public class CourseRepository : BaseRepository<UniEBoardDbContext, Repository.Course, Model.Entities.Course>, ICourseRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        public CourseRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Finds the courses with modules by student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <returns></returns>
        public List<Model.Entities.Course> FindCoursesWithModulesByStudent(int studentId)
        {
            List<Model.Entities.Course> courseList = new List<Model.Entities.Course>();
            try
            {
                IQueryable<Asset> assets = this.Context.Set<Asset>();
                IQueryable<Course> courses = 
                    from cr in this.Context.Set<CourseRegistration>().Where(cr => cr.Student_Id == studentId)
                                             join c in this.Context.Set<Course>() on cr.Course_Id equals c.Id
                                             select c;
                //courses = courses.Include("CourseModules").Include("CourseModules.Module").Include("CourseModules.Module.Units").Include("CourseModules.Module.Units.Quiz").Include("CourseModules.Module.Units.Assets");
                courses = courses.Include(c => c.CourseModules.Select(cm => cm.Module.Units.Select(u => u.Quiz)));
                //courses = courses.Include(c => c.CourseModules.Select(cm => cm.Module.Units.Select(u => u.Assets)));
                List<Course> courseEntityList = courses.ToList();
                // Return Courses
                courseList = ObjectMapper.Map<Course, Model.Entities.Course>(courseEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return courseList;
        }

        /// <summary>
        /// Finds the courses by student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <returns></returns>
        public List<Model.Entities.Course> FindCoursesByStudent(int studentId)
        {
            List<Model.Entities.Course> courseList = new List<Model.Entities.Course>();
            try
            {
                IQueryable<Course> courses = from u in this.Context.Set<User>().Where(u => u.Id == studentId)
                                             join cr in this.Context.Set<CourseRegistration>() on u.Id equals cr.Student_Id
                                             join c in this.Context.Set<Course>() on cr.Course_Id equals c.Id
                                             select c;
                // Return Courses
                courseList = ObjectMapper.Map<Course, Model.Entities.Course>(courses.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return courseList;
        }

        /// <summary>
        /// Finds the courses with modules by courseId.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <param name="includeAssociations">The include associations.</param>
        /// <returns>Model.Entities.CourseModule</returns>
        public Model.Entities.Course FindCourseByCourseId(int courseId)
        {
            List<Model.Entities.Course> courseEntity = new List<Model.Entities.Course>();
            try
            {
                IQueryable<Course> courses = Context.Set<Course>().Where(cr => cr.Id == courseId);
                //courses = IncludePropertyAssociations(courses, new List<string> { "CourseModules.Module.ModuleQuizs.Quiz" });

                //courses = IncludePropertyAssociations(courses, new List<string> { "CourseModules.Module.ModuleQuizs.Quiz", "CourseModules.Module.Units" });
                courses = courses.Include(c => c.CourseModules.Select(cm => cm.Module).Select(m => m.ModuleQuizs.Select(mq => mq.Quiz)));
                // TODO - not sure whether this query may work without the inclusion of Module.Units
                //courses = courses.Include(c => c.CourseModules.Select(cm => cm.Module).Select(m => m.Units));
                // Return Course
                courseEntity = ObjectMapper.Map<Course, Model.Entities.Course>(courses.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return courseEntity.FirstOrDefault();
        }


        /// <summary>
        /// Finds the courses with department by staff id.
        /// </summary>
        /// <param name="StaffId">The staff id.</param>
        /// <returns></returns>
        public List<Model.Entities.Course> FindCoursesWithDepartmentByStaffId(int StaffId, int view)
        {
            List<Model.Entities.Course> courseList = new List<Model.Entities.Course>();

            IQueryable<Course> courseQuery = from u in this.Context.Set<Course>()
                                             join m in this.Context.Set<StaffCourse>().Where(m => m.Staff_Id.Equals(StaffId))
                                             on u.Id equals m.Course_Id
                                             select u;

            courseQuery = IncludePropertyAssociations(courseQuery, new List<string>() { "Department", "StaffCourses", "StaffCourses.staff", "CourseRegistrations" });

            if (view != 0)
            {
                courseQuery = courseQuery.Take(view);
            }

                
              courseList = ObjectMapper.Map<Course, Model.Entities.Course>(courseQuery.ToList());

            return courseList;
        }

        /// <summary>
        /// Finds the courses with department by staff id.
        /// </summary>
        /// <param name="StaffId">The staff id.</param>
        /// <returns></returns>
        public List<Model.Entities.Course> FindCoursesWithDepartmentByStaffId(int StaffId, string filter)
        {
            List<Model.Entities.Course> courseList = new List<Model.Entities.Course>();
            IQueryable<Course> courseQuery; 

            if (String.IsNullOrEmpty(filter))
            {
                courseQuery = from u in this.Context.Set<Course>()                                                    
                              join m in this.Context.Set<StaffCourse>()
                                 .Where(m => m.Staff_Id.Equals(StaffId))
                                 on u.Id equals m.Course_Id
                              select u;
            }
            else
            {
                courseQuery = from u in this.Context.Set<Course>()
                                                    .Where(u => u.Title.ToLower().Contains(filter.ToLower()))
                                                 join m in this.Context.Set<StaffCourse>()
                                                    .Where(m => m.Staff_Id.Equals(StaffId))
                                                    on u.Id equals m.Course_Id
                                                 select u;
            }

            courseList = ObjectMapper.Map<Course, Model.Entities.Course>(courseQuery.ToList());

            return courseList;
        }

        /// <summary>
        /// Gets the courses by staff.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        /// <returns></returns>
        public List<Model.Entities.Course> FindCoursesByStaff(int staffId)
        {
            List<Model.Entities.Course> courselist = new List<Model.Entities.Course>();
            try
            {
                // Select Courses
                IQueryable<Course> courseQuery = from sc in this.Context.Set<StaffCourse>().Where(sc => sc.Staff_Id.Equals(staffId))
                                                 join c in this.Context.Set<Course>() on sc.Course_Id equals c.Id
                                                 select c;

                courseQuery = courseQuery.Include("CourseRegistrations");
                courseQuery = courseQuery.Include("CourseRegistrations.Student");

                courselist = ObjectMapper.Map<Course, Model.Entities.Course>(courseQuery.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return courselist;
        }

        public Model.Entities.Course AddCourseByStaff(Model.Entities.Course course, int staffId)
        {
            // Before we add an association to the StaffCourse table let's add the course to the database to generate course Id which
            // then be used to populate the StaffCourse entity
            Model.Entities.Course newCourse = Add(course);

            // This doesn't seem to be the best solution to deal with many-to-many relationships but as of limited knowledge at the time of this writing 
            // This deemed to be the perfect solution.
            Model.Entities.StaffCourse staffCourse = new Model.Entities.StaffCourse();
            staffCourse.Course_Id = newCourse.Id;
            staffCourse.Staff_Id = staffId;

            // As we don't know the use of these fields so we are setting a dummy datetime value for now
            staffCourse.EffectiveFrom = DateTime.Now;
            staffCourse.EffectiveTo = DateTime.Now;
            StaffCourse newStaffCourse = ObjectMapper.Map<Model.Entities.StaffCourse, StaffCourse>(staffCourse);
            DbEntityEntry entry = Context.Entry<StaffCourse>(newStaffCourse);
            if (entry.State == System.Data.Entity.EntityState.Detached)
            {
                Context.Entry<StaffCourse>(newStaffCourse).State = System.Data.Entity.EntityState.Added;
                Context.SaveChanges();
            }

            return newCourse;

        }

        /// <summary>
        /// Remove a course association with staff
        /// </summary>
        /// <param name="studentId">The staff id.</param>
        /// <param name="course">course assigned to staffId</param>
        /// <returns></returns>
        public bool RemoveUserFromCourse(int userId, int courseId)
        {
            var staffCourse = (from sc in Context.CourseRegistrations
                              where sc.Course_Id.Equals(courseId) && sc.Student_Id.Equals(userId)
                              select sc).FirstOrDefault();
            if (staffCourse != null)
            {
                CourseRegistration entity = Context.Set<CourseRegistration>().Find(staffCourse.Id);
                Context.Set<CourseRegistration>().Remove(entity);
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes course
        /// </summary>
        /// <param name="courseId">The course id</param>
        public void RemoveCourse(int courseId)
        {
            var course = Context.Set<Course>().Find(courseId);
            var discussions = Context.Set<Discussion>().Where(d => d.CourseId.Value.Equals(courseId)).ToList();
            var assignments = Context.Set<Assignment>().Where(a => a.CourseId.Value.Equals(courseId)).ToList();
            
            // remove assignments
            foreach (var assignment in assignments)
            {
                Context.Set<Assignment>().Remove(assignment);
            }
            // remove discussions
            foreach (var discussion in discussions)
            {
                RemoveDiscussion(discussion.Id);
            }

            // remove schedule
            var schedules = Context.Set<Schedule>().Where(s => s.CourseId.Equals(courseId)).ToList();
            foreach (var schedule in schedules)
            {
                Context.Set<Schedule>().Remove(schedule);
            }

            // remove course registrations
            var courseRegistrations = Context.Set<CourseRegistration>().Where(cr => cr.Course_Id.Equals(courseId)).ToList();
            foreach (var courseRegistration in courseRegistrations)
            {
                Context.Set<CourseRegistration>().Remove(courseRegistration);
            }

            // remove staff for courses
            var staffCourses = Context.Set<StaffCourse>().Where(sc => sc.Course_Id.Equals(courseId)).ToList();
            foreach (var staffCourse in staffCourses)
            {
                Context.Set<StaffCourse>().Remove(staffCourse);
            }

            // remove course from module
            var courseModules = Context.Set<CourseModule>().Where(cm => cm.Course_Id.Equals(courseId)).ToList();
            foreach (var courseModule in courseModules)
            {
                Context.Set<CourseModule>().Remove(courseModule);
            }
            Remove(courseId);
        }

        private void RemoveDiscussion(int discussionId)
        {
            var discussion = Context.Set<Discussion>().Find(discussionId);
            var topics = Context.Set<Topic>().Where(t => t.DiscussionId.Equals(discussionId)).ToList();
            foreach (var topic in topics)
            {
                var topicPosts = Context.Set<TopicPost>().Where(t => t.TopicId.Equals(topic.Id)).ToList();
                foreach (var topicPost in topicPosts)
                {
                    Context.Set<TopicPost>().Remove(topicPost);
                }
                Context.Set<Topic>().Remove(topic);
                Context.SaveChanges();
            }

            Context.Set<Discussion>().Remove(discussion);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseModuleId"></param>
        public void RemoveCourseFromModule(int courseModuleId)
        {
            CourseModule courseModule = Context.Set<CourseModule>().Find(courseModuleId);
            Context.Set<CourseModule>().Remove(courseModule);
            Context.SaveChanges();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<Model.Entities.CourseModule> GetCourseModulesByModule(int moduleId)
        {

            List<Model.Entities.CourseModule> courseModulelist = new List<Model.Entities.CourseModule>();
            try
            {
                // Select Courses

                IQueryable<CourseModule> courseModuleQuery =
                                                 from cm in this.Context.Set<CourseModule>().Include("Course")
                                                     .Where(cm => cm.Module_Id == moduleId)
                                                 select cm;


                courseModulelist = ObjectMapper.Map<CourseModule, Model.Entities.CourseModule>(courseModuleQuery.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return courseModulelist;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        public Model.Entities.Course GetCourseByName(string courseName)
        {
            Model.Entities.Course courseEntity = new Model.Entities.Course();

            try
            {
                courseEntity =
                    ObjectMapper.Map<Course, Model.Entities.Course>(this.Context.Set<Course>().Where(c => c.Title.Equals(courseName)).ToList<Course>().FirstOrDefault<Course>());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }

            return courseEntity;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseModule"></param>
        public void AddCourseModule(Model.Entities.CourseModule courseModule)
        {
            try
            {
                CourseModule newEntity = ObjectMapper.Map<Model.Entities.CourseModule, CourseModule>(courseModule);
                if (!ExistsCourseModule(newEntity))
                {
                    DbEntityEntry entry = Context.Entry<CourseModule>(newEntity);
                    if (entry.State == System.Data.Entity.EntityState.Detached)
                    {
                        Context.Entry<CourseModule>(newEntity).State = System.Data.Entity.EntityState.Added;
                        Context.SaveChanges();
                    }
                }
                //return ObjectMapper.Map<CourseModule, TModel>(newEntity);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CourseModule"></param>
        /// <returns></returns>
        private bool ExistsCourseModule(CourseModule CourseModule)
        {
            try
            {
                var courseModuleElement = Context.Set<CourseModule>().Where(cm => cm.Module_Id == CourseModule.Module_Id && cm.Course_Id == CourseModule.Course_Id).ToList();

                if (courseModuleElement.Count() == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
                return true;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public Model.Entities.Course GetCourseByIdWithStudents(int courseId)
        {
            Model.Entities.Course courseEntity = new Model.Entities.Course();

            try
            {
                var course = this.Context.Set<Course>().Where(c => c.Id.Equals(courseId))
                    .Include("CourseRegistrations")
                    .Include("CourseRegistrations.Student");
       
                courseEntity =
                    ObjectMapper.Map<Course, Model.Entities.Course>(course.ToList<Course>().FirstOrDefault<Course>());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }

            return courseEntity;
        }
       
        #endregion

    }
}
