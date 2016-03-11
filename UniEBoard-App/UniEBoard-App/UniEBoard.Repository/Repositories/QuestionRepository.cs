// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestionRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for Question Repository CRUD operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Repository;
using UniEBoard.Model.Interfaces.Adapter;
using System.Data.Entity.Infrastructure;

namespace UniEBoard.Repository.Repositories
{
    /// <summary>
    /// The Question Repository Class
    /// </summary>
    public class QuestionRepository : BaseRepository<UniEBoardDbContext, Repository.Question, Model.Entities.Question>, IQuestionRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        public QuestionRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Finds the questions by quizID
        /// </summary>
        /// <param name="quizId">The quiz id.</param>
        /// <returns>List<Model.Entities.Question></returns>
        public List<Model.Entities.Question> GetQuestionsByQuizId(int quizId)
        {
            List<Model.Entities.Question> questionsModelList = new List<Model.Entities.Question>();
            try
            {
                // Fetch Active Tasks
                IQueryable<Question> questionQuery = from cr in this.Context.Set<Question>().Where(cr => cr.Quiz_Id == quizId)
                                                 select cr;
                
                questionQuery = IncludePropertyAssociations(questionQuery, new List<string> { "QuestionChoices", "Quiz" });
                
                List<Question> questionEntityList = questionQuery.ToList();
                // Return Tasks
                questionsModelList = ObjectMapper.Map<Question, Model.Entities.Question>(questionEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return questionsModelList;
        }

        /// <summary>
        /// Finds the quiz questions by teacher and quiz.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <param name="quizId">The quiz id.</param>
        /// <param name="view">The view.</param>
        /// <returns></returns>
        public List<Model.Entities.Question> FindQuizQuestionsByTeacherAndQuiz(int teacherId, int quizId, int view)
        {
            List<Model.Entities.Question> questionList = new List<Model.Entities.Question>();
            try
            {
                // Select Quizzes
                IQueryable<Question> questionQuery = from q in this.Context.Set<Quiz>().Where(q => q.Id.Equals(quizId))
                                              join qu in this.Context.Set<Question>() on q.Id equals qu.Quiz_Id
                                              select qu;

                // Ensure No Duplicates
                questionQuery = questionQuery.Distinct();
                questionQuery = IncludePropertyAssociations(questionQuery, new List<string> { "QuestionChoices"});

                // handle no of results
                if (view != 0)
                {
                    questionQuery = questionQuery.Take(view);
                }

                // Get counts

                // Return Questions
                questionList = ObjectMapper.Map<Question, Model.Entities.Question>(questionQuery.ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return questionList;
        }


        /// <summary>
        /// Gets the question for the Id and its Question Choices.
        /// </summary>
        /// <param name="entityId">The question id.</param>
        /// <returns></returns>
        public override Model.Entities.Question FindBy(int id, List<string> includeAssociations)
        {
            Model.Entities.Question question = new Model.Entities.Question();
            try
            {               
                IQueryable<Question> questionQuery = Context.Set<Question>().Where(p => p.Id == id);
                questionQuery = IncludePropertyAssociations(questionQuery, includeAssociations);

                question = ObjectMapper.Map<Question, Model.Entities.Question>(questionQuery.ToList()[0]);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return question;
        }


        /// <summary>
        /// Updates the specified question.
        /// </summary>
        /// <param name="model">The question.</param>
        public override void Update(Model.Entities.Question model)
        {            
            // Getting existing Question
            Repository.Question existingEntity = Context.Set<Repository.Question>().Find(ObjectMapper.GetEntityIdentifier<Model.Entities.Question>(model));

            // deleting existing questions choices
            List<QuestionChoice> existingQuestionChoices = (from qCh in Context.Set<QuestionChoice>()
                                                                .Where(cr => cr.Question_Id == model.Id)
                                                                select qCh).ToList<QuestionChoice>();
            foreach (Repository.QuestionChoice questionChoice in existingQuestionChoices)
            {
                Context.Set<Repository.QuestionChoice>().Remove(questionChoice);
            }

            // Detach existing Entity
            System.Data.Entity.EntityState existingEntityState = Context.Entry<Repository.Question>(existingEntity).State;
            if (existingEntityState != System.Data.Entity.EntityState.Detached)
            {
                Context.Entry<Repository.Question>(existingEntity).State = System.Data.Entity.EntityState.Detached;
            }

            // Getting the updated Question
            Repository.Question updatedEntity = ObjectMapper.Map<Model.Entities.Question, Repository.Question>(model);                

            //adding the question choices of the updated question
            foreach (Repository.QuestionChoice questionChoice in updatedEntity.QuestionChoices)
            {
                Context.Set<Repository.QuestionChoice>().Add(questionChoice);
            }


            //changing to modified state the updated entity
            System.Data.Entity.EntityState updatedEntityState = Context.Entry<Repository.Question>(updatedEntity).State;
            if (updatedEntityState == System.Data.Entity.EntityState.Detached)
            {
                Context.Entry<Repository.Question>(updatedEntity).State = System.Data.Entity.EntityState.Modified;
            }
  
           
            Context.SaveChanges();
        }

        /// <summary>
        /// Removes the question
        /// </summary>
        /// <param name="questionId">question id</param>
        /// <returns>true if delete otherwise returns false</returns>
        public void RemoveQuestion(int questionId)
        {
            // removes the quesiton
            RemoveRefresh(questionId);
        }

        #endregion



       
    }
}
