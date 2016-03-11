// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for User Application Service Operations
//  Transforms entity domain models to view models
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
using UniEBoard.Service.Factories;
using UniEBoard.Model.Adapters.Logging;
using UniEBoard.Service.Factories;

namespace UniEBoard.Service.ApplicationServices
{
    /// <summary>
    /// User Application Service Class - Contains Methods for User Service Operations
    /// </summary>
    public class UserAppService : BaseAppService, IUserAppService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the user manager.
        /// </summary>
        /// <value>The user manager.</value>
        public IUserDomainService UserManager { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAppService"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="cacheService">The cache service.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public UserAppService(
            IUserDomainService userManager,
            IObjectMapperAdapter objectMapper,
            ICacheAdapter cacheService,
            IExceptionManagerAdapter exceptionManager,
            ILoggingServiceAdapter loggingService)
            : base(objectMapper, cacheService, exceptionManager, loggingService)
        {
            this.UserManager = userManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<UserViewModel> GetAllUsersByCompany(int companyId, int view)
        {

            List<UserViewModel> models = new List<UserViewModel>();
            try
            {
                List<User> users = UserManager.GetAllUsersByCompany(companyId, view);
                models = UserViewModelFactory.CreateFromDomainModel(users, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }


        /// <summary>
        /// Gets the student users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<UserViewModel> GetStudentUsersByCompany(int companyId, int view)
        {

            List<UserViewModel> models = new List<UserViewModel>();
            try
            {
                List<User> users = UserManager.GetStudentUsersByCompany(companyId, view);
                models = UserViewModelFactory.CreateFromDomainModel(users, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets the student users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<UserViewModel> GetStudentUsersByCompany(int companyId, string filter)
        {

            List<UserViewModel> models = new List<UserViewModel>();
            try
            {
                List<User> users = UserManager.GetStudentUsersByCompany(companyId, filter);
                models = UserViewModelFactory.CreateFromDomainModel(users, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets the staff users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<UserViewModel> GetStaffUsersByCompany(int companyId, int view)
        {

            List<UserViewModel> models = new List<UserViewModel>();
            try
            {
                List<User> users = UserManager.GetStaffUsersByCompany(companyId, view);
                models = UserViewModelFactory.CreateFromDomainModel(users, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets the user by member ship id.
        /// </summary>
        /// <param name="membershipId">The membership id.</param>
        /// <returns></returns>
        public UserViewModel GetUserByMemberShipId(int membershipId)
        {
            UserViewModel model = default(UserViewModel);
            try
            {
                User user = UserManager.GetUserByMemberShipId(membershipId);
                model = UserViewModelFactory.CreateFromDomainModel(user, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return model;
        }

        /// <summary>
        /// Gets the user by id.
        /// </summary>
        /// <param name="membershipId">The user id.</param>
        /// <returns></returns>
        public UserViewModel GetUserById(int userId)
        {
            UserViewModel model = default(UserViewModel);
            try
            {
                User user = UserManager.FindBy(userId);
                model = UserViewModelFactory.CreateFromDomainModel(user, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return model;
        }
        /// Gets the user by UserName.
        /// </summary>
        /// <param name="userName">The username.</param>
        /// <returns></returns>
        public UserViewModel GetUserByUserName(string userName)
        {
            UserViewModel model = default(UserViewModel);
            try
            {
                User user = UserManager.GetUserByUserName(userName);
                model = UserViewModelFactory.CreateFromDomainModel(user, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return model;
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="membershipProviderId">The membership provider id.</param>
        /// <param name="model">The model.</param>
        public UserViewModel CreateUser(int membershipProviderId, UserViewModel model)
        {
            try
            {
                User user = UserViewModelFactory.CreateFromViewModelModel(model, ObjectMapper);
                user.Membership_Id = membershipProviderId;
                User createdUser = UserManager.Add(user);
                return UserViewModelFactory.CreateFromDomainModel(createdUser, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return null;
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="model">The model.</param>
        public void UpdateUser(UserViewModel model)
        {
            try
            {
                User user = UserViewModelFactory.CreateFromViewModelModel(model, ObjectMapper);
                UserManager.Update(user);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        /// <summary>
        /// Delete the association of the user from the course
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="courseId">Course Id</param>
        /// <returns>true if the deletion is successfull otherwise false</returns>
        public bool RemoveUserFromCourse(int userId, int courseId)
        {
            try
            {
                return UserManager.RemoveUserFromCourse(userId, courseId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return false;
        }

        /// <summary>
        /// Gets the user by email id.
        /// </summary>
        /// <param name="emailId">The emailId id.</param>
        /// <returns></returns>
        public UserViewModel GetUserByEmailId(string emailId)
        {
            UserViewModel model = default(UserViewModel);
            try
            {
                User user = UserManager.GetUserByEmailId(emailId);
                model = UserViewModelFactory.CreateFromDomainModel(user, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return model;
        }

        /// <summary>
        /// Finds the user by course.
        /// </summary>
        /// <param name="emailId">The course id.</param>
        /// <returns>List of User</returns>
        public List<UserViewModel> GetUsersByCourse(int courseId)
        {
            List<UserViewModel> models = new List<UserViewModel>();
            try
            {
                List<User> users = UserManager.GetUsersByCourse(courseId);
                models = UserViewModelFactory.CreateFromDomainModel(users, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Find all available roles in the system
        /// </summary>
        /// <returns>A list of all available roles</returns>
        public List<RoleViewModel> GetAllAvailableRoles()
        {
            List<RoleViewModel> roles = new List<RoleViewModel>();
            try
            {
                var entities = UserManager.GetAllAvailableRoles();
                roles = ObjectMapper.Map<Role, RoleViewModel>(entities);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return roles;
        }

        /// <summary>
        /// Find a role by name
        /// </summary>
        /// <returns>user role</returns>
        public RoleViewModel GetRoleByName(string roleName)
        {
            RoleViewModel role = null;
            try
            {
                var entity = UserManager.GetRoleByName(roleName);
                role = ObjectMapper.Map<Role, RoleViewModel>(entity);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return role;
        }

        /// <summary>
        /// Assigns a role to user
        /// </summary>
        /// <param name="roleName">role name</param>
        /// <returns>true if role is successfully assigned otherwise false</returns>
        public bool AssignRole(int userId, string roleName)
        {
            try
            {
                return UserManager.AssignRole(userId, roleName);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return false;
        }

        #endregion
    }
}
