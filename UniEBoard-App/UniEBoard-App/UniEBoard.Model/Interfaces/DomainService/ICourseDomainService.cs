// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICourseDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for Course Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;

namespace UniEBoard.Model.Interfaces.DomainService
{
    /// <summary>
    /// ICourseDomainService interface definition - Contains Methods for Course Operations
    /// </summary>
    public interface ICourseDomainService : IBaseDomainService<Course>
    {
        /// <summary>
        /// Gets all courses and modules by student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="includeModules">if set to <c>true</c> [include modules].</param>
        /// <returns></returns>
        List<Course> GetAllCoursesByStudent(int studentId, bool includeModules = true);

        /// <summary>
        /// Finds the course moduleby course id.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        Course FindCourseWithModulebyCourseId(int courseId);

        /// <summary>
        /// Finds the courseby course id.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        Course FindCoursebyCourseId(int courseId);

        /// <summary>
        /// Gets module by ID
        /// </summary>
        /// <param name="moduleId">The module id.</param>
        /// <returns>Module</returns>
        Module FindModulebyId(int moduleId);

        /// <summary>
        /// Gets the modules by teacher.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <returns></returns>
        List<Module> GetModulesByTeacher(int teacherId, int view = 0);

        /// <summary>
        /// Gets the modules created by teacher.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <returns></returns>
        List<Module> GetModulesCreatedByTeacher(int teacherId, int view = 0);

        /// <summary>
        /// Gets the modules by student.
        /// </summary>
        /// <param name="teacherId">The student id.</param>
        /// <returns></returns>
        List<Module> GetModulesByStudent(int studentId, int view = 0);

        /// <summary>
        /// Finds the courses with department by staff id.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        /// <returns></returns>
        List<Course> FindCoursesWithDepartmentByStaffId(int staffId,int view);

        /// <summary>
        /// Finds the courses with department by staff id.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        /// <returns></returns>
        List<Course> FindCoursesWithDepartmentByStaffId(int staffId, string filter);

        /// <summary>
        /// Gets the courses by staff.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        /// <returns></returns>
        List<Model.Entities.Course> GetCoursesByStaff(int staffId);

        /// <summary>
        /// Add a course by staff
        /// </summary>
        /// <param name="studentId">The staff id.</param>
        /// <param name="course">course assigned to staffId</param>
        /// <returns></returns>
        Course AddCourseByStaff(Course course, int staffId);

        /// <summary>
        /// Remove Course From Module by courseId. 
        /// </summary>
        /// <param name="courseId">Course ID.</param>
        void RemoveCourseFromModule(int courseId);

        /// <summary>
        /// Removes the StaffCourse associative relationship associated with the speicied by courseId
        /// </summary>
        /// <param name="courseId">Course Id</param>
        /// <returns>true if deletion was successfull otherwise returns false</returns>
        bool RemoveStaffForCourse(int courseId);

        /// <summary>
        /// Removes the course and it's associated records
        /// </summary>
        /// <param name="courseId">The course id</param>
        /// <returns>true if deletion is successful otherwise returns false</returns>
        bool RemoveCourse(int courseId);

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
        List<CourseModule> GetCourseModulesByModule(int moduleId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        Course GetCourseByName(string courseName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Course GetCourseByIdWithStudents(int courseId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseModule"></param>
        void AddCourseModule(CourseModule courseModule);
    }
}
