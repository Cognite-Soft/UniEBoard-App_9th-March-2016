// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Membership.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Message class definition {User or Group Messages}
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// Message class definition
    /// </summary>
    public class Message : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the type of the message.
        /// </summary>
        /// <value>The type of the message.</value>
        public MessageType MessageType { get; set; }

        /// <summary>
        /// Gets or sets from user id.
        /// </summary>
        /// <value>From user id.</value>
        public int FromUserId { get; set; }

        /// <summary>
        /// Gets or sets the recipient user id.
        /// </summary>
        /// <value>The recipient user id.</value>
        public int RecipientUserId { get; set; }

        /// <summary>
        /// Gets or sets the entity Id this message is created for
        /// </summary>
        public Nullable<int> EntityId { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>The comments.</value>
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets from user.
        /// </summary>
        /// <value>From user.</value>
        public User FromUser { get; set; }

        /// <summary>
        /// Gets or sets the recipient user.
        /// </summary>
        /// <value>The recipient user.</value>
        public User RecipientUser { get; set; }

        /// <summary>
        /// Gets or sets the viewed messages.
        /// </summary>
        /// <value>The viewed messages.</value>
        public ICollection<ViewedMessage> ViewedMessages { get; set; }

        #endregion
    }
}
