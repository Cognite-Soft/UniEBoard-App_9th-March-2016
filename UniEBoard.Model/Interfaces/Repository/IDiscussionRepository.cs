// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDiscussionRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for Discussion Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using UniEBoard.Model.Entities;

namespace UniEBoard.Model.Interfaces.Repository
{
    /// <summary>
    /// The Discussion Repository Interface
    /// </summary>
    public interface IDiscussionRepository : IBaseRepository<Discussion>
    {
        /// <summary>
        /// Finds the discussions by course.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <param name="includeAssociations">The include associations.</param>
        /// <returns></returns>
        List<Discussion> FindDiscussionsByCourse(int courseId, List<string> includeAssociations);

        /// <summary>
        /// Finds the sub discussions byparent.
        /// </summary>
        /// <param name="discussionId">The discussion id.</param>
        /// <param name="includeAssociations">The include associations.</param>
        /// <returns></returns>
        List<Discussion> FindSubDiscussionsByParent(int discussionId, List<string> includeAssociations);

        /// <summary>
        /// Finds the discussions with no associated course.
        /// </summary>
        /// <param name="includeAssociations">The include associations.</param>
        /// <returns></returns>
        List<Model.Entities.Discussion> FindDiscussionsWithNoAssociatedCourse(List<string> includeAssociations);

        /// <summary>
        /// Finds the sub discussions by staff.
        /// </summary>
        /// <param name="staffId">The discussion id.</param>
        /// <param name="includeAssociations">The include associations.</param>
        /// <returns>List of Discussions</returns>
        List<Discussion> FindDiscussionsByStaffId(int staffId, List<string> includeAssociations);

        /// <summary>
        /// Deletes discussion.
        /// </summary>
        /// <param name="staffId">The discussion id.</param>
        void RemoveDiscussion(int discussionId);
    }
}
