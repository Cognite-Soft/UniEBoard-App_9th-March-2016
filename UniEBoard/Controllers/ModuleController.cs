using Cognite.Utility.MethodExtensions.StringExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniEBoard.Service.Models.Units;
using WebMatrix.WebData;
using UniEBoard.Filters;
using UniEBoard.Service.Interfaces.ApplicationService;
using UniEBoard.Model.Enums;
using UniEBoard.Service.Models;
using UniEBoard.Service.Models.Quizzes;
using UniEBoard.Service.ApplicationServices;
using UniEBoard.Security;
using System.IO;
using System.Web.Security;
using UniEBoard.Resource;
using UniEBoard.Service.Helpers.Comparer;
using Cognite.Utility.Helpers.Methods;
using System.Text;
using UniEBoard.Service.Helpers.Configuration;
using System.Net.Mail;
using UniEBoard.Model.Entities;

using cog = Cognite.MembershipProvider;

namespace UniEBoard.Controllers
{
    public class ModuleController : BaseController
    {
        //
        // GET: /Module/

        #region Members

        /// <summary>
        /// Assignment, Task and Submission Service
        /// </summary>
        private IAssignmentTaskSubmissionAppService _assignmentTaskAndSubmissionService;

        /// <summary>
        /// File Service
        /// </summary>
        private IFileAppService _fileService;

        /// <summary>
        /// Message Service
        /// </summary>
        private IMessageAppService _messageService;

        /// <summary>
        /// Course And Module Application Service 
        /// </summary>
        private ICourseModuleAppService _courseModuleService;

        /// <summary>
        /// BaseQuestionTopic Application Service 
        /// </summary>
        private IBaseQuestionTopicAppService _baseQuestionTopicModuleService;

        /// <summary>
        /// Staff Application Service
        /// </summary>
        private IStaffAppService _staffService;

        /// <summary>
        /// Student Application Service
        /// </summary>
        private IStudentAppService _studentService;

        /// <summary>
        /// Asset Application Service
        /// </summary>
        private IAssetAppService _assetService;

        /// <summary>
        /// Module Application Service
        /// </summary>
        private IUnitModuleAppService _unitModuleAppService;

        /// <summary>
        /// Video Application Service
        /// </summary>
        private IVideoAppService _videoAppService;

        /// <summary>
        /// Quiz Application Service
        /// </summary>
        private IQuizAppService _quizAppService;

        /// <summary>
        /// User Application Service
        /// </summary>
        private IUserAppService _userAppService;

        /// <summary>
        /// Question Application Service
        /// </summary>
        private IQuestionAppService _questionAppService;

        /// <summary>
        /// Answer Application Service
        /// </summary>
        public IAnswerAppService _answerAppService { get; set; }

        /// <summary>
        /// Schedule Application Service
        /// </summary>
        private IScheduleAppService _scheduleAppService;

        /// <summary>
        /// Discussion Application Service
        /// </summary>
        private IDiscussionAppService _discussionAppService;

        static List<AssetViewModel> assignmentAssets = new List<AssetViewModel>();

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TeacherController"/> class.
        /// </summary>
        /// <param name="staffService">The staff service.</param>
        /// <param name="assetService">The asset service.</param>
        /// <param name="assignmentTaskAndSubmission">The assignment task and submission.</param>
        /// <param name="messageService">The message service.</param>
        /// <param name="courseModuleService">The course module service.</param>
        /// <param name="fileService">The file service.</param>
        /// <param name="basequestionTopicService">The basequestionTopic service.</param>
        public ModuleController(
            IStaffAppService staffService,
            IStudentAppService studentService,
            IAssetAppService assetService,
            IAssignmentTaskSubmissionAppService assignmentTaskAndSubmission,
            IMessageAppService messageService,
            ICourseModuleAppService courseModuleService,
            IFileAppService fileService,
            IUserAppService userAppService,
            IBaseQuestionTopicAppService basequestionTopicService,
            IUnitModuleAppService iUnitModuleAppService,
            IVideoAppService iVideoAppService,
            IQuizAppService quizAppService,
            IQuestionAppService questionAppService,
            IAnswerAppService answerAppService,
            IScheduleAppService scheduleAppService,
            IDiscussionAppService discussionAppService
            )
            : base(userAppService)
        {
            this._staffService = staffService;
            this._studentService = studentService;
            this._assetService = assetService;
            this._assignmentTaskAndSubmissionService = assignmentTaskAndSubmission;
            this._messageService = messageService;
            this._courseModuleService = courseModuleService;
            this._fileService = fileService;
            this._baseQuestionTopicModuleService = basequestionTopicService;
            this._unitModuleAppService = iUnitModuleAppService;
            this._videoAppService = iVideoAppService;
            this._quizAppService = quizAppService;
            this._userAppService = userAppService;
            this._questionAppService = questionAppService;
            this._answerAppService = answerAppService;
            this._scheduleAppService = scheduleAppService;
            this._discussionAppService = discussionAppService;
        }





