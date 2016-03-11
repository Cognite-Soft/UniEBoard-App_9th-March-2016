// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAnswerDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Answer Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;

namespace UniEBoard.Model.Interfaces.DomainService
{
    /// <summary>
    /// IAnswerDomainService Interface definition - Contains Methods for Answer Operations
    /// </summary>
    public interface IAnswerDomainService : IBaseDomainService<Answer>
    {
        /// <summary>
        /// Get answer by QuizEntryId
        /// </summary>
        /// <param name="QuizEntryId">the QuizEntryId Id.</param>
        /// <returns>list of Answer</returns>
        List<Answer> GetAnswersByQuizEntryId(int QuizEntryId);

  
    }
}
