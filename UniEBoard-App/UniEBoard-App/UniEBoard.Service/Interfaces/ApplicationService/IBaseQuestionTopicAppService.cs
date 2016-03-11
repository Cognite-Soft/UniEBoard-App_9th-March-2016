// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBaseQuestionTopicAppServiceAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for all BaseQuestionTopic and module related operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Service.Models;

namespace UniEBoard.Service.Interfaces.ApplicationService
{
    /// <summary>
    /// IBaseQuestionTopicAppServiceAppService Interface - Contains Methods for all BaseQuestionTopic and module related operations
    /// </summary>
    public interface IBaseQuestionTopicAppService : IBaseAppService
    {
        /// <summary>
        /// Gets or sets the BaseQuestionTopic manager.
        /// </summary>
        /// <value>The BaseQuestionTopic manager.</value>
        IBaseQuestionTopicDomainService BaseQuestionTopicManager { get; set; }


        List<UniEBoard.Service.Models.BaseQuestionTopicViewModel> GetAllByStudent(int studentId);
    }
}
