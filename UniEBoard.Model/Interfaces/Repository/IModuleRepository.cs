// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICourseRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for Course Repository CRUD operations.
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
    /// The Course Repository Interface
    /// </summary>
    public interface IModuleRepository : IBaseRepository<Module>
    {

         /// <summary>
        /// Get the module by Id
        /// </summary>
        /// <param name="moduleId">The module id.</param>
        /// <returns>Model.Entities.Module</returns>
        Model.Entities.Module GetModuleById(int moduleId);

        /// <summary>
        /// Get the module by course Id
        /// </summary>
        /// <param name="moduleId">The course id.</param>
        /// <returns> List<Model.Entities.Module></returns>
        List<Model.Entities.Module> GetModuleByCourseId(int courseId);

        /// <summary>
        /// Get the ModuleQuiz by module Id
        /// </summary>
        /// <param name="moduleId">The module id.</param>
        /// <returns> List<Model.Entities.ModuleQuiz></returns>
        List<Model.Entities.ModuleQuiz> GetModuleQuizByModuleId(int moduleId);
       
        /// <summary>
        /// Gets the modules by teacher.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <returns></returns>
        List<Model.Entities.Module> GetModulesByTeacher(int teacherId, int view = 0);

        /// <summary>
        /// Gets the modules by student.
        /// </summary>
        /// <param name="teacherId">The student id.</param>
        /// <returns></returns>
        List<Model.Entities.Module> GetModulesByStudent(int studentId, int view = 0);

        /// <summary>
        /// Gets the modules created by teacher.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <returns></returns>
        List<Model.Entities.Module> GetModulesCreatedByTeacher(int teacherId, int view = 0);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        List<Model.Entities.Module> GetModulesAndQuizzesByCourseAndStudent(int studentId, int courseId);
    }
}
