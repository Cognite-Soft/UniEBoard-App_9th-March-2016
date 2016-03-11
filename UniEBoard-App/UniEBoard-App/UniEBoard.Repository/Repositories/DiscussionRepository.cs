// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiscussionRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for Discussion Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Repository;
using UniEBoard.Model.Interfaces.Adapter;
using System.Data.Entity;
using System.Data.Objects.DataClasses;

namespace UniEBoard.Repository.Repositories
{
    /// <summary>
    /// The Discussion Repository Class
    /// </summary>
    public class DiscussionRepository : BaseRepository<UniEBoardDbContext, Repository.Discussion, Model.Entities.Discussion>, IDiscussionRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscussionRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        public DiscussionRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Finds the discussions by course.
        /// </summary>
        /// <param name="courseId">The course id.</param>
        /// <param name="includeAssociations">The include associations.</param>
        /// <returns></returns>
        public List<Model.Entities.Discussion> FindDiscussionsByCourse(int courseId, List<string> includeAssociations)
        {
            List<Model.Entities.Discussion> discussionList = new List<Model.Entities.Discussion>();
            try
            {
                IQueryable<Discussion> discussions =
                    Context.Set<Discussion>()
                        .Where(
                            cr =>
                                courseId == 0
                                    ? cr.CourseId.HasValue
                                    : cr.CourseId.HasValue && cr.CourseId.Value == courseId);
                includeAssociations.ForEach(p => discussions = discussions.Include(p));

                // Return Discussions
                discussionList = ObjectMapper.Map<Discussion, Model.Entities.Discussion>(discussions.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return discussionList;
        }

        /// <summary>
        /// Finds the sub discussions byparent.
        /// </summary>
        /// <param name="discussionId">The discussion id.</param>
        /// <param name="includeAssociations">The include associations.</param>
        /// <returns></returns>
        public List<Model.Entities.Discussion> FindSubDiscussionsByParent(int discussionId, List<string> includeAssociations)
        {
            List<Model.Entities.Discussion> discussionList = new List<Model.Entities.Discussion>();
            try
            {
                IQueryable<Discussion> discussions = Context.Set<Discussion>().Where(cr => cr.ParentDiscussionId.HasValue && cr.ParentDiscussionId.Value == discussionId);
                // Return Discussions
                discussionList = ObjectMapper.Map<Discussion, Model.Entities.Discussion>(discussions.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return discussionList;
        }

        /// <summary>
        /// Finds the discussions with no associated course.
        /// </summary>
        /// <param name="includeAssociations">The include associations.</param>
        /// <returns></returns>
        public List<Model.Entities.Discussion> FindDiscussionsWithNoAssociatedCourse(List<string> includeAssociations)
        {
            List<Model.Entities.Discussion> discussionList = new List<Model.Entities.Discussion>();
            try
            {
                IQueryable<Discussion> discussions =Context.Set<Discussion>().Where(cr => !cr.CourseId.HasValue);
                includeAssociations.ForEach(p => discussions = discussions.Include(p));
                
                // Return Discussions
                discussionList = ObjectMapper.Map<Discussion, Model.Entities.Discussion>(discussions.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return discussionList;
        }

        /// <summary>
        /// Finds the sub discussions by staff.
        /// </summary>
        /// <param name="staffId">The discussion id.</param>
        /// <param name="includeAssociations">The include associations.</param>
        /// <returns>List of Discussions</returns>
        public List<Model.Entities.Discussion> FindDiscussionsByStaffId(int staffId, List<string> includeAssociations)
        {
            List<Model.Entities.Discussion> discussionList = new List<Model.Entities.Discussion>();
            try
            {
                /*IQueryable<User> userQuery = this.Context.Set<Student>()
                    .Where(u => u.CompanyId.Equals(companyId))
                    .Include(s => s.CourseRegistrations)
                    .Include(p => p.CourseRegistrations.Select(x => x.Course))
                    .OrderByDescending(u => u.Id);*/


                IQueryable<Discussion> discussions = from sc in this.Context.Set<StaffCourse>().Where(s => s.Staff_Id.Equals(staffId))
                                                     join c in this.Context.Set<Course>()
                                                     on sc.Course_Id equals c.Id
                                                     join d in this.Context.Set<Discussion>()
                                                     on c.Id equals d.CourseId
                                                     select d;
                includeAssociations.ForEach(p => discussions = discussions.Include(p));
                // Return Discussions
                discussionList = ObjectMapper.Map<Discussion, Model.Entities.Discussion>(discussions.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return discussionList;
        }

        /// <summary>
        /// Deletes discussion.
        /// </summary>
        /// <param name="staffId">The discussion id.</param>
        public void RemoveDiscussion(int discussionId)
        {
            var discussion = Context.Set<Discussion>().Find(discussionId);
            var topics = Context.Set<Topic>().Where(t => t.DiscussionId.Equals(discussionId)).ToList();
            foreach (var topic in topics)
            {
                var topicPosts = Context.Set<TopicPost>().Where(t => t.TopicId.Equals(topic.Id)).ToList();
                foreach (var topicPost in topicPosts)
                {
                    Context.Set<TopicPost>().Remove(topicPost);
                }
                Context.Set<Topic>().Remove(topic);
                Context.SaveChanges();
            }
            
            var entity = ObjectMapper.Map<Discussion, UniEBoard.Model.Entities.Discussion>(discussion);
            Remove(entity);
        }
      
        #endregion
    }
}
