// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICourseRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for Course Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;

namespace UniEBoard.Model.Interfaces.Repository
{
    /// <summary>
    /// The Course Repository Interface
    /// </summary>
    public interface ICourseRepository : IBaseRepository<Course>
    {
        /// <summary>
        /// Add a course by staff
        /// </summary>
        /// <param name="studentId">The staff id.</param>
        /// <param name="course">course assigned to staffId</param>
        /// <returns></returns>
        Course AddCourseByStaff(Course course, int staffId);

        /// <summary>
        /// Remove a course association with staff
        /// </summary>
        /// <param name="studentId">The staff id.</param>
        /// <param name="course">course assigned to staffId</param>
        /// <returns></returns>
        bool RemoveUserFromCourse(int userId, int courseId);

        /// <summary>
        /// Finds the courses with modules by student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <returns></returns>
        List<Model.Entities.Course> FindCoursesWithModulesByStudent(int studentId);

        /// <summary>
        /// Finds the courses with modules by courseId.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <param name="includeAssociations">The include associations.</param>
        /// <returns>Model.Entities.CourseModule</returns>
        Model.Entities.Course FindCourseByCourseId(int courseId);


        /// <summary>
        /// Finds the course by student.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <returns></returns>
        List<Model.Entities.Course> FindCoursesByStudent(int studentId);


        /// <summary>
        /// Finds the courses with department by staff id.
        /// </summary>
        /// <param name="StaffId">The staff id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<Model.Entities.Course> FindCoursesWithDepartmentByStaffId(int StaffId, int view);

        /// <summary>
        /// Finds the courses with department by staff id.
        /// </summary>
        /// <param name="StaffId">The staff id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<Model.Entities.Course> FindCoursesWithDepartmentByStaffId(int StaffId, string filter);

        /// <summary>
        /// Gets the courses by staff.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        /// <returns></returns>
        List<Model.Entities.Course> FindCoursesByStaff(int staffId);

        /// <summary>
        /// Removes course
        /// </summary>
        /// <param name="courseId">The course id</param>
        void RemoveCourse(int courseId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseModuleId"></param>
        void RemoveCourseFromModule(int courseModuleId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        List<Model.Entities.CourseModule> GetCourseModulesByModule(int moduleId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        Model.Entities.Course GetCourseByName(string courseName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseModule"></param>
        void AddCourseModule(Model.Entities.CourseModule courseModule);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Model.Entities.Course GetCourseByIdWithStudents(int courseId);

    }
}
