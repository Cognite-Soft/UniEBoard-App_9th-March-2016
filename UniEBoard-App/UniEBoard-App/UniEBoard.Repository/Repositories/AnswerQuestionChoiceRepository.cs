// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnswerQuestionChoice.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for AnswerQuestionChoice Repository CRUD operations.
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
    /// The AnswerQuestionChoice Repository Class
    /// </summary>
    public class AnswerQuestionChoiceRepository : BaseRepository<UniEBoardDbContext, Repository.AnswerQuestionChoice, Model.Entities.AnswerQuestionChoice>, IAnswerQuestionChoiceRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        public AnswerQuestionChoiceRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get all the questions choices 
        /// </summary>
        /// <returns></returns>
        public List<Model.Entities.AnswerQuestionChoice> GetAll()
        {
            List<Model.Entities.AnswerQuestionChoice> answerModelList = new List<Model.Entities.AnswerQuestionChoice>();
            try
            {
                // Fetch Active Tasks
                IQueryable<AnswerQuestionChoice> answer = from cr in this.Context.Set<AnswerQuestionChoice>()
                                            select cr;
                List<AnswerQuestionChoice> answerEntityList = answer.ToList();


                // Return Tasks
                answerModelList = ObjectMapper.Map<AnswerQuestionChoice, Model.Entities.AnswerQuestionChoice>(answerEntityList);
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
