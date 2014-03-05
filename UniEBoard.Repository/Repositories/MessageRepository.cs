// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for Message Repository CRUD operations.
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
using MySql.Data.Entity;

namespace UniEBoard.Repository.Repositories
{
    /// <summary>
    /// The Message Repository Class
    /// </summary>
    public class MessageRepository : BaseRepository<UniEBoardDbContext, Repository.Message, Model.Entities.Message>, IMessageRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        public MessageRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all student messages.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="associations">The associations.</param>
        /// <returns></returns>
        public List<Model.Entities.Message> GetAllStudentMessages(int studentId)
        {
            List<Model.Entities.Message> messageList = new List<Model.Entities.Message>();
            try
            {
                // Fetch Group Messages
                /*IQueryable<Message> groupMessages = from m in this.Context.Set<Message>()
                                                where m.GroupMessages.Any(gm => gm.Group.UserGroups.Any(ug => ug.UserId == studentId))    
                                                select m;
                groupMessages.ToList();*/
                // Fetch Individual Messages
                IQueryable<Message> messages = from m in this.Context.Set<Message>()
                                                   .Where(m => m.RecipientUserId == studentId)
                                               select m;
                // Join Messages
                //IQueryable<Message> allMessages = groupMessages.Union(messages);

                // Get Views
                //IQueryable<ViewedMessage> viewedMessages = allMessages.SelectMany(m => m.ViewedMessages).Where(vm => vm.UserId == studentId);
                //List<Message> entityMessageList = allMessages.ToList();
                //viewedMessages.ToList();

                // Return Messages
                messageList = ObjectMapper.Map<Message, Model.Entities.Message>(messages.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return messageList;
        }

        #endregion


        /// <summary>
        /// Add a list of messages to the data source
        /// </summary>
        /// <param name="messages">List of Messsages</param>
        public void AddMessages(List<Model.Entities.Message> messages)
        {
            List<Repository.Message> entities = ObjectMapper.Map<Model.Entities.Message, Repository.Message>(messages);
            DbSet set = Context.Set<Message>();
            foreach (var entity in entities)
            {
                set.Add(entity);
            }
            Context.SaveChanges();
        }
    }
}
