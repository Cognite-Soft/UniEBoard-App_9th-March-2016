// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseModuleAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for all Course and module related operations
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
using UniEBoard.Service.Models.Quizzes;
using UniEBoard.Service.Factories;
using UniEBoard.Model.Adapters.Logging;
using System.Web.Mvc;
using UniEBoard.Service.Helpers.Comparer;

namespace UniEBoard.Service.ApplicationServices
{
    /// <summary>
    /// Course And Module Application Service Class - Contains Methods for all Course and module related operations
    /// </summary>
    public class CourseModuleAppService : BaseAppService, ICourseModuleAppService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the course manager.
        /// </summary>
        /// <value>The course manager.</value>
        public ICourseDomainService CourseManager { get; set; }
        public IModuleDomainService ModuleManager { get; set; }
        public IDepartmentDomainService DepartmentManager { get; set; }
        public ICourseRegistrationDomainService CourseRegistrationManager { get; set; }
        public IModuleQuizDomainService ModuleQuizManager { get; set; }
        public IQuizDomainService QuizManager { get; set; }
        public IAssignmentDomainService AssignmentManager { get; set; }
        public ISubmissionDomainService SubmissionManager { get; set; }
        public IStudentDomainService StudentManager { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseModuleAppService"/> class.
        /// </summary>
        /// <param name="courseManager">The course manager.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="cacheService">The cache service.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public CourseModuleAppService(
            ICourseDomainService courseManager,
            IModuleDomainService moduleManager,
            IModuleQuizDomainService moduleQuizManager,
            IDepartmentDomainService departmentManager,
            IObjectMapperAdapter objectMapper,
            ICacheAdapter cacheService,
            IExceptionManagerAdapter exceptionManager,
            ILoggingServiceAdapter loggingService,
            ICourseRegistrationDomainService courseRegistrationManager,
            IQuizDomainService quizManager,
            IAssignmentDomainService assignmentManager,
            ISubmissionDomainService submissionManager,
            IStudentDomainService studentManager)
            : base(objectMapper, cacheService, exceptionManager, loggingService)
        {
            this.CourseManager = courseManager;
            this.ModuleManager = moduleManager;
            this.DepartmentManager = departmentManager;
            this.CourseRegistrationManager = courseRegistrationManager;
            this.QuizManager = quizManager;
            this.AssignmentManager = assignmentManager;
            this.SubmissionManager = submissionManager;
            this.StudentManager = studentManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all student course and modules.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="includeModules">if set to <c>true</c> [include modules].</param>
        /// <returns></returns>
        public List<CourseViewModel> GetAllStudentCourses(int studentId, bool includeModules = true)
        {
            List<CourseViewModel> models = new List<CourseViewModel>();
            try
            {
                List<Course> courses = CourseManager.GetAllCoursesByStudent(studentId, includeModules);
                models = CourseViewModelFactory.CreateCourseViewModels(courses, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets all student course and modules.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="includeModules">if set to <c>true</c> [include modules].</param>
        /// <returns></returns>
        public List<CourseViewModel> GetAllCourses()
        {
            List<CourseViewModel> models = new List<CourseViewModel>();
            try
            {
                List<Course> courses = CourseManager.FindAll();
                models = CourseViewModelFactory.CreateCourseViewModels(courses, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }



        /// <summary>
        /// Gets the courses by staff.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        /// <returns></returns>
        public List<CourseViewModel> GetCoursesByStaff(int staffId)
        {
            List<CourseViewModel> models = new List<CourseViewModel>();
            try
            {
                List<Course> courses = CourseManager.GetCoursesByStaff(staffId);
                models = CourseViewModelFactory.CreateCourseViewModels(courses, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets course by Id.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns>CourseViewModel</returns>
        public CourseViewModel GetCourseById(int courseId)
        {
            CourseViewModel models = new CourseViewModel();
            try
            {
                Course courses = CourseManager.FindCoursebyCourseId(courseId);
                models = CourseViewModelFactory.CreateCourseViewModels(courses, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets course by Id.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns>CourseViewModel</returns>
        public CourseViewModel GetCourseByIdWithStudents(int courseId)
        {
            CourseViewModel models = new CourseViewModel();
            try
            {
                Course courses = CourseManager.GetCourseByIdWithStudents(courseId);
                models = CourseViewModelFactory.CreateCourseViewModels(courses, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets the course with modules by id.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        public CourseViewModel GetCourseWithModulesById(int courseId)
        {
            CourseViewModel models = new CourseViewModel();
            try
            {
                Course courses = CourseManager.FindCourseWithModulebyCourseId(courseId);
                models = CourseViewModelFactory.CreateCourseViewModels(courses, ObjectMapper);

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets module by Id.
        /// </summary>
        /// <param name="moduleId">The moduleId id.</param>
        /// <returns>ModuleViewModel</returns>
        public ModuleViewModel GetModuleById(int moduleId)
        {
            ModuleViewModel models = new ModuleViewModel();
            try
            {
                Module modules = CourseManager.FindModulebyId(moduleId);
                models = ObjectMapper.Map<Model.Entities.Module, ModuleViewModel>(modules);

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }



        /// <summary>
        /// Get course planification grouping by date
        /// </summary>
        /// <param name="courseId">Course Id</param>
        /// <returns>ModuleSyllabusModel</returns>
        public List<ModuleSyllabusModel> GetModuleSyllabusById(int courseId)
        {
            List<ModuleSyllabusModel> models = new List<ModuleSyllabusModel>();
            try
            {
                //Get the modules
                List<ModuleViewModel> modules = GetCourseById(courseId).Modules.ToList();

                models = modules.GroupBy(p => new { p.PublishFrom, p.PublishTo })
                  .Select(g => new ModuleSyllabusModel
                  {
                      PublishFrom = g.Key.PublishFrom.Value.ToString("dddd dd MMMM yyyy"),
                      PublishTo = g.Key.PublishTo.Value.ToString("dddd dd MMMM yyyy"),
                      Modules = g.Select(x => new ModuleViewModel
                      {
                          Title = x.Title,
                          Description = x.Description,
                          PublishFrom = x.PublishFrom,
                          PublishTo = x.PublishTo,
                          Approved = x.Approved,
                          Course_Id = x.Course_Id,
                          Quizzes = x.Quizzes,
                          Units = x.Units
                      }).ToList()
                  })
                  .ToList();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

      
        
        /// <summary>
        /// Get modules by idcourse
        /// </summary>
        /// <param name="courseId">course Id</param>
        /// <returns>List<ModuleViewModel></returns>
        public List<ModuleViewModel> GetModulesByCourseId(int courseId)
        {
            List<ModuleViewModel> models = new List<ModuleViewModel>();
            try
            {
                List<Module> modules = ModuleManager.GetModulesByCourse(courseId);
                
                //Get the modules
                models = ModuleViewModelFactory.CreateModuleViewModels(modules, ObjectMapper);
                

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Updates the module.
        /// </summary>
        /// <param name="unit">The module.</param>
        public void UpdateModule(ModuleViewModel moduleViewModel)
        {
            try
            {
                Module module = ObjectMapper.Map<ModuleViewModel, Model.Entities.Module>(moduleViewModel);
                ModuleManager.Update(module);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        /// <summary>
        /// Updates the course
        /// </summary>
        /// <param name="courseViewModel">CourseViewModel</param>
        public void UpdateCourse(CourseViewModel courseViewModel)
        {
            try
            {
                Course course = ObjectMapper.Map<CourseViewModel, Model.Entities.Course>(courseViewModel);
                CourseManager.Update(course);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        /// <summary>
        /// Get the quizModule
        /// </summary>
        /// <param name="moduleId">The moduleId.</param>
        public List<ModuleQuizViewModel> GetModuleQuizs(int moduleId)
        {
            List<ModuleQuizViewModel> models = new List<ModuleQuizViewModel>();
            try
            {
                List<ModuleQuiz> _quizModule = ModuleQuizManager.FindAll().Where(x => x.ModuleId == moduleId).ToList();
                models = (ObjectMapper.Map<Model.Entities.ModuleQuiz, ModuleQuizViewModel>(_quizModule)).ToList();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffId"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        public List<CourseViewModel> GetCoursesWithDepartmentByStaffId(int staffId, int view)
        {
            List<CourseViewModel> models = new List<CourseViewModel>();
            try
            {
                //Get the modules
                List<Course> courses = CourseManager.FindCoursesWithDepartmentByStaffId(staffId, view);
                models = CourseViewModelFactory.CreateCourseViewModels(courses, ObjectMapper);

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }

            return models;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffId"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<CourseViewModel> GetCoursesWithDepartmentByStaffId(int staffId, string filter)
        {
            List<CourseViewModel> models = new List<CourseViewModel>();
            try
            {
                //Get the modules
                List<Course> courses = CourseManager.FindCoursesWithDepartmentByStaffId(staffId, filter);
                models = CourseViewModelFactory.CreateCourseViewModels(courses, ObjectMapper);

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }

            return models;
        }

        /// <summary>
        /// Gets the upload types.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GetModulesByTeacher(int teacherId)
        {
            List<Module> modules = CourseManager.GetModulesByTeacher(teacherId);
            IEnumerable<SelectListItem> moduleSelectList = modules.Select(m => new SelectListItem(){Text = m.Title, Value = m.Id.ToString()}).ToList().AsEnumerable();
            return moduleSelectList;
        }

        /// <summary>
        /// Gets all modules assigned to and created by with the teacher.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleViewModel> GetModulesForTeacher(int teacherId)
        {
            IEnumerable<ModuleViewModel> moduelesAssignedToTeacher = GetModulesByTeacherId(teacherId);
            IEnumerable<ModuleViewModel> modulesCreatedByTeacher = GetModulesCreatedByTeacher(teacherId);
            var modulesAssociatedToAndCreatedByTeacher = moduelesAssignedToTeacher.Concat(modulesCreatedByTeacher).Distinct(new ViewModelComparer<ModuleViewModel>());
            return modulesAssociatedToAndCreatedByTeacher;
        }

        /// <summary>
        /// Gets all modules assinged to and created by teacher 
        /// filtered by course id
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        public IEnumerable<ModuleViewModel> GetModulesForTeacherByCourseId(int teacherId, int courseId)
        {
            var modules = GetModulesForTeacher(teacherId);
            List<ModuleViewModel> models = new List<ModuleViewModel>();
            foreach (var module in modules)
            {
                var courseModules = module.CourseModules;
                foreach (var courseModule in courseModules)
                {
                    if (courseModule.Course_Id == courseId)
                        models.Add(module);
                }
            }
            //var modulesForTeacherByCourseId = GetModulesForTeacher(teacherId).Where(m => m.Course_Id == courseId);
            return models;
        }

        /// <summary>
        /// Gets all modules associated to a teacher assigned courses
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        public IEnumerable<ModuleViewModel> GetModulesByTeacherId(int teacherId, int view = 0)
        {
            List<ModuleViewModel> models = new List<ModuleViewModel>();
            try
            {
                List<Module> modules = CourseManager.GetModulesByTeacher(teacherId, view);
                models = ObjectMapper.Map<Model.Entities.Module, ModuleViewModel>(modules);
            }
            catch (Exception ex)
            {

                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }

            return models;
        }

        /// <summary>
        /// Gets all modules created by teacher
        /// </summary>
        /// <param name="teacherId"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        public IEnumerable<ModuleViewModel> GetModulesCreatedByTeacher(int teacherId, int view = 0)
        {
            List<ModuleViewModel> models = new List<ModuleViewModel>();
            try
            {
                List<Module> modules = CourseManager.GetModulesCreatedByTeacher(teacherId, view);
                models = ObjectMapper.Map<Model.Entities.Module, ModuleViewModel>(modules);
            }
            catch (Exception ex)
            {

                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }

            return models;
        }

        /// <summary>
        /// Creates the module.
        /// </summary>
        /// <param name="unitViewModel">The module view model.</param>
        public bool CreateModule(ModuleViewModel moduleViewModel)
        {
            try
            {
                if (moduleViewModel != null)
                {
                    Module module = ObjectMapper.Map<ModuleViewModel, Model.Entities.Module>(moduleViewModel);
                    module = ModuleManager.Add(module);
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
        /// Creates the course.
        /// </summary>
        /// <param name="unitViewModel">The course view model.</param>
        public void CreateCourse(CourseViewModel courseViewModel)
        {
            try
            {
                if (courseViewModel != null)
                {
                    courseViewModel.Accreditation_Id = courseViewModel.Accreditation_Id == 0 ? (int)AccreditationType.NotSpecified : courseViewModel.Accreditation_Id;
                    courseViewModel.CompanyId = courseViewModel.CompanyId == 0 ? (int)CompanyEnum.Trust : courseViewModel.CompanyId;
                    courseViewModel.CourseTemplate_Id = courseViewModel.CourseTemplate_Id == 0 ? (int)CourseTemplateEnum.DefaultTemplate : courseViewModel.CourseTemplate_Id;

                    Course course = ObjectMapper.Map<CourseViewModel, Model.Entities.Course>(courseViewModel);
                    course = CourseManager.Add(course);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseRegistrationViewModel"></param>
        public void CreateCourseRegistration(CourseRegistrationViewModel courseRegistrationViewModel)
        {
            try
            {
                if (courseRegistrationViewModel != null)
                {
                    CourseRegistration courseRegistration = ObjectMapper.Map<CourseRegistrationViewModel, Model.Entities.CourseRegistration>(courseRegistrationViewModel);
                    courseRegistration = CourseRegistrationManager.Add(courseRegistration);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        /// <summary>
        /// Creates the course.
        /// </summary>
        /// <param name="unitViewModel">The course view model.</param>
        public int? CreateCourseByStaff(CourseViewModel courseViewModel, int staffId)
        {
            try
            {
                if (courseViewModel != null)
                {
                    courseViewModel.Accreditation_Id = courseViewModel.Accreditation_Id == 0 ? (int)AccreditationType.NotSpecified : courseViewModel.Accreditation_Id;
                    courseViewModel.CompanyId = courseViewModel.CompanyId == 0 ? (int)CompanyEnum.Trust : courseViewModel.CompanyId;
                    courseViewModel.CourseTemplate_Id = courseViewModel.CourseTemplate_Id == 0 ? (int)CourseTemplateEnum.DefaultTemplate : courseViewModel.CourseTemplate_Id;

                    Course course = ObjectMapper.Map<CourseViewModel, Model.Entities.Course>(courseViewModel);
                    course = CourseManager.AddCourseByStaff(course, staffId);
                    return course.Id;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return null;
        }

        public IEnumerable<DepartmentViewModel> GetAllDepartments()
        {
            List<DepartmentViewModel> models = new List<DepartmentViewModel>();
            try
            {
                List<Department> modules = DepartmentManager.FindAll();
                models = ObjectMapper.Map<Model.Entities.Department, DepartmentViewModel>(modules);
            }
            catch (Exception ex)
            {

                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }

            return models;
        }

        /// <summary>
        /// Remove Course From Module by courseId. 
        /// </summary>
        /// <param name="courseId">Course ID.</param>
        public void RemoveCourseFromModule(int courseId)
        {
            try
            {
                CourseManager.RemoveCourseFromModule(courseId);
            }
            catch (Exception ex)
            {

                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        /// <summary>
        /// Remove Module From Course by moduleId. 
        /// </summary>
        /// <param name="moduleId">Module ID.</param>
        public void RemoveModuleFromCourse(int moduleId)
        {
            try
            {
                ModuleManager.RemoveModuleFromCourse(moduleId);
            }
            catch (Exception ex)
            {

                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseModuleId"></param>
        public void RemoveCourseModule(int courseModuleId)
        {
            try
            {
                CourseManager.RemoveCourseModule(courseModuleId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public IEnumerable<CourseModuleViewModel> GetCourseModulesByModule(int moduleId)
        {
            List<CourseModuleViewModel> courseModuleViewModelList = new List<CourseModuleViewModel>();

            try
            {
                courseModuleViewModelList =
                    ObjectMapper.Map<Model.Entities.CourseModule, CourseModuleViewModel>(CourseManager.GetCourseModulesByModule(moduleId));
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }

            return courseModuleViewModelList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        public CourseViewModel GetCourseByName(string courseName)
        {
            CourseViewModel courseViewModel = new CourseViewModel();

            try
            {
                courseViewModel =
                    ObjectMapper.Map<Model.Entities.Course, CourseViewModel>(CourseManager.GetCourseByName(courseName));
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }

            return courseViewModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseModuleViewModel"></param>
        public void AddCourseModule(CourseModuleViewModel courseModuleViewModel)
        {
            try
            {
                CourseManager.AddCourseModule(ObjectMapper.Map<CourseModuleViewModel, Model.Entities.CourseModule>(courseModuleViewModel));
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        public List<AssignmentViewModel> GetAssignmentsForTeacher(int teacherId, bool includeSubmissions = false)
        {
            List<AssignmentViewModel> assignmentViewModelList = new List<AssignmentViewModel>();

            try
            {

                //StudentManager.GetStudentsForTeacher(teacherId);
                List <Model.Entities.Assignment> assignments = AssignmentManager.GetAssignmentForTeacher(teacherId, includeSubmissions);

                foreach (var assign in assignments)
                {
                    List<Model.Entities.Student> students = StudentManager.GetStudentsForModule(assign.ModuleId??0);

                    foreach (var stud in students)
                    {
                        if (!assign.Submissions.Any(sub => stud.Id == sub.StudentId)) 
                        {
                            Submission newSub = new Submission();
                            newSub.Student = stud;
                            newSub.StudentId = stud.Id;
                            newSub.Assignment = assign;
                            newSub.AssignmentId = assign.Id;
                            newSub.Status = 0;
                            assign.Submissions.Add(newSub);
                        }
                    
                    }

                }

                assignmentViewModelList =
                    ObjectMapper.Map<Model.Entities.Assignment, AssignmentViewModel>(assignments);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }

            return assignmentViewModelList;
    
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        public List<StudentViewModel> GetStudentsForTeacher(int teacherId)
        {
            List<StudentViewModel> studentViewModelList = new List<StudentViewModel>();

            try
            {
                studentViewModelList =
                    ObjectMapper.Map<Model.Entities.Student, StudentViewModel>(StudentManager.GetStudentsForTeacher(teacherId));
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }

            return studentViewModelList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        /// <param name="gradeValue"></param>
        public void SubmitGradesForSubmission(int id, string comment, int gradeValue) 
        {

            try
            {
                Model.Entities.Submission submission = SubmissionManager.FindBy(id);
                submission.Body = comment;
                submission.GradePointValue = gradeValue;

                SubmissionManager.Update(submission);                
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }

        }
        
        #endregion
    }
}
