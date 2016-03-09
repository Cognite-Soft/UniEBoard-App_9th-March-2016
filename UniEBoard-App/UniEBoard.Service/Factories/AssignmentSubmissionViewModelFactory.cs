// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssignmentSubmissionViewModelFactory.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  AssignmentSubmissionViewModelFactory class definition
//  Contains methods to build Student Assignment Submission View Models
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Service.Models;

namespace UniEBoard.Service.Factories
{
    /// <summary>
    /// AssignmentSubmissionViewModelFactory - Contains methods to build Student Assignment Submission View Models
    /// </summary>
    public static class AssignmentSubmissionViewModelFactory
    {
        #region Methods

        /// <summary>
        /// Creates the student assignment with submission view model.
        /// </summary>
        /// <param name="assignments">The assignments.</param>
        /// <param name="studentId">The student id.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static List<AssignmentSubmissionViewModel> CreateStudentAssignmentSubmissionViewModels(List<Assignment> assignments, int studentId, IObjectMapperAdapter objectMapper)
        {
            List<AssignmentSubmissionViewModel> assignmentSubmissionModels = new List<AssignmentSubmissionViewModel>();
            foreach (Assignment assignmentItem in assignments)
            {
                AssignmentSubmissionViewModel assignmentSubmissionViewModel = CreateStudentAssignmentSubmissionViewModel(assignmentItem, studentId, objectMapper);
                if (assignmentSubmissionViewModel != null)
                {
                    assignmentSubmissionModels.Add(assignmentSubmissionViewModel);
                }
            }
            return assignmentSubmissionModels;
        }


        /// <summary>
        /// Creates the student assignment submission view model.
        /// </summary>
        /// <param name="assignment">The assignment.</param>
        /// <param name="studentId">The student id.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <returns></returns>
        public static AssignmentSubmissionViewModel CreateStudentAssignmentSubmissionViewModel(Assignment assignment, int studentId, IObjectMapperAdapter objectMapper)
        {
            AssignmentSubmissionViewModel model = null;
            if (assignment != null)
            {
                foreach (Submission submissionItem in assignment.Submissions)
                {
                    if (submissionItem.StudentId == studentId)
                    {
                        model = objectMapper.Map<Model.Entities.Submission, AssignmentSubmissionViewModel>(submissionItem);
                        break;
                    }
                }

                // If no submission exists, create a new one
                if (model == null)
                {
                    model = new AssignmentSubmissionViewModel();
                }

                //Set Assignment properties on Model
                model.StudentId = studentId;
                model.AssignmentId = assignment.Id;
                model.Instructions = assignment.Instructions;
                model.DaysDue = assignment.DaysDue;
                model.DaysLeft = assignment.DaysLeft;
                model.Priority = (int)assignment.Priority;
                if (model.Status == 0)
                {
                    model.Status = (int)SubmissionStatusType.New;
                }
                model.PointsPossible = assignment.PointsPossible;
                model.Title = assignment.Title;
                model.AssignmentUploads = objectMapper.Map<Model.Entities.BaseFile, BaseFileViewModel>(assignment.FileUploads.ToList());
            }

            return model;
        }

        #endregion
    }
}
