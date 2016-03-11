// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBaseQuestionTopicDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for BaseQuestionTopic Operations
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
    /// IBaseQuestionTopicDomainService interface definition - Contains Methods for BaseQuestionTopic Operations
    /// </summary>
    public interface IBaseQuestionTopicDomainService : IBaseDomainService<BaseQuestionTopic>
    {
        /// <summary>
        /// Get the questions by the user log in 
        /// </summary>
        /// <param name="studentId">The user Id. </param>
        /// <returns></returns>
        List<BaseQuestionTopic> GetAllByStudent(int studentId);

    }
}
