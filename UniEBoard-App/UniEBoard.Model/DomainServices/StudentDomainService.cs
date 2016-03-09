// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StudentDomainService.cs" company="Cognite Ltd">
//   Copyright (c) 2013 Cognite Ltd (http://www.cognite.co.uk)
// </copyright>
// <summary>
//  Contains Methods for Student Operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Enums;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Factories;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Model.Interfaces.Repository;

namespace UniEBoard.Model.DomainServices
{
    /// <summary>
    /// StudentDomainService class definition - Contains Methods for Student Operations
    /// </summary>
    public class StudentDomainService : BaseDomainService<Student, IStudentRepository>, IStudentDomainService
    {
        #region Properties

        /// <summary>
        /// StudentRepository instance
        /// </summary>
        public IStudentRepository StudentRepository;
        public IQuizEntryRepository QuizEntryRepository;
        public ISubmissionRepository SubmissionRepository;
        public IModuleRepository ModuleRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentDomainService"/> class.
        /// </summary>
        /// <param name="studentRepository">The student repository.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        /// <param name="loggingService">The logging service.</param>
        public StudentDomainService(IStudentRepository studentRepository, IQuizEntryRepository quizEntryRepository, ISubmissionRepository submissionRepository, IModuleRepository moduleRepository, IExceptionManagerAdapter exceptionManager, ILoggingServiceAdapter loggingService)
            : base(studentRepository, exceptionManager, loggingService)
        {
            StudentRepository = studentRepository;
            QuizEntryRepository = quizEntryRepository;
            SubmissionRepository = submissionRepository;
            ModuleRepository = moduleRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the student by member ship id.
        /// </summary>
        /// <param name="membershipId">The membership id.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public Student GetStudentByMemberShipId(int membershipId)
        {
            Student student = null;
            try
            {
                student = StudentRepository.GetStudentByMemberShipId(membershipId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return student;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public int GetGradeForStudentByCourse(int studentId, int courseId) 
        {
            List<QuizEntry> quizEntries = QuizEntryRepository.GetQuizEntriesForStudent(studentId, courseId);
            List<Submission> submissions = SubmissionRepository.GetSubmissionsForStudent(studentId, courseId);
            
            //int studentGrade = quizEntries.Sum(p => p.QuizResult ?? 0) + submissions.Sum(p => p.GradePointValue ?? 0);

            int quizGrade = quizEntries.Sum(p => p.QuizResult ?? 0);
            int subGrade = submissions.Sum(p => p.GradePointValue ?? 0);
            int studentGrade = quizGrade + subGrade;

            //int totalScore = submissions.Select(s => s.Assignment).Sum(a => a.PointsPossible ?? 0) +
            //quizEntries.Select(qe => qe.Quiz).Sum(q => q.TotalPoints);            
            
            //return ((studentGrade*100)/totalScore);     
            return studentGrade;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public List<ModuleGrade> GetGradeForStudentByCoursePerModule(int studentId, int courseId) 
        {
            List<Module> modules = ModuleRepository.GetModulesAndQuizzesByCourseAndStudent(studentId, courseId);
            
            // Getting total grades of quizzes per module            
            var quizzesPerModule = new List<ModuleGrade>();
            foreach (var mod in modules)
            {
                ModuleGrade mg = new ModuleGrade();
                mg.Module = mod;
                
                List<QuizEntry> quizEntries = new List<QuizEntry>();
                mod.ModuleQuizs.ToList().ForEach(mq => quizEntries.AddRange(mq.Quiz.QuizEntries.ToList()
                    .Where(qe => qe.Student_Id == studentId)));

                if (quizEntries.Count() != 0)
                {
                    mg.Grade = quizEntries.AsEnumerable().Sum(q => q.QuizResult ?? 0);
                    quizzesPerModule.Add(mg);
                }
            }

            // Getting total grades of submissions per module
            List<Submission> submissions = SubmissionRepository.GetSubmissionsForStudent(studentId, courseId);
            var submissionsPerModule = new List<ModuleGrade>();
            foreach (var mod in modules)
            {                
                int grade = 0;
                foreach (var sub in submissions)
                { 
                    if(sub.Assignment.Module.Id == mod.Id)
                    {
                        grade += sub.GradePointValue ?? 0;
                    }
                }
                ModuleGrade mg = new ModuleGrade();
                mg.Module = mod;
                mg.Grade = grade;
                submissionsPerModule.Add(mg);
            }
            
            //var submissionsPerModule = from sub in submissions
            //                           group sub by sub.Assignment.Module into mod
            //                           select new ModuleGrade { Module = mod.Key, Grade = mod.Sum(s => s.GradePointValue ?? 0) };


            // merging and adding grades of both lists            
            //var allModuleGrades = from qm in (quizzesPerModule.Concat(submissionsPerModule))
            //                      group qm by qm.Module into mod                                  
            //                      select new ModuleGrade { Module = mod.Key, Grade = mod.Sum(g => g.Grade) };

            var allModuleGrades = new List<ModuleGrade>();
            foreach (var sub in submissionsPerModule)
            {
                ModuleGrade mg = new ModuleGrade();
                mg.Module = sub.Module;
                int gradeQuiz = 0;
                foreach (var quiz in quizzesPerModule)
                {                    
                    if (quiz.Module.Id == sub.Module.Id) 
                    {
                        gradeQuiz += quiz.Grade;
                    }   
                }
                mg.Grade = gradeQuiz + sub.Grade;
                allModuleGrades.Add(mg);
            }            

            return allModuleGrades.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public List<Submission> GetGradeForStudentByCoursePerAssignment(int studentId, int courseId)
        {
            return SubmissionRepository.GetSubmissionsForStudent(studentId, courseId);            
        }

        /// <summary>
        /// Finds all the students in the same class.
        /// </summary>
        /// <param name="userName">The student Id</param>
        /// <returns>A list of fellow users</returns>
        public List<Student> GetFellowStudents(int studentId)
        {
            List<Student> students = new List<Student>();
            try
            {
                students = StudentRepository.FindFellowStudents(studentId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return students;
        }

        /// <summary>
        /// Finds the Teacher for students
        /// </summary>
        /// <param name="userName">The student id</param>
        /// <returns>A list of teachers for students</returns>
        public List<Staff> GetTeachersByStudent(int studentId)
        {
            List<Staff> teachers = new List<Staff>();
            try
            {
                teachers = StudentRepository.FindTeacherByStudent(studentId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return teachers;
        }

        /// <summary>
        /// Finds a list of courses student is registered for.
        /// </summary>
        /// <param name="studentId">Student Id</param>
        /// <returns>A List of Courses</returns>
        public List<Model.Entities.Course> GetRegisteredCourses(int studentId)
        {
            List<Course> courses = new List<Course>();
            try
            {
                courses = StudentRepository.FindRegisteredCourses(studentId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }
            return courses;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        public List<Student> GetStudentsForTeacher(int teacherId)
        {
            List<Student> students = new List<Student>();

            try
            {
                students = StudentRepository.GetStudentsForTeacher(teacherId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }


            return students;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<Student> GetStudentsForModule(int moduleId) 
        {
            List<Student> students = new List<Student>();

            try
            {
                students = StudentRepository.GetStudentsForModule(moduleId);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex, PolicyNameType.ExceptionShielding);
            }


            return students;
        
        }

        #endregion
    }
}
