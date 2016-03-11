// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAssignmentTaskSubmissionAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Interface Methods for all Assignment, Task and submission related operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Service.Models;

namespace UniEBoard.Service.Interfaces.ApplicationService
{
    /// <summary>
    /// IAssignmentTaskSubmissionAppService Interface - Contains Methods for all Assignment, Task and Submission related operations
    /// </summary>
    public interface IAssignmentTaskSubmissionAppService : IBaseAppService
    {

        /// <summary>
        /// Gets or sets the assignment manager.
        /// </summary>
        /// <value>The assignment manager.</value>
        IAssignmentDomainService AssignmentManager { get; set; }

        /// <summary>
        /// Gets or sets the task manager.
        /// </summary>
        /// <value>The task manager.</value>
        ITaskDomainService TaskManager { get; set; }

        /// <summary>
        /// Gets all student task and assignment deadlines.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <returns></returns>
        List<TaskAssignmentViewModel> GetAllStudentUpcomingTaskAndAssignmentDeadlines(int studentId);

        /// <summary>
        /// Gets all student assignment submissions.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="displayFilter">The display filter.</param>
        /// <returns></returns>
        List<AssignmentSubmissionViewModel> GetAllStudentAssignmentSubmissions(int studentId, StudentAssignmentFilterType displayFilter = StudentAssignmentFilterType.Active, int courseId = 0);
        
        /// <summary>
        /// Saves the student submission.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="assignmentSubmissionViewModel">The assignment submission view model.</param>
        /// <param name="setStatusToSubmitted">if set to <c>true</c> [set status to submitted].</param>
        AssignmentSubmissionViewModel SaveStudentSubmission(int studentId, AssignmentSubmissionViewModel assignmentSubmissionViewModel, bool setStatusToSubmitted = false);

        /// <summary>
        /// Uploads the student submission document.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="assignmentSubmissionViewModel">The assignment submission view model.</param>
        void UploadStudentSubmissionDocument(int studentId, AssignmentSubmissionViewModel assignmentSubmissionViewModel);

        /// <summary>
        /// Gets the student assignment submission.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="assignmentId">The assignment id.</param>
        /// <returns></returns>
        AssignmentSubmissionViewModel GetStudentAssignmentSubmission(int studentId, int assignmentId);

        /// <summary>
        /// Gets filtered tasks
        /// </summary>
        /// <param name="studentId">The user id.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        List<TaskViewModel> GetTasks(int userId, TaskFilterType displayFilter = TaskFilterType.All);

        /// <summary>
        /// Gets the task filter view model
        /// </summary>
        /// <param name="action">The target action</param>
        /// <param name="controller">The target controller.</param>
        /// <param name="updateTargetId">The update target id.</param>
        /// <param name="displayFilter">The active display filter.</param>
        /// <returns></returns>
        DisplayFilterViewModel GetTaskDisplayFilter(string action, string controller, string updateTargetId, TaskFilterType displayFilter = TaskFilterType.Active, string view = "");

        /// <summary>
        /// Gets the assignment display filter.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="updateTargetId">The update target id.</param>
        /// <param name="displayFilter">The display filter.</param>
        /// <returns></returns>
        DisplayFilterViewModel GetAssignmentDisplayFilter(string action, string controller, string updateTargetId, StudentAssignmentFilterType displayFilter = StudentAssignmentFilterType.Active);

        /// <summary>
        /// Completes the task.
        /// </summary>
        /// <param name="taskId">The task id.</param>
        void CompleteTask(int taskId);

        /// <summary>
        /// Adds the task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="userId">The user id.</param>
        TaskViewModel AddTask(TaskViewModel task, int userId);

        /// <summary>
        /// Get all assignment
        /// </summary>
        /// <returns>list of all assignment</returns>
        IEnumerable<AssignmentViewModel> GetAllAssignments();


        /// <summary>
        /// Get single assignment
        /// </summary>
        /// <returns>list of single assignment</returns>
        AssignmentViewModel GetAssignment(int assgId);

        /// <summary>
        /// Updates the assignment.
        /// </summary>
        /// <param name="assignment">The assignment.</param>
        void UpdateAssignment(AssignmentViewModel assignmentViewModel);

        /// <summary>
        /// Creates the assignment.
        /// </summary>
        /// <param name="assignmentViewModel">The assignment view model.</param>
        void CreateAssignment(AssignmentViewModel assignmentViewModel, int? userId);
    }
}
