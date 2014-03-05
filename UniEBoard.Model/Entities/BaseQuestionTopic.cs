// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseFile.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  BaseFile class definition - contains file metadata information
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using UniEBoard.Model.Enums;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    ///  BaseQuestionTopic class definition
    /// </summary>
    public class BaseQuestionTopic : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseQuestionTopic"/> class.
        /// </summary>
        public BaseQuestionTopic(): base()
        {
            Status = QuestionTopicStatusType.New;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public QuestionTopicStatusType Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is topic.
        /// </summary>
        /// <value><c>true</c> if this instance is topic; otherwise, <c>false</c>.</value>
        public bool IsTopic { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the originator id.
        /// </summary>
        /// <value>The originator id.</value>
        public int OriginatorId { get; set; }

        /// <summary>
        /// Gets or sets the originator.
        /// </summary>
        /// <value>The originator.</value>
        public User Originator { get; set; }
    }
}
