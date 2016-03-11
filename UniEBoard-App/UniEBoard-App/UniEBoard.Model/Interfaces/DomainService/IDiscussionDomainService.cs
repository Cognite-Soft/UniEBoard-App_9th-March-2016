// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDiscussionDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for Discussion Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using UniEBoard.Model.Entities;

namespace UniEBoard.Model.Interfaces.DomainService
{
    /// <summary>
    /// IDiscussionDomainService interface definition - Contains Methods for Discussion Operations
    /// </summary>
    public interface IDiscussionDomainService : IBaseDomainService<Discussion>
    {
        /// <summary>
        /// Gets the course discussions.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        List<Discussion> GetCourseDiscussionsWithLatestPosts(int courseId);

        /// <summary>
        /// Gets the sub discussions by parent.
        /// </summary>
        /// <param name="parentDiscussionId">The parent discussion id.</param>
        /// <returns></returns>
        List<Discussion> GetSubDiscussionsWithLatestPosts(int parentDiscussionId);

        /// <summary>
        /// Gets the sub discussions by parent.
        /// </summary>
        /// <returns></returns>
        List<Discussion> GetSharedDiscussionsWithLatestPosts();

        /// <summary>
        /// Gets the sub discussions by staff.
        /// </summary>
        /// <param name="parentDiscussionId">The staff id.</param>
        /// <returns></returns>
        List<Discussion> GetDiscussionsByStaffId(int staffId);

        /// <summary>
        /// Deletes discussion.
        /// </summary>
        /// <param name="staffId">The discussion id.</param>
        bool RemoveDiscussion(int discussionId);
    }
}
