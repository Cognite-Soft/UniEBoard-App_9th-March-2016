// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StudentMessageViewModelFactory.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  StudentMessageViewModelFactory class definition
//  Contains methods to build StudentMessage View Models
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Service.Models;

namespace UniEBoard.Service.Factories
{
    /// <summary>
    /// StudentMessageViewModelFactory - Contains methods to build StudentMessage View Models
    /// </summary>
    public static class StudentMessageViewModelFactory
    {
        #region Methods

        /// <summary>
        /// Gets the student viewed message.
        /// </summary>
        /// <param name="alertId">The messageId.</param>
        /// <param name="studentId">The studentId.</param>
        /// <returns></returns>
        public static StudentViewedMessageViewModel CreateStudentViewedMessageModel(int alertId, int studentId)
        {
            return new StudentViewedMessageViewModel()
            {
                MessageId = alertId,
                UserId = studentId
            };
        }

        public static List<Message> CreateTeacherAssignmentMessages(Module module, Assignment assignment, int? userId)
        {
            List<Message> messages = new List<Message>();
            List<Course> courses = new List<Course>();
            foreach (var cm in module.CourseModules)
            {
                courses.Add(cm.Course);
            }

            foreach (var course in courses)
            {
                foreach (var registration in course.CourseRegistrations)
                {
                    Message message = new Message()
                    {
                        Body = assignment.Instructions,
                        Title = assignment.Title,
                        FromUserId = userId.HasValue ? userId.Value : 0,
                        RecipientUserId = registration.Student_Id,
                        MessageType = MessageType.Assignment,
                        Comments = MessageType.Assignment.ToString(),
                        DateCreated = DateTime.UtcNow,
                        EntityId = assignment.Id
                    };

                    messages.Add(message);
                }
            }
            return messages;
        }

        public static List<Message> CreateStudentAssignmentSubmissionMessages(Module module, AssignmentViewModel assignment, int? userId)
        {
            List<Message> messages = new List<Message>();
            List<Course> courses = new List<Course>();
            foreach (var cm in module.CourseModules)
            {
                courses.Add(cm.Course);
            }

            foreach (var course in courses)
            {
                foreach (var staffCourse in course.StaffCourses)
                {
                    Message message = new Message()
                    {
                        Body = assignment.Instructions,
                        Title = assignment.Title,
                        FromUserId = userId.HasValue ? userId.Value : 0,
                        RecipientUserId = staffCourse.Staff_Id,
                        MessageType = MessageType.Assignment,
                        Comments = MessageType.Assignment.ToString(),
                        DateCreated = DateTime.UtcNow,
                        EntityId = assignment.Id
                    };

                    messages.Add(message);
                }
            }
            return messages;
        }

        public static List<Message> CreateUserMessage(List<UserViewModel> users, string messageBody, UserViewModel CurrentUser)
        {
            List<Message> messages = new List<Message>();
            foreach (var user in users)
            {
                Message message = new Message()
                {
                    Body = messageBody,
                    Title = string.Format("{0}: {1}", CurrentUser.FullName, messageBody),
                    FromUserId = CurrentUser != null ? CurrentUser.Id : 0,
                    RecipientUserId = user.Id,
                    MessageType = MessageType.Message,
                    Comments = MessageType.Message.ToString(),
                    DateCreated = DateTime.UtcNow,
                    EntityId = null
                };
                messages.Add(message);
            }
            return messages;
        }

        #endregion
    }
}