        #endregion






        #region Modules

        /// <summary>
        /// Modules this instance.
        /// </summary>
        /// <returns></returns>
        [ActionName("Modules")]
        public ActionResult Modules()
        {
            var displayFilter = new PageViewAllFilterViewModel(Url.Action("Modules", "Teacher"));
            ViewData["Pager"] = displayFilter;

            ViewBag.StatusMessage = Convert.ToString(TempData["StatusMessage"]);

            var courseId = Request.QueryString["courseId"];
            return Modules(displayFilter, courseId);
        }

        /// <summary>
        /// Modules this instance.
        /// </summary>
        /// <returns></returns>
        [ActionName("Modules")]
        [HttpPost]
        public ActionResult Modules(PageViewAllFilterViewModel pageViewFilterModel, string courseId)
        {
            ViewData["Pager"] = pageViewFilterModel;
            ViewData["CourseId"] = (courseId == null ? "" : courseId.ToString());
            var modulesAssociatedToAndCreatedByTeacher = string.IsNullOrEmpty(courseId) ? _courseModuleService.GetModulesForTeacher(CurrentUser.Id)
                : _courseModuleService.GetModulesForTeacherByCourseId(CurrentUser.Id, int.Parse(courseId));

            ViewData["ModuleList"] = pageViewFilterModel.SelectedFilter != 0 ? modulesAssociatedToAndCreatedByTeacher.Take(pageViewFilterModel.SelectedFilter).OrderBy(o => o.SortOrder) : modulesAssociatedToAndCreatedByTeacher.OrderBy(o => o.SortOrder);



            Session["CourseList"] = _courseModuleService.GetCoursesWithDepartmentByStaffId(CurrentUser.Id, pageViewFilterModel.SelectedFilter)
                .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Title }).ToArray();
            //Drop Down List for Courses
            var courses = from CourseViewModel c in _courseModuleService.GetAllCourses()
                          select new { Id = c.Id, Name = c.Title };

