// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITopicDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for Topic Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using UniEBoard.Model.Entities;
using System.Collections.Generic;

namespace UniEBoard.Model.Interfaces.DomainService
{
    /// <summary>
    /// ITopicDomainService interface definition - Contains Methods for Topic Operations
    /// </summary>
    public interface ITopicDomainService : IBaseDomainService<Topic>
    {
        /// <summary>
        /// Gets the topics by topic id.
        /// </summary>
        /// <param name="topicId">The topic id.</param>
        /// <returns></returns>
        List<Model.Entities.Topic> GetTopicsByDiscussionId(int topicId);
    }
}
