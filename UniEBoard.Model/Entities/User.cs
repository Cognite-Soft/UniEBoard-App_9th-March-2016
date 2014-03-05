// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  User class definition
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
    /// User class definition
    /// </summary>
    public class User : BaseEntity
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            AccountDisabled = true;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>The date of birth.</value>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the user gender.
        /// </summary>
        /// <value>The user gender.</value>
        public GenderType UserGender { get; set; }

        /// <summary>
        /// Gets or sets the mobile.
        /// </summary>
        /// <value>The mobile.</value>
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [account disabled].
        /// </summary>
        /// <value><c>true</c> if [account disabled]; otherwise, <c>false</c>.</value>
        public bool AccountDisabled { get; set; }

        /// <summary>
        /// Gets or sets the membership_ id.
        /// </summary>
        /// <value>The membership_ id.</value>
        public int Membership_Id { get; set; }

        /// <summary>
        /// Gets or sets the company id.
        /// </summary>
        /// <value>The company id.</value>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>The company.</value>
        public Company Company { get; set; }

        /// <summary>
        /// Gets or sets the tasks.
        /// </summary>
        /// <value>The tasks.</value>
        public ICollection<Task> Tasks { get; set; }

        /// <summary>
        /// Gets or sets the user groups.
        /// </summary>
        /// <value>The user groups.</value>
        public ICollection<UserGroup> UserGroups { get; set; }

        /// <summary>
        /// Gets or sets the created messages.
        /// </summary>
        /// <value>The created messages.</value>
        public ICollection<Message> CreatedMessages { get; set; }

        /// <summary>
        /// Gets or sets the received messages.
        /// </summary>
        /// <value>The received messages.</value>
        public ICollection<Message> ReceivedMessages { get; set; }

        /// <summary>
        /// Gets or sets the user viewed messages.
        /// </summary>
        /// <value>The user viewed messages.</value>
        public ICollection<ViewedMessage> UserViewedMessages { get; set; }

        /// <summary>
        /// Gets or sets the user roles.
        /// </summary>
        /// <value>The user roles.</value>
        public ICollection<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets whether the user is enabled or not.
        /// </summary>
        /// <value>The user viewed messages.</value>
        public bool Enabled { get; set; }

        #endregion
    }
}
