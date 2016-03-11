// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for User Repository CRUD operations.
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
    /// The User Repository Interface
    /// </summary>
    public interface IUserRepository : IBaseRepository<User>
    {
        /// <summary>
        /// Finds the users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<Model.Entities.User> FindUsersByCompany(int companyId, int view);

        /// <summary>
        /// Finds the user by member ship id.
        /// </summary>
        /// <param name="membershipId">The membership id.</param>
        /// <returns></returns>
        Model.Entities.User FindUserByMemberShipId(int membershipId);

        /// <summary>
        /// Finds the student users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<Model.Entities.User> FindStudentUsersByCompany(int companyId, int view);

        /// <summary>
        /// Finds the student users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<Model.Entities.User> FindStudentUsersByCompany(int companyId, string filter);

        /// <summary>
        /// Finds the staff users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        List<Model.Entities.User> FindStaffUsersByCompany(int companyId, int view);

        /// <summary>
        /// Finds the user by UserName.
        /// </summary>
        /// <param name="userName">The username</param>
        /// <returns></returns>
        Model.Entities.User FindUserByUserName(string userName);

        /// Gets the user by email id.
        /// </summary>
        /// <param name="emailId">The email id.</param>
        /// <returns></returns>
        /// 
        Model.Entities.User FindUserByEmailId(string emailId);

        /// <summary>
        /// Finds the user by course.
        /// </summary>
        /// <param name="emailId">The course id.</param>
        /// <returns>List of User</returns>
        List<Model.Entities.User> FindUsersByCourse(int courseId);

        /// <summary>
        /// Find all available roles in the system
        /// </summary>
        /// <returns>A list of all available roles</returns>
        List<Model.Entities.Role> FindAllAvailableRoles();

        /// <summary>
        /// Find all available roles in the system
        /// </summary>
        /// <returns>A list of all available roles</returns>
        Model.Entities.Role FindRoleByName(string roleName);

        /// <summary>
        /// Assigns a role to user
        /// </summary>
        /// <param name="roleName">role name</param>
        /// <returns>true if role is successfully assigned otherwise false</returns>
        bool AssignRole(int userId, string roleName);

    }
}
