// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestionChoicesRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for QuestionChoices Repository CRUD operations.
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
    /// The QuestionChoices Repository Class
    /// </summary>
    public class QuestionChoicesRepository : BaseRepository<UniEBoardDbContext, Repository.QuestionChoice, Model.Entities.QuestionChoice>, IQuestionChoiceRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        public QuestionChoicesRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Finds the active questionchoices by question.
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <returns></returns>
        public List<Model.Entities.QuestionChoice> GetQuestionsChoicesByQuestionId(int questionId)
        {
            List<Model.Entities.QuestionChoice> questionModelList = new List<Model.Entities.QuestionChoice>();
            try
            {
                // Fetch Active Tasks
                IQueryable<QuestionChoice> questionChoices = from cr in this.Context.Set<QuestionChoice>().Where(cr => cr.Question_Id == questionId)
                                                             select cr;
                List<QuestionChoice> questionEntityList = questionChoices.ToList();


                // Return Tasks
                questionModelList = ObjectMapper.Map<QuestionChoice, Model.Entities.QuestionChoice>(questionEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return questionModelList;
        }

        /// <summary>
        /// Get all the questionChoices 
        /// </summary>
        /// <returns> List of question choices </returns>
        public List<Model.Entities.QuestionChoice> GetAll()
        {
            List<Model.Entities.QuestionChoice> questionModelList = new List<Model.Entities.QuestionChoice>();
            try
            {
                // Fetch Active Tasks
                IQueryable<QuestionChoice> questionChoices = from cr in this.Context.Set<QuestionChoice>()
                                                             select cr;
                List<QuestionChoice> questionEntityList = questionChoices.ToList();


                // Return Tasks
                questionModelList = ObjectMapper.Map<QuestionChoice, Model.Entities.QuestionChoice>(questionEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return questionModelList;
        }


        /// <summary>
        /// Get all questionchoices by quizId
        /// </summary>
        /// <param name="quizId">The QuizId</param>
        /// <returns>list of questionChoices </returns>
        public List<Model.Entities.QuestionChoice> GetQuestionChoicesByQuizId(int quizId)
        {
            List<Model.Entities.QuestionChoice> questionModelList = new List<Model.Entities.QuestionChoice>();
            try
            {
                // Fetch Active Tasks
                IQueryable<QuestionChoice> questionChoices = from qc in this.Context.Set<Question>().Where(x => x.Quiz_Id == quizId)
                                                             join q in this.Context.Set<QuestionChoice>() on qc.Quiz_Id equals q.Id
                                                             select q;
                List<QuestionChoice> questionEntityList = questionChoices.ToList();


                // Return Tasks
                questionModelList = ObjectMapper.Map<QuestionChoice, Model.Entities.QuestionChoice>(questionEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return questionModelList;
        }


        /// <summary>
        /// Get the correct question for unique
        /// </summary>
        /// <returns>List of questionChoices </returns>
        public List<Model.Entities.QuestionChoice> GetCorrectQuestionForUnique()
        {
            List<Model.Entities.QuestionChoice> questionModelList = new List<Model.Entities.QuestionChoice>();
            try
            {
                // Fetch Active Tasks
                IQueryable<QuestionChoice> questionChoices = from q in this.Context.Set<QuestionChoice>().Where(x => x.CorrectAnswer == true)
                                                             join qc in this.Context.Set<Question>().Where(p => p.AllowMultipleSelections == false) on q.Question_Id equals qc.Id
                                                             select q;
                List<QuestionChoice> questionEntityList = questionChoices.ToList();


                // Return Tasks
                questionModelList = ObjectMapper.Map<QuestionChoice, Model.Entities.QuestionChoice>(questionEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return questionModelList;
        }

        /// <summary>
        /// Get the correct question for Multiple
        /// </summary>
        /// <returns></returns>
        public List<Model.Entities.QuestionChoice> GetCorrectQuestionForMultiple()
        {
            List<Model.Entities.QuestionChoice> questionModelList = new List<Model.Entities.QuestionChoice>();
            try
            {
                // Fetch Active Tasks
                IQueryable<QuestionChoice> questionChoices = from q in this.Context.Set<QuestionChoice>().Where(x => x.CorrectAnswer == true)
                                                             join qc in this.Context.Set<Question>().Where(p => p.AllowMultipleSelections == true) on q.Question_Id equals qc.Id
                                                             select q;
                List<QuestionChoice> questionEntityList = questionChoices.ToList();


                // Return Tasks
                questionModelList = ObjectMapper.Map<QuestionChoice, Model.Entities.QuestionChoice>(questionEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return questionModelList;
        }

        /// <summary>
        /// Get all the questions with multiple solution
        /// </summary>
        /// <param name="quizId"></param>
        /// <returns></returns>
        public List<int> GetQuestionsMultiples(int quizId)
        {
            List<int> questionMultipleChoice = new List<int>();
            try
            {
                questionMultipleChoice = (from q in GetCorrectQuestionForMultiple()
                                          select q.Question_Id).Distinct().ToList();
            }
            catch (Exception ex)
            {

                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }

            return questionMultipleChoice;
        }

        /// <summary>
        /// Get correct question choices by question Id
        /// </summary>
        /// <param name="questionId">The question Id. </param>
        /// <returns>list of questionChoices</returns>
        public List<Model.Entities.QuestionChoice> GetCorrectQuestionChoices(int questionId)
        {
            List<Model.Entities.QuestionChoice> questionModelList = new List<Model.Entities.QuestionChoice>();
            try
            {

                IQueryable<QuestionChoice> questionChoices = from q in this.Context.Set<QuestionChoice>().Where(x => x.CorrectAnswer == true && x.Question_Id == questionId)
                                                             select q;
                List<QuestionChoice> questionEntityList = questionChoices.ToList();



                questionModelList = ObjectMapper.Map<QuestionChoice, Model.Entities.QuestionChoice>(questionEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return questionModelList;
        }

        #endregion







    }
}
