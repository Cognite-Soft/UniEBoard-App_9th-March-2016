// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITopicRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for Topic Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using UniEBoard.Model.Entities;
using System.Collections.Generic;

namespace UniEBoard.Model.Interfaces.Repository
{
    /// <summary>
    /// The Topic Repository Interface
    /// </summary>
    public interface ITopicRepository : IBaseRepository<Topic>
    {
        List<UniEBoard.Model.Entities.Topic> GetTopicsByDiscussionId(int topicId);
    }
}
