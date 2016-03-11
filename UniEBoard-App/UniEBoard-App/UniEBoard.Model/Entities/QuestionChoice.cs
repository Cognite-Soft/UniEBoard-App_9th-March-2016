// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestionChoices.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  QuestionChoices class definition
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
    /// Question class definition
    /// </summary>
    public class QuestionChoice  : BaseEntity
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionChoice"/> class.
        /// </summary>
        public QuestionChoice()
            : base()
        {
  
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>The Name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the PointsValue.
        /// </summary>
        /// <value>The PointsValue.</value>
        public short PointsValue { get; set; }

        /// <summary>
        /// Gets or sets the DisplayOrder.
        /// </summary>
        /// <value>The DisplayOrder.</value>
        public short DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the CorrectAnswer.
        /// </summary>
        /// <value>The CorrectAnswer.</value>
        public bool CorrectAnswer { get; set; }

        /// <summary>
        /// Gets or sets the Question_Id.
        /// </summary>
        /// <value>The Question_Id.</value>
        public int Question_Id { get; set; }
    

        #endregion
    }
}
