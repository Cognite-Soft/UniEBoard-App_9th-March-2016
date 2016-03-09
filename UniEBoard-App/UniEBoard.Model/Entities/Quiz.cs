// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Quiz.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Quiz class definition
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
    /// Quiz class definition
    /// </summary>
    public class Quiz : BaseEntity
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Task"/> class.
        /// </summary>
        public Quiz()
            : base()
        {
            
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        /// <value>The Title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the PublishFrom.
        /// </summary>
        /// <value>The PublishFrom.</value>
        public DateTime PublishFrom { get; set; }

        /// <summary>
        /// Gets or sets the PublishTo.
        /// </summary>
        /// <value>The PublishTo.</value>
        public DateTime PublishTo { get; set; }
        
        /// <summary>
        /// Gets or sets the MaxAttemptsAllowed.
        /// </summary>
        /// <value>The MaxAttemptsAllowed.</value>
        public Nullable<int> MaxAttemptsAllowed { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>The Description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the DisplayEndResults.
        /// </summary>
        /// <value>The DisplayEndResults.</value>
        public QuizDisplayEndResultsOptions DisplayEndResults { get; set; }

        /// <summary>
        /// Gets or sets the CorrectUserChoices.
        /// </summary>
        /// <value>The CorrectUserChoices.</value>
        public bool CorrectUserChoices { get; set; }

        /// <summary>
        /// Gets or sets the Instructions.
        /// </summary>
        /// <value>The Instructions.</value>
        public string Instructions { get; set; }


        /// <summary>
        /// Gets or sets the Deadline.
        /// </summary>
        /// <value>The Deadline.</value>
        public Nullable<System.DateTime> Deadline { get; set; }

        public string PassMessage { get; set; }

        /// <summary>
        /// Gets or sets the module quizs.
        /// </summary>
        /// <value>The module quizs.</value>
        public ICollection<ModuleQuiz> ModuleQuizs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int TotalPoints
        { 
            get 
            {
                int total = 0;
                if (Questions != null)
                {
                    total = Questions.Sum(p => p.TotalPoints);
                }

                return total;
            } 
        }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Question> Questions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<QuizEntry> QuizEntries { get; set; }

        #endregion
    }
}
