// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStudentDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for Student Operations
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
    /// IStudentDomainService Interface definition - Contains Methods for Student Operations
    /// </summary>
    public interface IStudentDomainService : IBaseDomainService<Student>
    {
        /// <summary>
        /// Gets the student by member ship id.
        /// </summary>
        /// <param name="membershipId">The membership id.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        Student GetStudentByMemberShipId(int membershipId);

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
        List<ModuleGrade> GetGradeForStudentByCoursePerModule(int studentId, int courseId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        List<Submission> GetGradeForStudentByCoursePerAssignment(int studentId, int courseId);

        /// <summary>
        /// Finds all the students in the same class.
        /// </summary>
        /// <param name="userName">The student Id</param>
        /// <returns>A list of fellow users</returns>
        List<Student> GetFellowStudents(int studentId);

        /// <summary>
        /// Finds the Teacher for students
        /// </summary>
        /// <param name="userName">The student id</param>
        /// <returns>A list of teachers for students</returns>
        List<Staff> GetTeachersByStudent(int studentId);

        /// <summary>
        /// Finds a list of courses student is registered for.
        /// </summary>
        /// <param name="studentId">Student Id</param>
        /// <returns>A List of Courses</returns>
        List<Model.Entities.Course> GetRegisteredCourses(int studentId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="?"></param>
        List<Student>GetStudentsForTeacher(int teacherId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        List<Student> GetStudentsForModule(int moduleId);
    }
}
