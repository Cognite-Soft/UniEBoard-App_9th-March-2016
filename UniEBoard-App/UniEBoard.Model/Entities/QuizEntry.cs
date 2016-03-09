// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuizEntry.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  QuizEntry class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// QuizEntry class definition
    /// </summary>
    public class QuizEntry : BaseEntity
    {

        #region Properties

        /// <summary>
        /// Gets or sets the Student_Id.
        /// </summary>
        /// <value>The Student_Id.</value>
        public int Student_Id { get; set; }

        /// <summary>
        /// Gets or sets the Quiz_Id.
        /// </summary>
        /// <value>The Quiz_Id.</value>
        public int Quiz_Id { get; set; }


        /// <summary>
        /// Gets or sets the QuizResult.
        /// </summary>
        /// <value>The QuizResult.</value>
        public Nullable<int> QuizResult { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Quiz Quiz { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Student Student { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Answer> Answers { get; set; }
        
        #endregion
    }
}
