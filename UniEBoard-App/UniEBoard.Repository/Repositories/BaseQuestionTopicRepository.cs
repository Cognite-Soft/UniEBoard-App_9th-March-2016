// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseQuestionTopicRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for BaseQuestionTopic Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Repository;
using UniEBoard.Model.Interfaces.Adapter;
using System.Data.Entity;
using System.Data.Objects.DataClasses;

namespace UniEBoard.Repository.Repositories
{
    /// <summary>
    /// The BaseQuestionTopic Repository Class
    /// </summary>
    public class BaseQuestionTopicRepository : BaseRepository<UniEBoardDbContext, Repository.BaseQuestionTopic, Model.Entities.BaseQuestionTopic>, IBaseQuestionTopicRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseQuestionTopicRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        public BaseQuestionTopicRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get the QuestionsTopic by StudentId
        /// </summary>
        /// <param name="studentId">The student Id.</param>
        /// <returns></returns>
        public List<Model.Entities.BaseQuestionTopic> FindByStudentId(int studentId)
        {
            List<Model.Entities.BaseQuestionTopic> entities = new List<Model.Entities.BaseQuestionTopic>();
            try
            {
                IQueryable<BaseQuestionTopic> questions = from cr in this.Context.Set<BaseQuestionTopic>().Where(cr => cr.OriginatorId == studentId)
                                                          select cr;

                // Return BaseQuestionTopic
                entities = ObjectMapper.Map<BaseQuestionTopic, Model.Entities.BaseQuestionTopic>(questions.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return entities;
        }

        #endregion





    }
}
