// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseViewModelFactory.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  CourseViewModelFactory class definition
//  Contains methods to build Course View Models
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Service.Models;

namespace UniEBoard.Service.Factories
{
    /// <summary>
    /// CourseViewModelFactory - Contains methods to build Course View Models
    /// </summary>
    public static class CourseViewModelFactory
    {
        #region Methods

        /// <summary>
        /// Creates the course view models.
        /// </summary>
        /// <param name="courses">The courses.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static List<CourseViewModel> CreateCourseViewModels(List<Course> courses, IObjectMapperAdapter objectMapper)
        {
            List<CourseViewModel> courseModels = new List<CourseViewModel>();
            foreach (Course courseItem in courses)
            {
                objectMapper.CreateMap<Model.Entities.CourseModule, CourseModuleViewModel>();
                CourseViewModel courseViewModel = objectMapper.Map<Model.Entities.Course, CourseViewModel>(courseItem);
                courseViewModel.Modules = new List<ModuleViewModel>();
                foreach (CourseModule courseModuleItem in courseItem.CourseModules)
                {
                    if (courseModuleItem.Module != null)
                    {
                        courseViewModel.Modules.Add(objectMapper.Map<Model.Entities.Module, ModuleViewModel>(courseModuleItem.Module));
                    }
                }

                if (courseItem.Department != null)
                {
                    courseViewModel.DepartmentName = courseItem.Department.Name;
                }

                if (courseItem.StaffCourses != null && courseItem.StaffCourses.Count >0)
                {
                    foreach (var staffModel in courseItem.StaffCourses)
                    {
                        courseViewModel.StaffUsers = courseViewModel.StaffUsers + staffModel.Staff.FirstName;
                    }
                }

                courseViewModel.StudentCount = courseItem.CourseRegistrations.Count;
                courseModels.Add(courseViewModel);
            }

            return courseModels;
        }


        /// <summary>
        /// Creates the course view models.
        /// </summary>
        /// <param name="course">The course.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static CourseViewModel CreateCourseViewModels(Course course, IObjectMapperAdapter objectMapper)
        {
            CourseViewModel courseViewModel = objectMapper.Map<Model.Entities.Course, CourseViewModel>(course);
            courseViewModel.Modules = new List<ModuleViewModel> ();

            foreach (CourseModule courseModuleItem in course.CourseModules)
            {
                if (courseModuleItem.Module != null)
                {
                    courseViewModel.Modules.Add(ModuleViewModelFactory.CreateModuleViewModels(courseModuleItem.Module, objectMapper));
                    //courseViewModel.Modules.Add(objectMapper.Map<Model.Entities.Module, ModuleViewModel>(courseModuleItem.Module));
                }
            }

            return courseViewModel;
        }


        
        #endregion
    }
}
