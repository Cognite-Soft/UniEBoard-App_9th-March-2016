// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserViewModelFactory.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  UserViewModelFactory class definition
//  Contains methods to build User Entities
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Service.Models;

namespace UniEBoard.Service.Factories
{
    /// <summary>
    /// 
    /// </summary>
    public static class UserViewModelFactory
    {
        #region Methods

        /// <summary>
        /// Creates from domain model.
        /// </summary>
        /// <param name="asset">The user.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static UserViewModel CreateFromDomainModel(User user, IObjectMapperAdapter objectMapper)
        {
            if (user is Student)
            {
                StudentViewModel student = objectMapper.Map<Student, StudentViewModel>((Student)user);
                student.Courses = CreateStudentCourses((Student)user, objectMapper);
                return student;
            }
            else if (user is Staff)
            {
                StaffViewModel staff = objectMapper.Map<Staff, StaffViewModel>((Staff)user);
                staff.Courses = CreateStaffCourses((Staff)user, objectMapper);
                return staff;
            }
            else
            {
                return objectMapper.Map<User, UserViewModel>(user);
            }
        }

        /// <summary>
        /// Creates from domain model.
        /// </summary>
        /// <param name="asset">The user.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static List<UserViewModel> CreateFromDomainModel(List<User> user, IObjectMapperAdapter objectMapper)
        {
            return user.Select(u => CreateFromDomainModel(u, objectMapper)).ToList<UserViewModel>();
        }

        /// <summary>
        /// Creates from view model model.
        /// </summary>
        /// <param name="asset">The user.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static User CreateFromViewModelModel(UserViewModel user, IObjectMapperAdapter objectMapper)
        {
            if (user is StudentViewModel)
            {
                return objectMapper.Map<StudentViewModel, Student>((StudentViewModel)user);
            }
            else if (user is StaffViewModel)
            {
                return objectMapper.Map<StaffViewModel, Staff>((StaffViewModel)user);
            }
            else
            {
                return objectMapper.Map<UserViewModel, User>(user);
            }
        }

        /// <summary>
        /// Creates from view model model.
        /// </summary>
        /// <param name="asset">The user.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static List<User> CreateFromViewModelModel(List<UserViewModel> user, IObjectMapperAdapter objectMapper)
        {
            return user.Select(u => CreateFromViewModelModel(u, objectMapper)).ToList<User>();
        }

        /// <summary>
        /// Gets or sets the create student courses.
        /// </summary>
        /// <value>The create student courses.</value>
        private static List<CourseViewModel> CreateStudentCourses(Student user, IObjectMapperAdapter objectMapper)
        {
            List<CourseViewModel> courses = new List<CourseViewModel>();
            if (user != null && user.CourseRegistrations != null)
            {
                foreach (var courseRegistration in user.CourseRegistrations)
                {
                    if (courseRegistration.Course != null)
                    {
                        courses.Add(objectMapper.Map<Course, CourseViewModel>(courseRegistration.Course));
                    }
                }
            }
            return courses;
        }

        /// <summary>
        /// Creates the staff courses.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        private static List<CourseViewModel> CreateStaffCourses(Staff user, IObjectMapperAdapter objectMapper)
        {
            List<CourseViewModel> courses = new List<CourseViewModel>();
            if (user != null && user.StaffCourses != null)
            {
                foreach (var staffCourses in user.StaffCourses)
                {
                    if (staffCourses.Course != null)
                    {
                        courses.Add(objectMapper.Map<Course, CourseViewModel>(staffCourses.Course));
                    }
                }
            }
            return courses;
        }

        #endregion
    }
}
