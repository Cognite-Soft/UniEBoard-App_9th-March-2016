// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiscussionDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Discussion Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Factories;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Model.Interfaces.Repository;

namespace UniEBoard.Model.DomainServices
{
    /// <summary>
    /// DiscussionDomainService class definition - Contains Methods for Discussion Operations
    /// </summary>
    public class DiscussionDomainService : BaseDomainService<Discussion, IDiscussionRepository>, IDiscussionDomainService
    {
        #region Properties

        /// <summary>
        /// The discussion repository
        /// </summary>
        public IDiscussionRepository DiscussionRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscussionDomainService"/> class.
        /// </summary>
        /// <param name="discussionRepository">The discussion repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public DiscussionDomainService(IDiscussionRepository discussionRepository,  IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(discussionRepository, exceptionManager, loggingService)
        {
            DiscussionRepository = discussionRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the course discussions.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        public List<Discussion> GetCourseDiscussionsWithLatestPosts(int courseId)
        {
            List<Discussion> discussions = new List<Discussion>();
            try
            {
                //GetpropertyAssociations<C.NavigationalProperties.Schedule>(u => u.Course, u => u.Unit, u => u.UnitAndModule)
                discussions = DiscussionRepository.FindDiscussionsByCourse(courseId, new List<string>());

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return discussions;
        }

        /// <summary>
        /// Gets the sub discussions by parent.
        /// </summary>
        /// <param name="parentDiscussionId">The parent discussion id.</param>
        /// <returns></returns>
        public List<Discussion> GetSubDiscussionsWithLatestPosts(int parentDiscussionId)
        {
            List<Discussion> discussions = new List<Discussion>();
            try
            {
                discussions = DiscussionRepository.FindSubDiscussionsByParent(parentDiscussionId, new List<string>());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return discussions;
        }

        /// <summary>
        /// Gets the sub discussions by parent.
        /// </summary>
        /// <returns></returns>
        public List<Discussion> GetSharedDiscussionsWithLatestPosts()
        {
            List<Discussion> discussions = new List<Discussion>();
            try
            {

                discussions = DiscussionRepository.FindDiscussionsWithNoAssociatedCourse(new List<string>());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return discussions;
        }

        /// <summary>
        /// Gets the sub discussions by staff.
        /// </summary>
        /// <param name="parentDiscussionId">The staff id.</param>
        /// <returns></returns>
        public List<Discussion> GetDiscussionsByStaffId(int staffId)
        {
            List<Discussion> discussions = new List<Discussion>();
            try
            {
                discussions = DiscussionRepository.FindDiscussionsByStaffId(staffId, new List<string>());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return discussions;
        }

        /// <summary>
        /// Deletes discussion.
        /// </summary>
        /// <param name="staffId">The discussion id.</param>
        public bool RemoveDiscussion(int discussionId)
        {
            try
            {
                DiscussionRepository.RemoveDiscussion(discussionId);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return false;
        }

        #endregion
    }
}
