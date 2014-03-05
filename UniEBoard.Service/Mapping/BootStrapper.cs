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

namespace UniEBoard.Service.Mapping
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
            // Convert from Domain Model to View Model
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Student, UniEBoard.Service.Models.StudentViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Staff, UniEBoard.Service.Models.StaffViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.User, UniEBoard.Service.Models.UserViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Role, UniEBoard.Service.Models.RoleViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Group, UniEBoard.Service.Models.MessageViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Message, UniEBoard.Service.Models.MessageViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Assignment, UniEBoard.Service.Models.AssignmentViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.BaseTask, UniEBoard.Service.Models.TaskAssignmentViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Module, UniEBoard.Service.Models.ModuleViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.ModuleGrade, UniEBoard.Service.Models.ModuleGradeViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Course, UniEBoard.Service.Models.CourseViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Task, UniEBoard.Service.Models.TaskViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Assignment, UniEBoard.Service.Models.AssignmentViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Submission, UniEBoard.Service.Models.SubmissionViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.BaseFile, UniEBoard.Service.Models.BaseFileViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.File, UniEBoard.Service.Models.FileViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Submission, UniEBoard.Service.Models.AssignmentSubmissionViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Unit, UniEBoard.Service.Models.UnitViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Quiz, UniEBoard.Service.Models.Quizzes.QuizzesViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.QuizEntry, UniEBoard.Service.Models.Quizzes.QuizEntryViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Question, UniEBoard.Service.Models.Quizzes.QuestionViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.QuestionChoice, UniEBoard.Service.Models.Quizzes.QuestionChoicesViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Answer, UniEBoard.Service.Models.Quizzes.AnswerViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.AnswerQuestionChoice, UniEBoard.Service.Models.Quizzes.AnswerQuestionChoiceViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Schedule, UniEBoard.Service.Models.ScheduleViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.BaseQuestionTopic, UniEBoard.Service.Models.BaseQuestionTopicViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.TopicPost, UniEBoard.Service.Models.TopicPostViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Topic, UniEBoard.Service.Models.TopicViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Discussion, UniEBoard.Service.Models.DiscussionViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.BaseQuestionTopic, UniEBoard.Service.Models.BaseQuestionTopicViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Asset, UniEBoard.Service.Models.AssetViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Video, UniEBoard.Service.Models.VideoViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Document, UniEBoard.Service.Models.DocumentViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Image, UniEBoard.Service.Models.ImageViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Tag, UniEBoard.Service.Models.TagViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.Department, UniEBoard.Service.Models.DepartmentViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.ModuleQuiz, UniEBoard.Service.Models.ModuleQuizViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.CourseRegistration, UniEBoard.Service.Models.CourseRegistrationViewModel>();
            ObjectMapper.CreateMap<UniEBoard.Model.Entities.CourseModule, UniEBoard.Service.Models.CourseModuleViewModel>();

            // Convert from View Model to Domain Model
            ObjectMapper.CreateMap<UniEBoard.Service.Models.StudentViewModel, UniEBoard.Model.Entities.Student>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.StaffViewModel, UniEBoard.Model.Entities.Staff>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.UserViewModel, UniEBoard.Model.Entities.User>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.RoleViewModel, UniEBoard.Model.Entities.Role>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.MessageViewModel, UniEBoard.Model.Entities.Message>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.StudentViewedMessageViewModel, UniEBoard.Model.Entities.ViewedMessage>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.ModuleViewModel, UniEBoard.Model.Entities.Module>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.ModuleGradeViewModel, UniEBoard.Model.Entities.ModuleGrade>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.CourseViewModel, UniEBoard.Model.Entities.Course>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.TaskViewModel, UniEBoard.Model.Entities.Task>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.AssignmentViewModel, UniEBoard.Model.Entities.Assignment>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.SubmissionViewModel, UniEBoard.Model.Entities.Submission>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.BaseFileViewModel, UniEBoard.Model.Entities.BaseFile>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.FileViewModel, UniEBoard.Model.Entities.File>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.UnitViewModel, UniEBoard.Model.Entities.Unit>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.Quizzes.QuizzesViewModel, UniEBoard.Model.Entities.Quiz>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.Quizzes.QuizEntryViewModel, UniEBoard.Model.Entities.QuizEntry>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.Quizzes.QuestionViewModel, UniEBoard.Model.Entities.Question>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.Quizzes.QuestionChoicesViewModel, UniEBoard.Model.Entities.QuestionChoice>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.Quizzes.AnswerViewModel, UniEBoard.Model.Entities.Answer>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.Quizzes.AnswerQuestionChoiceViewModel, UniEBoard.Model.Entities.AnswerQuestionChoice>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.ScheduleViewModel, UniEBoard.Model.Entities.Schedule>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.TopicPostViewModel, UniEBoard.Model.Entities.TopicPost>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.TopicViewModel, UniEBoard.Model.Entities.Topic>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.DiscussionViewModel, UniEBoard.Model.Entities.Discussion>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.BaseQuestionTopicViewModel, UniEBoard.Model.Entities.BaseQuestionTopic>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.BaseQuestionTopicViewModel, UniEBoard.Model.Entities.BaseQuestionTopic>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.AssetViewModel, UniEBoard.Model.Entities.Asset>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.VideoViewModel, UniEBoard.Model.Entities.Video>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.DocumentViewModel, UniEBoard.Model.Entities.Document>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.ImageViewModel, UniEBoard.Model.Entities.Image>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.TagViewModel, UniEBoard.Model.Entities.Tag>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.ModuleQuizViewModel, UniEBoard.Model.Entities.ModuleQuiz>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.CourseRegistrationViewModel, UniEBoard.Model.Entities.CourseRegistration>();
            ObjectMapper.CreateMap<UniEBoard.Service.Models.CourseModuleViewModel, UniEBoard.Model.Entities.CourseModule>();
        }

        #endregion
    }
}
