// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseViewModelFactory.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  CourseViewModelFactory class definition
//  Contains methods to build Course View Models
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Service.Models;
using UniEBoard.Service.Models.Quizzes;

namespace UniEBoard.Service.Factories
{
    /// <summary>
    /// CourseViewModelFactory - Contains methods to build Course View Models
    /// </summary>
    public static class QuizViewModelFactory
    {
        #region Methods

        /// <summary>
        /// Creates the quiz view model.
        /// </summary>
        /// <param name="quiz">The quiz.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static QuizzesViewModel CreateFromDomainModel(Quiz quiz,  IObjectMapperAdapter objectMapper)
        {
            QuizzesViewModel viewmodel = objectMapper.Map<Model.Entities.Quiz, QuizzesViewModel>(quiz);
            if (viewmodel != null)
            {
                Module quizModule = null;
                try 
	            {	        
		            quizModule = quiz.ModuleQuizs.FirstOrDefault().Module;
	            }
	            catch (Exception)
	            {
	            }
                if(quizModule != null)
                {
                    viewmodel.ModuleId = quizModule.Id;
                    viewmodel.ModuleTitle = quizModule.Title;
                    viewmodel.CourseId = quizModule.Course_Id;
                }
            }
            return viewmodel;
        }

        /// <summary>
        /// Creates from view domain model.
        /// </summary>
        /// <param name="quizzes">The quizzes.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static List<QuizzesViewModel> CreateFromDomainModel(List<Quiz> quizzes, IObjectMapperAdapter objectMapper)
        {
            return quizzes.Select(q => CreateFromDomainModel(q, objectMapper)).ToList<QuizzesViewModel>();
        }
       


        
        #endregion
    }
}
