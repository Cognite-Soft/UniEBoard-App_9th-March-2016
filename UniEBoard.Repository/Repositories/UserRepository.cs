// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for User Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Repository;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Repository.Factories;

namespace UniEBoard.Repository.Repositories
{
    /// <summary>
    /// The User Repository Class
    /// </summary>
    public class UserRepository : BaseRepository<UniEBoardDbContext, Repository.User, Model.Entities.User>, IUserRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        public UserRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Finds the users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<Model.Entities.User> FindUsersByCompany(int companyId, int view)
        {
            List<Model.Entities.User> userList = new List<Model.Entities.User>();
            try
            {
                IQueryable<User> userQuery = this.Context.Set<User>().Where(u => u.CompanyId.Equals(companyId)).OrderByDescending(u => u.Id);
                if (view != 0)
                {
                    userQuery = userQuery.Take(view);
                }

                // Return Users
                userList = UserEntityFactory.CreateFromDataModel(userQuery.ToList(), ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return userList;
        }

        /// <summary>
        /// Finds the student users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<Model.Entities.User> FindStudentUsersByCompany(int companyId, int view)
        {
            List<Model.Entities.User> userList = new List<Model.Entities.User>();
            try
            {
                IQueryable<User> userQuery = this.Context.Set<Student>()
                    .Where(u => u.CompanyId.Equals(companyId))
                    .Include(s => s.CourseRegistrations)
                    .Include(p => p.CourseRegistrations.Select(x => x.Course))
                    .OrderByDescending(u => u.Id);

                if (view != 0)
                {
                    userQuery = userQuery.Take(view);
                }

                // Return Users
                userList = UserEntityFactory.CreateFromDataModel(userQuery.ToList(), ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return userList;
        }

        /// <summary>
        /// Finds the student users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<Model.Entities.User> FindStudentUsersByCompany(int companyId, string filter)
        {
            List<Model.Entities.User> userList = new List<Model.Entities.User>();

            try
            {
                IQueryable<User> userQuery;
                
                if (String.IsNullOrEmpty(filter))
                {
                    userQuery = this.Context.Set<Student>()
                    .Where(u => u.CompanyId.Equals(companyId))
                    .Include(s => s.CourseRegistrations)
                    .Include(p => p.CourseRegistrations.Select(x => x.Course))
                    .OrderByDescending(u => u.Id);
                }
                else                 
                {
                    userQuery = this.Context.Set<Student>()
                    .Where(u => u.CompanyId.Equals(companyId) && (u.FirstName.ToLower().Contains(filter.ToLower()) || u.LastName.ToLower().Contains(filter.ToLower()) || u.Email.ToLower().Contains(filter.ToLower())))
                    .Include(s => s.CourseRegistrations)
                    .Include(p => p.CourseRegistrations.Select(x => x.Course))
                    .OrderByDescending(u => u.Id);
                }
                
                
                                
                // Return Users
                userList = UserEntityFactory.CreateFromDataModel(userQuery.ToList(), ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }

            
            return userList;
        }

        /// <summary>
        /// Finds the staff users by company.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<Model.Entities.User> FindStaffUsersByCompany(int companyId, int view)
        {
            List<Model.Entities.User> userList = new List<Model.Entities.User>();
            try
            {
                IQueryable<User> userQuery = this.Context.Set<Staff>()
                    .Where(u => u.CompanyId.Equals(companyId))
                    .Include(s => s.StaffCourses)
                    .Include(p => p.StaffCourses.Select(x => x.Course))
                    .OrderByDescending(u => u.Id);

                if (view != 0)
                {
                    userQuery = userQuery.Take(view);
                }
                // Return Users
                userList = UserEntityFactory.CreateFromDataModel(userQuery.ToList(), ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return userList;
        }

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public override Model.Entities.User Add(Model.Entities.User model)
        {
            User newEntity = UserEntityFactory.CreateFromDomainModel(model, ObjectMapper);
            DbEntityEntry entry = Context.Entry<User>(newEntity);
            if (entry.State == System.Data.Entity.EntityState.Detached)
            {
                Context.Entry<User>(newEntity).State = System.Data.Entity.EntityState.Added;
                Context.SaveChanges();
            }
            return UserEntityFactory.CreateFromDataModel(newEntity, ObjectMapper);
        }

        /// <summary>
        /// Finds the by.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public override Model.Entities.User FindBy(int id)
        {
            User entity = Context.Set<User>().Find(id);
            return UserEntityFactory.CreateFromDataModel(entity, ObjectMapper);
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns></returns>
        public override IQueryable<Model.Entities.User> FindAll()
        {
            List<Model.Entities.User> userList = new List<Model.Entities.User>();
            try
            {
                IQueryable<User> userQuery = this.Context.Set<User>().OrderByDescending(u => u.Id);

                // Return Users
                userList = UserEntityFactory.CreateFromDataModel(userQuery.ToList(), ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return userList.AsQueryable();
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public override void Update(Model.Entities.User model)
        {
            // Detach existing Entity
            User existingEntity = Context.Set<User>().Find(ObjectMapper.GetEntityIdentifier<Model.Entities.User>(model));
            System.Data.Entity.EntityState existingState = Context.Entry<User>(existingEntity).State;
            if (existingState != System.Data.Entity.EntityState.Detached)
            {
                Context.Entry<User>(existingEntity).State = System.Data.Entity.EntityState.Detached;
            }

            User updatedEntity = UserEntityFactory.CreateFromDomainModel(model, ObjectMapper);
            DbEntityEntry entry = Context.Entry<User>(updatedEntity);
            if (entry.State == System.Data.Entity.EntityState.Detached)
            {
                //Context.Set<User>().Attach(updatedEntity);
                Context.Entry<User>(updatedEntity).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
            }
        }

        /// <summary>
        /// Finds the user by member ship id.
        /// </summary>
        /// <param name="membershipId">The membership id.</param>
        /// <returns></returns>
        public Model.Entities.User FindUserByMemberShipId(int membershipId)
        {
            Model.Entities.User user = null;
            try
            {
                IQueryable<User> users = this.Context.Set<User>().Where(p => p.Membership_Id == membershipId).Take(1);
                User userEntity = users.ToList().FirstOrDefault();
                user = UserEntityFactory.CreateFromDataModel(userEntity, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return user;
        }

        /// <summary>
        /// Finds the user by UserName.
        /// </summary>
        /// <param name="userName">The username</param>
        /// <returns></returns>
        public Model.Entities.User FindUserByUserName(string userName)
        {
            Model.Entities.User user = null;

            try
            {
                /*IQueryable<User> users = this.Context.Set<Student>()
                    .Where(u => u.UserName.ToLower().Equals(userName.ToLower()))
                    .Include(s => s.CourseRegistrations)
                    .Include(p => p.CourseRegistrations.Select(x => x.Course))
                    .Take(1);*/
                IQueryable<User> users = this.Context.Set<User>().Include(u => u.Roles)
                    .Where(u => u.UserName.ToLower().Equals(userName.ToLower()))
                    .Take(1);
                User userEntity = users.ToList().FirstOrDefault();
                user = UserEntityFactory.CreateFromDataModel(userEntity, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return user;
        }
        /// <summary>
        /// Finds the user by email id.
        /// </summary>
        /// <param name="emailId">The email id.</param>
        /// <returns></returns>
        public Model.Entities.User FindUserByEmailId(string emailId)
        {
            Model.Entities.User user = null;
            try
            {
                User userEntity = this.Context.Set<User>().FirstOrDefault(x => x.Email.ToLower() == emailId.ToLower());
                user = UserEntityFactory.CreateFromDataModel(userEntity, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return user;
        }

        /// <summary>
        /// Finds the user by course.
        /// </summary>
        /// <param name="emailId">The course id.</param>
        /// <returns>List of User</returns>
        public List<Model.Entities.User> FindUsersByCourse(int courseId)
        {
            List<User> usersEntities = new List<User>();
            List<Model.Entities.User> users = new List<Model.Entities.User>();
            try
            {
                var course = Context.Set<Course>()
                    .Include(c => c.CourseRegistrations.Select(cr => cr.Student))
                    .Include(c => c.StaffCourses.Select(sc => sc.Staff))
                    .Where(c => c.CourseRegistrations.Any(cr => cr.Course_Id.Equals(courseId)) || c.StaffCourses.Any(cr => cr.Course_Id.Equals(courseId))).FirstOrDefault();
                var students = (from s in course.CourseRegistrations
                               select s.Student).ToList();
                var teachers = from t in course.StaffCourses
                               select t.Staff;

                usersEntities.AddRange(students);
                usersEntities.AddRange(teachers);
                users = ObjectMapper.Map<User, Model.Entities.User>(usersEntities);
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
        public List<Model.Entities.Role> FindAllAvailableRoles()
        {
            List<Model.Entities.Role> roles = new List<Model.Entities.Role>();
            try
            {
                var systemRoles = Context.Set<Role>().ToList();
                roles = ObjectMapper.Map<Role, Model.Entities.Role>(systemRoles);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }

            return roles;
        }

        /// <summary>
        /// Find all available roles in the system
        /// </summary>
        /// <returns>A list of all available roles</returns>
        public Model.Entities.Role FindRoleByName(string roleName)
        {
            Model.Entities.Role role = null;
            try
            {
                var systemRole = Context.Set<Role>().Where(r => r.Title.ToLower().Equals(roleName.ToLower())).FirstOrDefault();
                role = ObjectMapper.Map<Role, Model.Entities.Role>(systemRole);
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
                var user = Context.Set<User>().Where(u => u.Id.Equals(userId)).FirstOrDefault();
                var role = Context.Set<Role>().Where(r => r.Title.ToLower().Equals(roleName.ToLower())).FirstOrDefault();
                user.Roles.Add(role);
                Context.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
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
