// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Answer.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Answer class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// Answer class definition
    /// </summary>
    public class Answer : BaseEntity
    {

        #region Properties


        /// <summary>
        /// Gets or sets the Question_Id.
        /// </summary>
        /// <value>The Question_Id.</value>
        public int Question_Id { get; set; }

        /// <summary>
        /// Gets or sets the QuizEntryId.
        /// </summary>
        /// <value>The QuizEntryId.</value>
        public int QuizEntryId { get; set; }

        
        #endregion
    }
}
