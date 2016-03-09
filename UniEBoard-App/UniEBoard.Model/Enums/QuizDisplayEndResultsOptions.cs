// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuizDisplayEndResultsOptions.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using Cognite.Utility.Attributes;

namespace UniEBoard.Model.Enums
{
    /// <summary>
    /// 
    /// </summary>
    public enum QuizDisplayEndResultsOptions
    {

        /// <summary>
        /// 
        /// </summary>
        [DisplayAs("Never Show Answers")]
        NeverShowAnswers = 0,
        
        /// <summary>
        /// 
        /// </summary>
        [DisplayAs("Show Answer After the Question")]
        ShowAnswerAfterQuestion = 1,
        
        /// <summary>
        /// 
        /// </summary>
        [DisplayAs("ShowAnswerAfterQuiz")]
        ShowAnswerAfterQuiz = 2,
        
        /// <summary>
        /// 
        /// </summary>
        [DisplayAs("Show Answer After Question And Quiz")]
        ShowAnswerAfterQuestionAndQuiz = 3

    }
}
