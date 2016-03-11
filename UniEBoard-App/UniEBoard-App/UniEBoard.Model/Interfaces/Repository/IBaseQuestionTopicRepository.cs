// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBaseQuestionTopicRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for BaseQuestionTopic Repository.
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
    /// The BaseQuestionTopic Repository Interface
    /// </summary>
    public interface IBaseQuestionTopicRepository : IBaseRepository<BaseQuestionTopic>
    {
        /// <summary>
        /// Get all the BaseQuestionTopic By student id. 
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        List<BaseQuestionTopic> FindByStudentId(int studentId);

    }
}
