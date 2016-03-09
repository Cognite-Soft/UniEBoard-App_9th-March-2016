// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnswerRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for Answer Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Repository;
using UniEBoard.Model.Interfaces.Adapter;

namespace UniEBoard.Repository.Repositories
{
    /// <summary>
    /// The Answer Repository Class
    /// </summary>
    public class AnswerRepository : BaseRepository<UniEBoardDbContext, Repository.Answer, Model.Entities.Answer>, IAnswerRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        public AnswerRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get Answer by quizEntryId
        /// </summary>
        /// <param name="QuizEntryId">The QuizEntry Id</param>
        /// <returns>List of answers</returns>
        public List<Model.Entities.Answer> GetAnswerByQuizEntryId(int QuizEntryId)
        {
            List<Model.Entities.Answer> answerModelList = new List<Model.Entities.Answer>();
            try
            {
                // Fetch Active Tasks
                IQueryable<Answer> answer = from cr in this.Context.Set<Answer>().Where(cr => cr.QuizEntryId == QuizEntryId)
                                                select cr;
                List<Answer> answerEntityList = answer.ToList();


                // Return Tasks
                answerModelList = ObjectMapper.Map<Answer, Model.Entities.Answer>(answerEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return answerModelList;
        }

       

        #endregion



       
    }
}
