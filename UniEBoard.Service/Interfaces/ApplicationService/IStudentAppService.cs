// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStudentAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for Student Application Service Operations
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

namespace UniEBoard.Service.Interfaces.ApplicationService
{
    /// <summary>
    /// IStudentAppService Interface - Contains Methods for Student Application Service Operations
    /// </summary>
    public interface IStudentAppService : IBaseAppService
    {
        /// <summary>
        /// Gets or sets the student manager.
        /// </summary>
        /// <value>The student manager.</value>
        IStudentDomainService StudentManager { get; set; }

        /// <summary>
        /// Gets all the students.
        /// </summary>
        /// <returns></returns>
        List<StudentViewModel> GetAllStudents();

        /// <summary>
        /// Gets the student by member ship id.
        /// </summary>
        /// <param name="membershipId">The membership id.</param>
        /// <returns></returns>
        StudentViewModel GetStudentByMemberShipId(int membershipId);

        /// <summary>
        /// Creates the student user.
        /// </summary>
        /// <param name="membershipId">The membership id.</param>
        /// <param name="model">The model.</param>
        bool CreateStudentUser(int membershipId, StudentViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        void UpdateStudentUser(StudentViewModel model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        int GetGradeForStudentByCourse(int studentId, int courseId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        List<ModuleGradeViewModel> GetGradeForStudentByCoursePerModule(int studentId, int courseId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        List<SubmissionViewModel> GetGradeForStudentByCoursePerAssignment(int studentId, int courseId);

        /// <summary>
        /// Finds all the students in the same class.
        /// </summary>
        /// <param name="userName">The student Id</param>
        /// <returns>A list of fellow users</returns>
        List<StudentViewModel> GetFellowStudents(int studentId);

        /// <summary>
        /// Finds the Teacher for students
        /// </summary>
        /// <param name="userName">The student id</param>
        /// <returns>A list of teachers for students</returns>
        List<StaffViewModel> GetTeachersByStudent(int studentId);

        /// <summary>
        /// returns a list of users including the fellow students and teachers for the students
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>List of UserViewModel</returns>
        List<UserViewModel> GetUsersForStudent(int studentId);

        /// <summary>
        /// Finds a list of courses student is registered for.
        /// </summary>
        /// <param name="studentId">Student Id</param>
        /// <returns>A List of Courses</returns>
        List<CourseViewModel> GetRegisteredCourses(int studentId);
    }
}
