// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAnswerQuestionChoiceRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for AnswerQuestionChoice Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;

namespace UniEBoard.Model.Interfaces.Repository
{
    /// <summary>
    /// The AnswerQuestionChoice Repository Interface
    /// </summary>
    public interface IAnswerQuestionChoiceRepository : IBaseRepository<AnswerQuestionChoice>
    {
        /// <summary>
        /// Get all Model.Entities.AnswerQuestionChoice
        /// </summary>
        /// <returns><Model.Entities.AnswerQuestionChoice></returns>
        List<Model.Entities.AnswerQuestionChoice> GetAll();

    }
}
