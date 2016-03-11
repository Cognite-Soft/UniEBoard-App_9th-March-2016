// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStudentRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for Student Repository CRUD operations.
// </summary>
// ------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;

namespace UniEBoard.Model.Interfaces.Repository
{
    /// <summary>
    /// the Student Repository interface
    /// </summary>
    public interface IStudentRepository : IBaseRepository<Student>
    {
        /// <summary>
        /// Gets the student by member ship id.
        /// </summary>
        /// <param name="membershipId">The membership id.</param>
        /// <returns></returns>
        Student GetStudentByMemberShipId(int membershipId);

        /// <summary>
        /// Finds the students in the same class.
        /// </summary>
        /// <param name="userName">The studentName</param>
        /// <returns>A list of fellow students</returns>
        List<Model.Entities.Student> FindFellowStudents(int studentId);

        /// <summary>
        /// Finds the users in the same class.
        /// </summary>
        /// <param name="userName">The username</param>
        /// <returns>A list of fellow users</returns>
        List<Model.Entities.Staff> FindTeacherByStudent(int studentId);

        /// <summary>
        /// Finds the student by studentName.
        /// </summary>
        /// <param name="userName">The studentName</param>
        /// <returns>Student</returns>
        Model.Entities.Student FindStudentByName(string studentName);

        /// <summary>
        /// Finds a list of courses student is registered for.
        /// </summary>
        /// <param name="studentId">Student Id</param>
        /// <returns>A List of Courses</returns>
        List<Model.Entities.Course> FindRegisteredCourses(int studentId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        List<Student> GetStudentsForTeacher(int teacherId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        List<Student> GetStudentsForModule(int moduleId);
    }
}
