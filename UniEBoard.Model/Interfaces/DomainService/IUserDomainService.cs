// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for User Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;

namespace UniEBoard.Model.Interfaces.DomainService
{
    /// <summary>
    /// IUserDomainService Interface definition - Contains Methods for User Operations
    /// </summary>
    public interface IUserDomainService : IBaseDomainService<User>
    {
        /// <summary>
        /// Gets all users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<User> GetAllUsersByCompany(int companyId, int view);

        /// <summary>
        /// Gets the user by member ship id.
        /// </summary>
        /// <param name="membershipId">The membership id.</param>
        /// <returns></returns>
        User GetUserByMemberShipId(int membershipId);

        /// <summary>
        /// Gets the student users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<User> GetStudentUsersByCompany(int companyId, int view);


        /// <summary>
        /// Gets the student users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<User> GetStudentUsersByCompany(int companyId, string filter);

        /// <summary>
        /// Gets the staff users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<User> GetStaffUsersByCompany(int companyId, int view);

        /// <summary>
        /// Gets the user by username.
        /// </summary>
        /// <param name="userName">The username.</param>
        /// <returns></returns>
        User GetUserByUserName(string userName);

        /// Gets the user by email id.
        /// </summary>
        /// <param name="emailId">The email id.</param>
        /// <returns></returns>
        /// 
        User GetUserByEmailId(string emailId);

        /// <summary>
        /// Remove a course association with staff
        /// </summary>
        /// <param name="studentId">The staff id.</param>
        /// <param name="course">course assigned to staffId</param>
        /// <returns>true if deletion is successful otherwise false</returns>
        bool RemoveUserFromCourse(int userId, int courseId);

        /// <summary>
        /// Finds the user by course.
        /// </summary>
        /// <param name="emailId">The course id.</param>
        /// <returns>List of User</returns>
        List<Model.Entities.User> GetUsersByCourse(int courseId);

        /// <summary>
        /// Find all available roles in the system
        /// </summary>
        /// <returns>A list of all available roles</returns>
        List<Model.Entities.Role> GetAllAvailableRoles();

        /// <summary>
        /// Find a role by name
        /// </summary>
        /// <returns>user role</returns>
        Model.Entities.Role GetRoleByName(string roleName);

        /// <summary>
        /// Assigns a role to user
        /// </summary>
        /// <param name="roleName">role name</param>
        /// <returns>true if role is successfully assigned otherwise false</returns>
        bool AssignRole(int userId, string roleName);
    }
}
