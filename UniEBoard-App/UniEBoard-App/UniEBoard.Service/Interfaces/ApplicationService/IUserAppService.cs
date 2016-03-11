// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for User Application Service Operations
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
    /// IUserAppService Interface - Contains Methods for User Application Service Operations
    /// </summary>
    public interface IUserAppService : IBaseAppService
    {
        IUserDomainService UserManager { get; set; }

        /// <summary>
        /// Gets all users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<UserViewModel> GetAllUsersByCompany(int companyId, int view);

        /// <summary>
        /// Gets the student users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<UserViewModel> GetStudentUsersByCompany(int companyId, int view);

        /// <summary>
        /// Gets the student users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<UserViewModel> GetStudentUsersByCompany(int companyId, string filter);

        /// <summary>
        /// Gets the staff users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<UserViewModel> GetStaffUsersByCompany(int companyId, int view);

        /// <summary>
        /// Gets the user by member ship id.
        /// </summary>
        /// <param name="membershipId">The membership id.</param>
        /// <returns></returns>
        UserViewModel GetUserByMemberShipId(int membershipId);

        /// <summary>
        /// Gets the user by id.
        /// </summary>
        /// <param name="membershipId">The user id.</param>
        /// <returns></returns>
        UserViewModel GetUserById(int userId);

        /// Gets the user by UserName.
        /// </summary>
        /// <param name="userName">The username.</param>
        /// <returns></returns>
        UserViewModel GetUserByUserName(string userName);

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="membershipProviderId">The membership provider id.</param>
        /// <param name="model">The model.</param>
        UserViewModel CreateUser(int membershipProviderId, UserViewModel model);

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="membershipProviderId">The membership provider id.</param>
        /// <param name="model">The model.</param>
        void UpdateUser(UserViewModel model);

        /// <summary>
        /// Delete the association of the user from the course
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="courseId">Course Id</param>
        /// <returns>true if the deletion is successfull otherwise false</returns>
        bool RemoveUserFromCourse(int userId, int courseId);

        /// <summary>
        /// Gets the user by email id.
        /// </summary>
        /// <param name="emailId">The email id.</param>
        /// <param name="model">The model.</param>
        /// 
        UserViewModel GetUserByEmailId(string emailId);

        /// <summary>
        /// Finds the user by course.
        /// </summary>
        /// <param name="emailId">The course id.</param>
        /// <returns>List of User</returns>
        List<UserViewModel> GetUsersByCourse(int courseId);

        /// <summary>
        /// Find all available roles in the system
        /// </summary>
        /// <returns>A list of all available roles</returns>
        List<RoleViewModel> GetAllAvailableRoles();

        /// <summary>
        /// Find a role by name
        /// </summary>
        /// <returns>user role</returns>
        RoleViewModel GetRoleByName(string roleName);

        /// <summary>
        /// Assigns a role to user
        /// </summary>
        /// <param name="roleName">role name</param>
        /// <returns>true if role is successfully assigned otherwise false</returns>
        bool AssignRole(int userId, string roleName);
    }
}
