// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BootStrapper.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Object mapping resolutions which need to be initialised on application start
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Interfaces.Adapter;

namespace UniEBoard.Repository.Mapping
{
    /// <summary>
    /// Bootstrapper class for Object maping
    /// </summary>
    public static class BootStrapper
    {
        #region Methods

        /// <summary>
        /// Initializes the specified object mapper.
        /// </summary>
        /// <param name="ObjectMapper">The object mapper.</param>
        public static void Initialize(IObjectMapperAdapter ObjectMapper)
        {
            // Repository Entity to Domain Entity
            ObjectMapper.CreateMap<UniEBoard.Repository.User, UniEBoard.Model.Entities.User>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Role, UniEBoard.Model.Entities.Role>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Staff, UniEBoard.Model.Entities.Staff>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Student, UniEBoard.Model.Entities.Student>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Group, UniEBoard.Model.Entities.Group>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Membership, UniEBoard.Model.Entities.Membership>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Message, UniEBoard.Model.Entities.Message>();
            ObjectMapper.CreateMap<UniEBoard.Repository.ViewedMessage, UniEBoard.Model.Entities.ViewedMessage>();
            ObjectMapper.CreateMap<UniEBoard.Repository.UserGroup, UniEBoard.Model.Entities.UserGroup>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Assignment, UniEBoard.Model.Entities.Assignment>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Submission, UniEBoard.Model.Entities.Submission>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Task, UniEBoard.Model.Entities.Task>();
            ObjectMapper.CreateMap<UniEBoard.Repository.CourseModule, UniEBoard.Model.Entities.CourseModule>();
            ObjectMapper.CreateMap<UniEBoard.Repository.CourseRegistration, UniEBoard.Model.Entities.CourseRegistration>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Module, UniEBoard.Model.Entities.Module>();
            ObjectMapper.CreateMap<UniEBoard.Repository.StaffCourse, UniEBoard.Model.Entities.StaffCourse>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Unit, UniEBoard.Model.Entities.Unit>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Course, UniEBoard.Model.Entities.Course>();
            ObjectMapper.CreateMap<UniEBoard.Repository.BaseFile, UniEBoard.Model.Entities.BaseFile>();
            ObjectMapper.CreateMap<UniEBoard.Repository.File, UniEBoard.Model.Entities.File>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Video, UniEBoard.Model.Entities.Video>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Image, UniEBoard.Model.Entities.Image>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Document, UniEBoard.Model.Entities.Document>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Asset, UniEBoard.Model.Entities.Asset>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Tag, UniEBoard.Model.Entities.Tag>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Quiz, UniEBoard.Model.Entities.Quiz>();
            ObjectMapper.CreateMap<UniEBoard.Repository.QuizEntry, UniEBoard.Model.Entities.QuizEntry>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Question, UniEBoard.Model.Entities.Question>();
            ObjectMapper.CreateMap<UniEBoard.Repository.QuestionChoice, UniEBoard.Model.Entities.QuestionChoice>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Answer, UniEBoard.Model.Entities.Answer>();
            ObjectMapper.CreateMap<UniEBoard.Repository.AnswerQuestionChoice, UniEBoard.Model.Entities.AnswerQuestionChoice>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Schedule, UniEBoard.Model.Entities.Schedule>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Topic, UniEBoard.Model.Entities.Topic>();
            ObjectMapper.CreateMap<UniEBoard.Repository.TopicPost, UniEBoard.Model.Entities.TopicPost>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Discussion, UniEBoard.Model.Entities.Discussion>();
            ObjectMapper.CreateMap<UniEBoard.Repository.BaseQuestionTopic, UniEBoard.Model.Entities.BaseQuestionTopic>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Company, UniEBoard.Model.Entities.Company>();
            ObjectMapper.CreateMap<UniEBoard.Repository.Department, UniEBoard.Model.Entities.Department>();
            ObjectMapper.CreateMap<UniEBoard.Repository.ModuleQuiz, UniEBoard.Model.Entities.ModuleQuiz>();

            // Domain Entity to Repository Entity
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Membership, UniEBoard.Repository.Membership>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Message, UniEBoard.Repository.Message>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.User, UniEBoard.Repository.User>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Role, UniEBoard.Repository.Role>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Student, UniEBoard.Repository.Student>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Staff, UniEBoard.Repository.Staff>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.ViewedMessage, UniEBoard.Repository.ViewedMessage>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.UserGroup, UniEBoard.Repository.UserGroup>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Submission, UniEBoard.Repository.Submission>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Task, UniEBoard.Repository.Task>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Assignment, UniEBoard.Repository.Assignment>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.CourseModule, UniEBoard.Repository.CourseModule>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.CourseRegistration, UniEBoard.Repository.CourseRegistration>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Module, UniEBoard.Repository.Module>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.StaffCourse, UniEBoard.Repository.StaffCourse>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Unit, UniEBoard.Repository.Unit>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Course, UniEBoard.Repository.Course>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.BaseFile, UniEBoard.Repository.BaseFile>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.File, UniEBoard.Repository.File>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Video, UniEBoard.Repository.Video>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Document, UniEBoard.Repository.Document>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Image, UniEBoard.Repository.Image>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Asset, UniEBoard.Repository.Asset>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Quiz, UniEBoard.Repository.Quiz>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.QuizEntry, UniEBoard.Repository.QuizEntry>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Question, UniEBoard.Repository.Question>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.QuestionChoice, UniEBoard.Repository.QuestionChoice>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Answer, UniEBoard.Repository.Answer>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.AnswerQuestionChoice, UniEBoard.Repository.AnswerQuestionChoice>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Schedule, UniEBoard.Repository.Schedule>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Discussion, UniEBoard.Repository.Discussion>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Topic, UniEBoard.Repository.Topic>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.TopicPost, UniEBoard.Repository.TopicPost>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.BaseQuestionTopic, UniEBoard.Repository.BaseQuestionTopic>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Company, UniEBoard.Repository.Company>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Tag, UniEBoard.Repository.Tag>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.ModuleQuiz, UniEBoard.Repository.ModuleQuiz>();
        }

        #endregion
    }
}
