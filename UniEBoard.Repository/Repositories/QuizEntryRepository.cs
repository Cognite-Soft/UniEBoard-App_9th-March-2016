// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuizEntryRepository.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains methods for QuizEntry Repository CRUD operations.
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
    /// The QuizEntry Repository Class
    /// </summary>
    public class QuizEntryRepository : BaseRepository<UniEBoardDbContext, Repository.QuizEntry, Model.Entities.QuizEntry>, IQuizEntryRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskRepository"/> class.
        /// </summary>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        public QuizEntryRepository(IObjectMapperAdapter objectMapper, IExceptionManagerAdapter exceptionManager)
            : base(objectMapper, exceptionManager)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get the quiz entry by quiz Id and student Id
        /// </summary>
        /// <param name="quizId"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public Model.Entities.QuizEntry GetQuizEntryByStudentAndQuiz(int quizId, int studentId)
        {
            Model.Entities.QuizEntry quizEntryModel = new Model.Entities.QuizEntry();
            try
            {
                // Fetch Active Tasks
                IQueryable<QuizEntry> quizzes = from cr in this.Context.Set<QuizEntry>().Where(cr => cr.Quiz_Id == quizId && cr.Student_Id == studentId)
                                                                                    select cr;
                QuizEntry quizEntityList = quizzes.ToList().FirstOrDefault();


                // Return Tasks
                quizEntryModel = ObjectMapper.Map<QuizEntry, Model.Entities.QuizEntry>(quizEntityList);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return quizEntryModel;
        }

        /// <summary>
        /// num of Attempts for a quizId
        /// </summary>
        /// <param name="quizId">The quizId</param>
        /// <param name="studentId">The student Id. </param>
        /// <returns>num of Attempts</returns>
        public int NumAttemptsSoFar(int quizId, int studentId)
        {
            int numattempst = 0;
            try
            {

                IQueryable<QuizEntry> quizzes = from cr in this.Context.Set<QuizEntry>().Where(cr => cr.Quiz_Id == quizId && cr.Student_Id == studentId)
                                                select cr;
                numattempst = quizzes.Count();


            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return numattempst;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StudentId"></param>
        /// <returns></returns>
        public List<Model.Entities.QuizEntry> GetQuizEntriesForStudent(int studentId, int courseId) 
        {
            List<Model.Entities.QuizEntry> quizEntryList = new List<Model.Entities.QuizEntry>();
            try
            {
                // Fetch Active Tasks

                IQueryable<QuizEntry> quizEntries = from qe in this.Context.Set<QuizEntry>()
                                                        .Include("Quiz")
                                                        .Include("Quiz.Questions")
                                                        .Include("Quiz.Questions.QuestionChoices")
                                                join q in Context.Set<Quiz>() on qe.Quiz_Id equals q.Id
                                                join mq in Context.Set<ModuleQuiz>() on q.Id equals mq.QuizId
                                                join m in Context.Set<Module>() on mq.ModuleId equals m.Id
                                                join c in Context.Set<Course>() on m.Course_Id equals c.Id
                                                where (qe.Student_Id == studentId && c.Id == courseId)
                                                select qe;
                

                // Return Tasks
                quizEntryList = ObjectMapper.Map<QuizEntry, Model.Entities.QuizEntry>(quizEntries.ToList());                
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return quizEntryList;
        }

        #endregion
    }
}
