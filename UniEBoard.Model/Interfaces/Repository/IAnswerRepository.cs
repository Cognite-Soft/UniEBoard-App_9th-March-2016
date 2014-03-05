// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAnswerRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface methods for Answer Repository CRUD operations.
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
    /// The Answer Repository Interface
    /// </summary>
    public interface IAnswerRepository : IBaseRepository<Answer>
    {

        List<Model.Entities.Answer> GetAnswerByQuizEntryId(int QuizEntryId);

    }
}
