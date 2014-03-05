// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssignmentTaskSubmissionAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for all Assignment, task and Submission related operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Factories;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Service.Interfaces.ApplicationService;
using UniEBoard.Service.Models;
using UniEBoard.Service.Factories;
using UniEBoard.Model.Adapters.Logging;

namespace UniEBoard.Service.ApplicationServices
{
    /// <summary>
    /// Assignment And Submission Application Service Class - Contains Methods for all Assignment, Task and Submission related operations
    /// </summary>
    public class AssignmentTaskSubmissionAppService : BaseAppService, IAssignmentTaskSubmissionAppService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the assignment manager.
        /// </summary>
        /// <value>The assignment manager.</value>
        public IAssignmentDomainService AssignmentManager { get; set; }

        /// <summary>
        /// Gets or sets the submission manager.
        /// </summary>
        /// <value>The submission manager.</value>
        public ISubmissionDomainService SubmissionManager { get; set; }

        /// <summary>
        /// Gets or sets the Course Manager
        /// </summary>
        public ICourseDomainService CourseManager { get; set; }

        /// <summary>
        /// Gets or sets the Module manager
        /// </summary>
        public IModuleDomainService ModuleManager { get; set; }

        /// <summary>
        /// Gets or sets the Unit Manager
        /// </summary>
        public IUnitDomainService UnitManager { get; set; }

        /// <summary>
        /// Gets or sets the file manager.
        /// </summary>
        /// <value>The file manager.</value>
        public IFileDomainService FileManager { get; set; }

        /// <summary>
        /// Gets or sets the task manager.
        /// </summary>
        /// <value>The task manager.</value>
        public ITaskDomainService TaskManager { get; set; }

