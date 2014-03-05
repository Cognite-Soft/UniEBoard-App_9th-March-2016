// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StudentAppService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Student Application Service Operations
//  Transforms entity domain models to view models
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Service.Interfaces.ApplicationService;
using UniEBoard.Service.Models;
using UniEBoard.Service.Factories;
using UniEBoard.Model.Adapters.Logging;
using UniEBoard.Service.Helpers.Comparer;

namespace UniEBoard.Service.ApplicationServices
{
    /// <summary>
    /// Student Application Service Class - Contains Methods for Student Application Service Operations
    /// </summary>
    public class StudentAppService : BaseAppService, IStudentAppService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the student manager.
        /// </summary>
        /// <value>The student manager.</value>
        public IStudentDomainService StudentManager { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentAppService"/> class.
        /// </summary>
        /// <param name="studentManager">The student manager.</param>
        /// <param name="objectMapper">The object mapper.</param>
        /// <param name="cacheService">The cache service.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public StudentAppService(
            IStudentDomainService studentManager,
            IObjectMapperAdapter objectMapper,
            ICacheAdapter cacheService,
            IExceptionManagerAdapter exceptionManager,
            ILoggingServiceAdapter loggingService)
            : base(objectMapper, cacheService, exceptionManager, loggingService)
        {
            this.StudentManager = studentManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <typeparam name="TStudentViewModel">The type of the student view model.</typeparam>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public List<StudentViewModel> GetAllStudents()
        {

            List<StudentViewModel> models = new List<StudentViewModel>();
            try
            {
                List<Student> students = StudentManager.FindAll();
                models = ObjectMapper.Map<Model.Entities.Student, StudentViewModel>(students);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return models;
        }

        /// <summary>
        /// Gets the student by member ship id.
        /// </summary>
        /// <typeparam name="TStudentViewModel">The type of the student view model.</typeparam>
        /// <param name="membershipId">The membership id.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public StudentViewModel GetStudentByMemberShipId(int membershipId)
        {
            StudentViewModel model = default(StudentViewModel);
            try
            {
                Student student = StudentManager.GetStudentByMemberShipId(membershipId);
                model = ObjectMapper.Map<Model.Entities.Student, StudentViewModel>(student);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return model;
        }

        /// <summary>
        /// Creates the student user.
        /// </summary>
        /// <typeparam name="TRegisterStudentViewModel">The type of the register student view model.</typeparam>
        /// <param name="membershipId">The membership ProviderId id.</param>
        /// <param name="model">The model.</param>
        public bool CreateStudentUser(int membershipProviderId, StudentViewModel model)
        {
            try
            {
                Student user = ObjectMapper.Map<StudentViewModel, Model.Entities.Student>(model);
                user.Membership_Id = membershipProviderId;
                StudentManager.Add(user);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
                return false;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void UpdateStudentUser(StudentViewModel model)
        {
            Student student = ObjectMapper.Map<StudentViewModel, Model.Entities.Student>(model);
            StudentManager.Update(student);
        }

        /// <summary>
        /// Finds all the students in the same class.
        /// </summary>
        /// <param name="userName">The student Id</param>
        /// <returns>A list of fellow users</returns>
        public List<StudentViewModel> GetFellowStudents(int studentId)
        {
            List<StudentViewModel> students = new List<StudentViewModel>();

            try
            {
                var studentEntities = StudentManager.GetFellowStudents(studentId);
                students = ObjectMapper.Map<Student, StudentViewModel>(studentEntities);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }

            return students.Distinct(new ViewModelComparer<StudentViewModel>()).ToList();
        }

        /// <summary>
        /// Finds the Teacher for students
        /// </summary>
        /// <param name="userName">The student id</param>
        /// <returns>A list of teachers for students</returns>
        public List<StaffViewModel> GetTeachersByStudent(int studentId)
        {
            List<StaffViewModel> teachers = new List<StaffViewModel>();
            try
            {
                var teacherEntities = StudentManager.GetTeachersByStudent(studentId);
                teachers = ObjectMapper.Map<Staff, StaffViewModel>(teacherEntities);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }

            return teachers.Distinct(new ViewModelComparer<StaffViewModel>()).ToList();
        }

        /// <summary>
        /// returns a list of users including the fellow students and teachers for the students
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>List of UserViewModel</returns>
        public List<UserViewModel> GetUsersForStudent(int studentId)
        {
            List<UserViewModel> users = new List<UserViewModel>();
            var students = GetFellowStudents(studentId);
            var teachers = GetTeachersByStudent(studentId);

            users.AddRange(students);
            users.AddRange(teachers);
            return users;
        }

        /// <summary>
        /// Finds a list of courses student is registered for.
        /// </summary>
        /// <param name="studentId">Student Id</param>
        /// <returns>A List of Courses</returns>
        public List<CourseViewModel> GetRegisteredCourses(int studentId)
        {
            List<CourseViewModel> courses = new List<CourseViewModel>();
            try
            {
                var coursesEntities = StudentManager.GetRegisteredCourses(studentId);
                courses = ObjectMapper.Map<Course, CourseViewModel>(coursesEntities);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return courses;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public int GetGradeForStudentByCourse(int studentId, int courseId)
        {
            try
            {
                return StudentManager.GetGradeForStudentByCourse(studentId, courseId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public List<ModuleGradeViewModel> GetGradeForStudentByCoursePerModule(int studentId, int courseId)
        {
            List<ModuleGradeViewModel> moduleGrades = new List<ModuleGradeViewModel>();
            try
            {
                moduleGrades = ObjectMapper.Map<Model.Entities.ModuleGrade, ModuleGradeViewModel>(StudentManager.GetGradeForStudentByCoursePerModule(studentId, courseId));
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }

            return moduleGrades;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public List<SubmissionViewModel> GetGradeForStudentByCoursePerAssignment(int studentId, int courseId)
        {
            List<SubmissionViewModel> submissions = new List<SubmissionViewModel>();
            
            try
            {
                submissions = ObjectMapper.Map<Model.Entities.Submission, SubmissionViewModel>(StudentManager.GetGradeForStudentByCoursePerAssignment(studentId, courseId));
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionReplacing);
            }

            return submissions;
        }

        #endregion
    }
}
