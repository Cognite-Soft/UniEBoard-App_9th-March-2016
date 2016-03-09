// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICourseModuleAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for all Course and module related operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Service.Models;
using System.Web.Mvc;

namespace UniEBoard.Service.Interfaces.ApplicationService
{
    /// <summary>
    /// ICourseModuleAppService Interface - Contains Methods for all Course and module related operations
    /// </summary>
    public interface ICourseModuleAppService : IBaseAppService
    {
        /// <summary>
        /// Gets or sets the course manager.
        /// </summary>
        /// <value>The course manager.</value>
        ICourseDomainService CourseManager { get; set; }
        IModuleDomainService ModuleManager { get; set; }
        IDepartmentDomainService DepartmentManager { get; set; }
        ICourseRegistrationDomainService CourseRegistrationManager { get; set; }
       

        /// <summary>
        /// Gets all student course and modules.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="includeModules">if set to <c>true</c> [include modules].</param>
        /// <returns></returns>
        List<CourseViewModel> GetAllStudentCourses(int studentId, bool includeModules = true);

        /// <summary>
        /// Gets the courses by staff.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        /// <returns></returns>
        List<CourseViewModel> GetCoursesByStaff(int staffId);

        /// <summary>
        /// Get course by CourseId
        /// </summary>
        /// <param name="courseId">Course id</param>
        /// <returns>CourseViewModel</returns>
        CourseViewModel GetCourseById(int courseId);

        /// <summary>
        /// Gets the course with modules by id.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        CourseViewModel GetCourseWithModulesById(int courseId);

        /// <summary>
        /// Gets the module.
        /// </summary>
        /// <param name="unitId">The module id.</param>
        /// <returns></returns>
        ModuleViewModel GetModuleById(int moduleId);

        /// <summary>
        /// Get Module Syllabus group by Dates
        /// </summary>
        /// <param name="courseId">Course id</param>
        /// <returns>ModuleSyllabusModel</returns>
        List<ModuleSyllabusModel> GetModuleSyllabusById(int courseId);

        /// <summary>
        /// Get Module Syllabus group by Dates
        /// </summary>
        /// <param name="courseId">Course id</param>
        /// <returns>List<ModuleViewModel/></returns>
        List<ModuleViewModel> GetModulesByCourseId(int courseId);

        /// <summary>
        /// Gets the courses with department by staff id.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        /// <returns></returns>
        List<CourseViewModel> GetCoursesWithDepartmentByStaffId(int staffId,int view);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffId"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        List<CourseViewModel> GetCoursesWithDepartmentByStaffId(int staffId, string filter);

        /// <summary>
        /// Gets all modules assigned the teacher.
        /// </summary>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetModulesByTeacher(int teacherId);

        /// <summary>
        /// Gets all modules assigned to and created by with the teacher.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ModuleViewModel> GetModulesForTeacher(int teacherId);

        /// <summary>
        /// Gets all modules assinged to and created by teacher 
        /// filtered by course id
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        IEnumerable<ModuleViewModel> GetModulesForTeacherByCourseId(int teacherId, int courseId);

        /// <summary>
        /// Gets a list of modules by teacher
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns>List of the ModuleViewModel</returns>
        IEnumerable<ModuleViewModel> GetModulesByTeacherId(int teacherId, int view = 0);

        /// <summary>
        /// Gets a list of modules created by teacher
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns>List of the ModuleViewModel</returns>
        IEnumerable<ModuleViewModel> GetModulesCreatedByTeacher(int teacherId, int view = 0);

        /// <summary>
        /// Create a module
        /// </summary>
        /// <param name="moduleViewModel">ModuleViewModel</param>
        bool CreateModule(ModuleViewModel moduleViewModel);

        /// <summary>
        /// Create a course
        /// </summary>
        /// <param name="moduleViewModel">CourseViewModel</param>
        void CreateCourse(CourseViewModel courseViewModel);


        /// <summary>
        /// Add a course by staff
        /// </summary>
        /// <param name="studentId">The staff id.</param>
        /// <param name="course">course assigned to staffId</param>
        /// <returns></returns>
        int? CreateCourseByStaff(CourseViewModel course, int staffId);

        /// <summary>
        /// Update a module
        /// </summary>
        /// <param name="moduleViewModel">ModuleViewModel</param>
        void UpdateModule(ModuleViewModel moduleViewModel);

        /// <summary>
        /// Update a course
        /// </summary>
        /// <param name="moduleViewModel">CourseViewModel</param>
        void UpdateCourse(CourseViewModel courseViewModel);

        /// <summary>
        /// Get all courses
        /// </summary>
        /// <param name="includeModules">whether to include modules or not</param>
        /// <returns></returns>
        List<CourseViewModel> GetAllCourses();

        /// <summary>
        /// Get all departments
        /// </summary>
        /// <returns>list of all departments</returns>
        IEnumerable<DepartmentViewModel> GetAllDepartments();

        /// <summary>
        /// Create a new course registration
        /// </summary>
        /// <param name="courseRegistrationViewModel">Course Registration View Model</param>
        void CreateCourseRegistration(CourseRegistrationViewModel courseRegistrationViewModel);

        /// <summary>
        /// Get the quizModule
        /// </summary>
        /// <param name="moduleId">The moduleId.</param>
        List<ModuleQuizViewModel> GetModuleQuizs(int moduleId);


         /// <summary>
        /// Remove Course From Module by courseId. 
        /// </summary>
        /// <param name="courseId">Course ID.</param>
        void RemoveCourseFromModule(int courseId);

         /// <summary>
        /// Remove Module From Course by moduleId. 
        /// </summary>
        /// <param name="moduleId">Module ID.</param>
        void RemoveModuleFromCourse(int moduleId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseModuleId"></param>
        void RemoveCourseModule(int courseModuleId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        IEnumerable<CourseModuleViewModel> GetCourseModulesByModule(int moduleId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        CourseViewModel GetCourseByName(string courseName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseModuleViewModel"></param>
        void AddCourseModule(CourseModuleViewModel courseModuleViewModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        List<AssignmentViewModel> GetAssignmentsForTeacher(int teacherId, bool includeSubmissions = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        List<StudentViewModel> GetStudentsForTeacher(int teacherId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        /// <param name="gradeValue"></param>
        void SubmitGradesForSubmission(int id, string comment, int gradeValue);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        CourseViewModel GetCourseByIdWithStudents(int courseId);

    }
}
