// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IModuleDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Modules Operations
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
    /// IModuleDomainService Interface definition - Contains Methods for module Operations
    /// </summary>
    public interface IModuleDomainService : IBaseDomainService<Module>
    {
        /// <summary>
        /// Gets the modules by course.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        List<Module> GetModulesByCourse(int courseId);

        /// <summary>
        /// Gets the modules by course.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        List<ModuleQuiz> GetModulesQuizByModule(int moduleId);

        /// <summary>
        /// Remove Module From Course by moduleId. 
        /// </summary>
        /// <param name="moduleId">Module ID.</param>
        void RemoveModuleFromCourse(int moduleId);
    }
}