        /// <summary>
        /// Gets or sets the task manager.
        /// </summary>
        /// <value>The task manager.</value>
        public IMessageDomainService MessageManager { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignmentTaskSubmissionAppService"/> class.
        /// </summary>
        /// <param name="assignmentManager">The assignment manager.</param>
        /// <param name="taskManager">The task manager.</param>
        /// <param name="submissionManager">The submission manager.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="cacheService">The cache service.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public AssignmentTaskSubmissionAppService(
            IAssignmentDomainService assignmentManager,
            ICourseDomainService courseManager,
            IModuleDomainService moduleManager,
            IUnitDomainService unitManager,
            ITaskDomainService taskManager,
            IMessageDomainService messageManager,
            ISubmissionDomainService submissionManager,
            IFileDomainService fileManager,
            IObjectMapperAdapter objectMapper,
            ICacheAdapter cacheService,
            IExceptionManagerAdapter exceptionManager,
            ILoggingServiceAdapter loggingService)
            : base(objectMapper, cacheService, exceptionManager, loggingService)
        {
            this.AssignmentManager = assignmentManager;
            this.TaskManager = taskManager;
            this.SubmissionManager = submissionManager;
            this.FileManager = fileManager;
            this.CourseManager = courseManager;
            this.ModuleManager = moduleManager;
            this.UnitManager = unitManager;
            this.MessageManager = messageManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all student assignment submissions.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="displayFilter">The display filter.</param>
        /// <param name="courseId">The course id.</param>
        /// <returns></returns>
        public List<AssignmentSubmissionViewModel> GetAllStudentAssignmentSubmissions(int studentId, StudentAssignmentFilterType displayFilter = StudentAssignmentFilterType.Active, int courseId = 0)
        {
            List<AssignmentSubmissionViewModel> models = new List<AssignmentSubmissionViewModel>();
            try
            {
                List<Assignment> assignments = AssignmentManager.GetAllAssignmentsByStudentAndCourse(studentId, displayFilter, courseId);
                models = AssignmentSubmissionViewModelFactory.CreateStudentAssignmentSubmissionViewModels(assignments, studentId, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }


        /// <summary>
        /// Gets the student assignment submission.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="assignmentId">The assignment id.</param>
        /// <returns></returns>
        public AssignmentSubmissionViewModel GetStudentAssignmentSubmission(int studentId, int assignmentId)
        {
            AssignmentSubmissionViewModel model = null;
            try
            {
                Assignment assignment = AssignmentManager.GetAssignmentForStudent(studentId, assignmentId);
                model = AssignmentSubmissionViewModelFactory.CreateStudentAssignmentSubmissionViewModel(assignment, studentId, ObjectMapper);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return model;
        }

        /// <summary>
        /// Gets all student upcoming task and assignment deadlines.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <returns></returns>
        public List<TaskAssignmentViewModel> GetAllStudentUpcomingTaskAndAssignmentDeadlines(int studentId)
        {
            List<TaskAssignmentViewModel> models = new List<TaskAssignmentViewModel>();
            try
            {
                List<BaseTask> deadlineList = new List<BaseTask>();
                deadlineList.AddRange(AssignmentManager.GetAllAssignmentsByStudentAndCourse(studentId, StudentAssignmentFilterType.Active, 0));
                deadlineList.AddRange(TaskManager.GetTasksWithUpcomingDeadlinesByUser(studentId));
                models = ObjectMapper.Map<Model.Entities.BaseTask, TaskAssignmentViewModel>(deadlineList.OrderBy(d => d.DaysDue).ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets the task filter view model
        /// </summary>
        /// <param name="action">The target action</param>
        /// <param name="controller">The target controller.</param>
        /// <param name="updateTargetId">The update target id.</param>
        /// <param name="displayFilter">The active display filter.</param>
        /// <returns></returns>
        public DisplayFilterViewModel GetTaskDisplayFilter(string action, string controller, string updateTargetId, TaskFilterType displayFilter = TaskFilterType.Active, string view="")
        {
            DisplayFilterViewModel model = null;
            try
            {
                model = DisplayFilterViewModelFactory.CreateTaskDisplayFilterViewModel(action, controller, updateTargetId, displayFilter, view);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return model;
        }

        /// <summary>
        /// Gets the assignment display filter.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="updateTargetId">The update target id.</param>
        /// <param name="displayFilter">The display filter.</param>
        /// <returns></returns>
        public DisplayFilterViewModel GetAssignmentDisplayFilter(string action, string controller, string updateTargetId, StudentAssignmentFilterType displayFilter = StudentAssignmentFilterType.Active)
        {
            DisplayFilterViewModel model = null;
            try
            {
                model = DisplayFilterViewModelFactory.CreateAssignmentDisplayFilterViewModel(action, controller, updateTargetId, displayFilter);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return model;
        }

        /// <summary>
        /// Gets filtered tasks
        /// </summary>
        /// <param name="studentId">The user id.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public List<TaskViewModel> GetTasks(int userId, TaskFilterType displayFilter = TaskFilterType.All)
        {
            List<TaskViewModel> models = new List<TaskViewModel>();
            try
            {
                List<Task> tasks = new List<Task>();
                tasks = TaskManager.GetAllTasksByUser(userId, displayFilter);
                models = ObjectMapper.Map<Model.Entities.Task, TaskViewModel>(tasks.OrderBy(t => t.IsCompleted).ThenByDescending(t => t.HasDeadline).ThenBy(t => t.DaysDue).ThenBy(t => t.DateCreated).ToList());
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Adds the task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="userId">The user id.</param>
        public TaskViewModel AddTask(TaskViewModel task, int studentId)
        {
            TaskViewModel taskViewModel = null;
            try
            {
                Task studentTask = ObjectMapper.Map<TaskViewModel, Model.Entities.Task>(task);
                studentTask.UserId = studentId;
                Task taskModel = TaskManager.Add(studentTask);
                taskViewModel = ObjectMapper.Map<Model.Entities.Task, TaskViewModel>(taskModel);
                return taskViewModel;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
                return taskViewModel;
            }
        }

        /// <summary>
        /// Completes the task.
        /// </summary>
        /// <param name="taskId">The task id.</param>
        public void CompleteTask(int taskId)
        {
            try
            {
                Task studentTask = TaskManager.FindBy(taskId);
                studentTask.IsCompleted = true;
                TaskManager.Update(studentTask);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        /// <summary>
        /// Saves the student submission.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="assignmentSubmissionViewModel">The assignment submission view model.</param>
        /// <param name="setStatusToSubmitted">if set to <c>true</c> [set status to submitted].</param>
        public AssignmentSubmissionViewModel SaveStudentSubmission(int studentId, AssignmentSubmissionViewModel assignmentSubmissionViewModel, bool setStatusToSubmitted = false)
        {
            try
            {
                Submission submission = ObjectMapper.Map<AssignmentSubmissionViewModel, Model.Entities.Submission>(assignmentSubmissionViewModel);
                submission.StudentId = studentId;            
                SubmissionManager.SubmissionForAssignmentAlreadyExists(ref submission);
                submission.Status = setStatusToSubmitted ? (int)SubmissionStatusType.Submitted : submission.Status;
                if (submission != null && submission.Id != 0)
                {
                    SubmissionManager.Update(submission);
                }
                else
                {
                    submission = SubmissionManager.Add(submission);
                    assignmentSubmissionViewModel.Id = submission.Id;
                }

                if (submission != null)
                {
                    List<string> associations = new List<string>();
                    associations.Add("CourseModules");
                    associations.Add("CourseModules.Course");
                    associations.Add("CourseModules.Course.StaffCourses");
                    AssignmentViewModel assignmentViewModel = GetAssignment(assignmentSubmissionViewModel.AssignmentId);
                    var module = ModuleManager.FindAll(associations).Where(m => m.Id.Equals(assignmentViewModel.ModuleId)).FirstOrDefault();

                    List<Message> messages = new List<Message>();
                    messages = StudentMessageViewModelFactory.CreateStudentAssignmentSubmissionMessages(module, assignmentViewModel, studentId);

                    MessageManager.AddMessages(messages);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return assignmentSubmissionViewModel;
        }

        /// <summary>
        /// Uploads the student submission document.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="assignmentSubmissionViewModel">The assignment submission view model.</param>
        public void UploadStudentSubmissionDocument(int studentId, AssignmentSubmissionViewModel assignmentSubmissionViewModel)
        {

            try
            {
                Submission submission = ObjectMapper.Map<AssignmentSubmissionViewModel, Model.Entities.Submission>(assignmentSubmissionViewModel);
                submission.StudentId = studentId;
                SubmissionManager.SubmissionForAssignmentAlreadyExists(ref submission);

                // Create Submission if does not exist
                if (submission == null || submission.Id == 0)
                {
                    submission = SubmissionManager.Add(submission);
                }

                // UploadFile
                UniEBoard.Model.Entities.File uploadFile = FileFactory.CreateSubmissionContentFile(submission.Id, submission.AssignmentId, assignmentSubmissionViewModel.UploadFile) as File;
                FileManager.Add(uploadFile);

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }


        /// <summary>
        /// Gets all assignment .
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AssignmentViewModel> GetAllAssignments()
        {
            List<AssignmentViewModel> models = new List<AssignmentViewModel>();
            try
            {
                List<Assignment> modules = AssignmentManager.FindAll();
                models = ObjectMapper.Map<Model.Entities.Assignment, AssignmentViewModel>(modules);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets the unit.
        /// </summary>
        /// <param name="unitId">The unit id.</param>
        /// <returns></returns>
        public AssignmentViewModel GetAssignment(int assgId)
        {
            AssignmentViewModel model = default(AssignmentViewModel);
            try
            {
                Assignment assignment = AssignmentManager.FindBy(assgId);
                model = ObjectMapper.Map<Model.Entities.Assignment, AssignmentViewModel>(assignment);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return model;
        }

        /// <summary>
        /// Updates the assignment.
        /// </summary>
        /// <param name="assignment">The assignment.</param>
        public void UpdateAssignment(AssignmentViewModel assignmentViewModel)
        {
            try
            {
                Assignment assignment = ObjectMapper.Map<AssignmentViewModel, Model.Entities.Assignment>(assignmentViewModel);
                AssignmentManager.Update(assignment);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        /// <summary>
        /// Creates the assignment.
        /// </summary>
        /// <param name="assignmentViewModel">The assignment view model.</param>
        public void CreateAssignment(AssignmentViewModel assignmentViewModel, int? userId = null)
        {
            try
            {
                if (assignmentViewModel != null)
                {
                    Assignment assignment = ObjectMapper.Map<AssignmentViewModel, Model.Entities.Assignment>(assignmentViewModel);
                    assignment = AssignmentManager.Add(assignment);
                    if (assignment != null)
                    {
                        List<string> associations = new List<string>();
                        associations.Add("CourseModules");
                        associations.Add("CourseModules.Course");
                        associations.Add("CourseModules.Course.CourseRegistrations");
                        var module = ModuleManager.FindAll(associations).Where(m => m.Id.Equals(assignment.ModuleId)).FirstOrDefault();
                        List<Message> messages = new List<Message>();
                        messages = StudentMessageViewModelFactory.CreateTeacherAssignmentMessages(module, assignment, userId);
                        MessageManager.AddMessages(messages);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
        }

        #endregion
    }
}
