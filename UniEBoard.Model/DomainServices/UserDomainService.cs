// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for User Operations
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
using UniEBoard.Model.Interfaces.Repository;

namespace UniEBoard.Model.DomainServices
{
    /// <summary>
    /// UserDomainService class definition - Contains Methods for User Operations
    /// </summary>
    public class UserDomainService : BaseDomainService<User, IUserRepository>, IUserDomainService
    {
        #region Properties

        /// <summary>
        /// UserRepository instance
        /// </summary>
        public IUserRepository UserRepository;
        public ICourseRepository CourseRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDomainService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public UserDomainService(ICourseRepository courseRepository, IUserRepository userRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(userRepository, exceptionManager, loggingService)
        {
            UserRepository = userRepository;
            this.CourseRepository = courseRepository;
        }

        /// <summary>
        /// Gets all users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<User> GetAllUsersByCompany(int companyId, int view)
        {
            List<User> users = new List<User>();
            try
            {
                users = UserRepository.FindUsersByCompany(companyId, view);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return users;
        }

        /// <summary>
        /// Gets the user by member ship id.
        /// </summary>
        /// <param name="membershipId">The membership id.</param>
        /// <returns></returns>
        public User GetUserByMemberShipId(int membershipId)
        {
            User user = null;
            try
            {
                user = UserRepository.FindUserByMemberShipId(membershipId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return user;
        }

        /// <summary>
        /// Gets the student users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<User> GetStudentUsersByCompany(int companyId, int view)
        {
            List<User> users = new List<User>();
            try
            {
                users = UserRepository.FindStudentUsersByCompany(companyId, view);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return users;
        }

        /// <summary>
        /// Gets the student users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<User> GetStudentUsersByCompany(int companyId, string filter)
        {
            List<User> users = new List<User>();
            try
            {
                users = UserRepository.FindStudentUsersByCompany(companyId, filter);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return users;
        }

        /// <summary>
        /// Gets the staff users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<User> GetStaffUsersByCompany(int companyId, int view)
        {
            List<User> users = new List<User>();
            try
            {
                users = UserRepository.FindStaffUsersByCompany(companyId, view);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return users;
        }

        /// <summary>
        /// Gets the user by username.
        /// </summary>
        /// <param name="userName">The username.</param>
        /// <returns></returns>
        public User GetUserByUserName(string userName)
        {
            User user = null;
            try
            {
                user = UserRepository.FindUserByUserName(userName);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return user;
        }


        /// Gets the user by email id.
        /// </summary>
        /// <param name="emailId">The email id.</param>
        /// <returns></returns>
        public User GetUserByEmailId(string emailId)
        {
            User user = null;
            try
            {
                user = UserRepository.FindUserByEmailId(emailId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return user;
        }

        /// <summary>
        /// Remove a course association with staff
        /// </summary>
        /// <param name="studentId">The staff id.</param>
        /// <param name="course">course assigned to staffId</param>
        /// <returns>true if deletion is successful otherwise false</returns>
        public bool RemoveUserFromCourse(int userId, int courseId)
        {
            try
            {
                return CourseRepository.RemoveUserFromCourse(userId, courseId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return false;
        }

        /// <summary>
        /// Finds the user by course.
        /// </summary>
        /// <param name="emailId">The course id.</param>
        /// <returns>List of User</returns>
        public List<Model.Entities.User> GetUsersByCourse(int courseId)
        {
            List<User> users = new List<User>();
            try
            {
                users = UserRepository.FindUsersByCourse(courseId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return users;
        }

        /// <summary>
        /// Find all available roles in the system
        /// </summary>
        /// <returns>A list of all available roles</returns>
        public List<Model.Entities.Role> GetAllAvailableRoles()
        {
            List<Role> roles = new List<Role>();
            try
            {
                roles = UserRepository.FindAllAvailableRoles();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return roles;
        }

        /// <summary>
        /// Find a role by name
        /// </summary>
        /// <returns>user role</returns>
        public Model.Entities.Role GetRoleByName(string roleName)
        {
            Role role = null;
            try
            {
                role = UserRepository.FindRoleByName(roleName);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
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
                return UserRepository.AssignRole(userId, roleName);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return false;
        }

        #endregion
    }
}
