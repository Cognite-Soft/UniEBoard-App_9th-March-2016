// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleQuiz.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  ModuleQuiz class definition
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UniEBoard.Model.Entities
{
    /// <summary>
    /// ModuleQuiz class definition
    /// </summary>
    public class ModuleQuiz : BaseEntity
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleQuiz"/> class.
        /// </summary>
        public ModuleQuiz()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleQuiz"/> class.
        /// </summary>
        /// <param name="quizId">The quiz id.</param>
        /// <param name="moduleId">The module id.</param>
        public ModuleQuiz(int quizId, int moduleId)
        {
            QuizId = quizId;
            ModuleId = moduleId;
        }

        #endregion
        #region Properties

        /// <summary>
        /// Gets or sets the quiz id.
        /// </summary>
        /// <value>The quiz id.</value>
        public int QuizId { get; set; }

        /// <summary>
        /// Gets or sets the module id.
        /// </summary>
        /// <value>The module id.</value>
        public int ModuleId { get; set; }

        /// <summary>
        /// Gets or sets the quiz.
        /// </summary>
        /// <value>The course.</value>
        public Quiz Quiz { get; set; }

        /// <summary>
        /// Gets or sets the module.
        /// </summary>
        /// <value>The module.</value>
        public Module Module { get; set; }

        #endregion
    }
}
