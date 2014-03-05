// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICourseModuleRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for CourseModule Repository CRUD operations.
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
    /// The CourseModule Repository Interface
    /// </summary>
    public interface ICourseModuleRepository : IBaseRepository<CourseModule>
    {
    }
}