            ViewBag.CoursesDropDownList = new SelectList(courses, "Id", "Name");
            //List<ModuleViewModel> moduleList = this._courseModuleService.GetModulesByTeacherId(CurrentUser.Id, pageViewFilterModel.SelectedFilter).ToList();
            //.GetCoursesWithDepartmentByStaffId(CurrentUser.Id, pageViewFilterModel.SelectedFilter);
            return View();
        }

        [HttpPost]
        public ActionResult ModuleByCourse(int? id, int filter)
        {
            var displayFilter = (PageViewAllFilterViewModel)ViewData["Pager"];
            ViewData["CourseId"] = (!id.HasValue ? "" : id.ToString());
            var modules = new List<ModuleViewModel>().AsEnumerable();
            if (id.HasValue)
                modules = _courseModuleService.GetModulesForTeacherByCourseId(CurrentUser.Id, id.Value).Take(filter);
            else
                modules = _courseModuleService.GetModulesForTeacher(CurrentUser.Id).Take(filter);
            ViewData["ModuleList"] = modules.ToList();
            return PartialView("_ModuleListPartial", modules);
        }

        private TopicViewModel PrepareTopicViewModel(ModuleViewModel module, int discussionId)
        {
            TopicViewModel topicViewModel = new TopicViewModel();
            topicViewModel.IsTopic = true;
            topicViewModel.OriginatorId = module.CreatedByStaff_Id;
            topicViewModel.Title = module.Title;
            topicViewModel.Description = module.Description;
            topicViewModel.DiscussionId = discussionId;

            return topicViewModel;
        }

        /// <summary>
        /// Creates the module.
        /// </summary>
        /// <param name="unitViewModel">The unit view model.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateModule(ModuleViewModel moduleViewModel)
        {

            var displayFilter = (PageViewAllFilterViewModel)ViewData["Pager"];
            var selectedCourse = moduleViewModel.Course_Id;
            if (ModelState.IsValid)
            {
                moduleViewModel.CreatedByStaff_Id = CurrentUser.Id;
                if (_courseModuleService.CreateModule(moduleViewModel))
                {
                    DiscussionViewModel discussion = _discussionAppService.GetCourseDiscussionsWithLatestPosts(selectedCourse).FirstOrDefault();
                    if (discussion != null)
                    {
                        TopicViewModel topicViewModel = PrepareTopicViewModel(moduleViewModel, discussion.Id);
                        _discussionAppService.AddTopic(topicViewModel);
                    }
                }
                else {
                    UniEBoard.Helpers.StatusHelper.ErrorMessage("An error occurred while creating new module. Please contact the administrator", this);
                }

                UniEBoard.Helpers.StatusHelper.SuccessMessage("Module has been created successfully.", this);
                return RedirectToAction("Modules");
            }
            else
            {

                ViewData["ModuleList"] = _courseModuleService.GetModulesForTeacher(CurrentUser.Id).OrderBy(o => o.SortOrder);

                ViewData["CourseId"] = "";

                Session["CourseList"] = _courseModuleService.GetCoursesWithDepartmentByStaffId(CurrentUser.Id, 10)
                .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Title }).ToArray();

                //Drop Down List for Courses
                var courses = from CourseViewModel c in _courseModuleService.GetAllCourses()
                              select new { Id = c.Id, Name = c.Title };

                ViewBag.CoursesDropDownList = new SelectList(courses, "Id", "Name");

                return View("Modules");
                //return RedirectToAction("Modules", new { pageViewFilterModel = displayFilter, courseId = selectedCourse });
            }
        }

        public ActionResult RemoveModule(int moduleId)
        {
            // Set ModuleId = 0 in Assignment
            var assignmentsList = _assignmentTaskAndSubmissionService.GetAllAssignments().Where(x => x.ModuleId == moduleId).ToList();
            foreach (var assignment in assignmentsList)
            {
                assignment.ModuleId = null;
                _assignmentTaskAndSubmissionService.UpdateAssignment(assignment);
            }

            // Delete Module Quiz
            var moduleQuizList = _quizAppService.ModuleQuizManager.FindAll().Where(x => x.ModuleId == moduleId).ToList();
            foreach (var moduleQuiz in moduleQuizList)
            {
                _quizAppService.ModuleQuizManager.Remove(moduleQuiz.Id);
            }

            // Set Module = null in Unit
            var UnitList = _unitModuleAppService.UnitManager.FindAll().Where(u => u.ModuleId.Equals(moduleId)).ToList(); //.FindUnitsByModuleId(moduleId, 0).ToList();
            foreach (var unit in UnitList)
            {
                unit.ModuleId = null;
                _unitModuleAppService.UnitManager.Update(unit);
            }

            // Delete Course Modules
            _courseModuleService.RemoveModuleFromCourse(moduleId);

            // Delete Module
            _courseModuleService.ModuleManager.Remove(moduleId);

            return RedirectToAction("Modules");
        }

        /// <summary>
        /// Updates the name of the asset.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="assetId">The asset id.</param>
        public PartialViewResult UpdateModule(string moduleId, string name, string description,
             string publishFrom, string publishTo, string courseName)
        {
            ModuleViewModel module = _courseModuleService.GetModuleById(moduleId.ToInteger());
            CourseViewModel course = _courseModuleService.GetCourseByName(courseName);

            if (module != null)
            {
                DateTime pFrom, pTo;
                module.Title = name;
                module.Description = description;
                if (DateTime.TryParse(publishFrom, out pFrom))
                {
                    module.PublishFrom = pFrom;
                }
                if (DateTime.TryParse(publishTo, out pTo))
                {
                    module.PublishTo = pTo;
                }

                _courseModuleService.UpdateModule(module);

                if (course != null)
                {

                    CourseModuleViewModel courseModuleViewModel = new CourseModuleViewModel();
                    courseModuleViewModel.Module_Id = module.Id;
                    courseModuleViewModel.Course_Id = course.Id;

                    _courseModuleService.AddCourseModule(courseModuleViewModel);
                }
            }
            return PartialView("_CourseModuleTagPartial", _courseModuleService.GetCourseModulesByModule(moduleId.ToInteger()));
        }

        [HttpPost]
        public void UpdateModulesOrder(List<string> draggedItemId)
        {
            UpdateModuleOrder(draggedItemId);
        }

        private void UpdateModuleOrder(List<string> draggedItemId)
        {
            /*********************************
             * Current implementation works perfect with non-pagination results but the logic doesn't support pagination in place. 
             * This makes it more complex to handle the results. 
             *********************************/
            int sort = 0;
            foreach (var moduleId in draggedItemId)
            {
                int id = 0;
                if (int.TryParse(moduleId, out id))
                {
                    var module = _courseModuleService.GetModuleById(id);
                    module.SortOrder = sort++;
                    _courseModuleService.UpdateModule(module);
                }
                else
                {
                    throw new InvalidCastException();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseModuleId"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCourseToModule(int courseModuleId, int moduleId)
        {
            //_courseModuleService.RemoveCourseFromModule(courseModuleId);
            return PartialView("_CourseModuleTagPartial", _courseModuleService.GetCourseModulesByModule(moduleId));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseModuleId"></param>
        public ActionResult RemoveCourseFromModule(int courseModuleId, int moduleId)
        {
            _courseModuleService.RemoveCourseModule(courseModuleId);
            return PartialView("_CourseModuleTagPartial", _courseModuleService.GetCourseModulesByModule(moduleId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public ActionResult AutoCompleteCourses(string term)
        {
            //string search = '';
            var json = Json((from course in _courseModuleService.GetCoursesByStaff(CurrentUser.Id)
                             where (course.Title.ToLower().Contains(term.ToLower()))
                             select new { label = course.Title, id = course.Title }).ToArray(), JsonRequestBehavior.AllowGet);
            return json;
        }

        #endregion
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Module/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Module/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Module/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Module/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Module/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Module/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Module/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
