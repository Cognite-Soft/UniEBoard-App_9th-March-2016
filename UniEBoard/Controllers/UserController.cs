using Cognite.Utility.MethodExtensions.StringExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniEBoard.Service.Models.Units;
using WebMatrix.WebData;
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
using UniEBoard.Filters;

using cog = Cognite.MembershipProvider;


namespace UniEBoard.Controllers
{

    [CustomAuthorize(Roles = "Administrator")]

    [InitializeSimpleMembership]
    public class UserController : BaseController
    {


        #region Members

        /// <summary>
        /// Staff Application Service
        /// </summary>
        private IStaffAppService _staffService;


        private IQuestionAppService _questionAppService;

        /// <summary>
        /// Student Application Service
        /// </summary>
        private IStudentAppService _studentService;

        private IUserAppService _userAppService;

        private IUnitModuleAppService _iUnitModuleAppService;


        /// <summary>
        /// Module Application Service
        /// </summary>
        private IUnitModuleAppService _unitModuleAppService;


        /// <summary>
        /// Course And Module Application Service 
        /// </summary>
        private ICourseModuleAppService _courseModuleService;

        public UserViewModel _currentUser ;

        #endregion

        #region AdminController

        public UserController(IStaffAppService staffService,
                                IStudentAppService studentService,
                                IUserAppService userAppService,
                                ICourseModuleAppService courseModuleService,
                                  IQuestionAppService questionAppService,
                                   IUnitModuleAppService iUnitModuleAppService) : base(userAppService)
        {
            this._staffService = staffService;
            this._studentService = studentService;
            this._userAppService = userAppService;
            this._courseModuleService = courseModuleService;
            this._questionAppService = questionAppService;
            this._iUnitModuleAppService = iUnitModuleAppService;
            _currentUser = CurrentUser;
        }

        public ActionResult GetAllUsers()
        {
            List<UserViewModel> user = _userAppService.GetAllUsersByCompany(CurrentUser.CompanyId, 0);
            ViewData["Users"] = user;
            return View(user);
        }


        #region Users

        /// <summary>
        /// The Users instance.
        /// </summary>
        /// <returns></returns>
        [ActionName("Users")]
        public ActionResult Users()
        {
        
            var displayFilter = new PageViewAllFilterViewModel(Url.Action("Users", "User"));
            ViewData["Pager"] = displayFilter;
            //ViewData["Courses"] = _courseModuleService.GetCoursesByStaff(CurrentUser.Id).Select(v => new SelectListItem { Value = v.Id.ToString(), Text = v.Title }).ToArray();
            ViewData["Courses"] = _courseModuleService.GetAllCourses().Select(v => new SelectListItem { Value = v.Id.ToString(), Text = v.Title }).ToArray();
            ViewData["Users"] = _userAppService.GetStudentUsersByCompany(CurrentUser.CompanyId, displayFilter.SelectedFilter);
            ViewData["Roles"] = _userAppService.GetAllAvailableRoles().Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Title }).ToArray();
            SelectList selectList = new SelectList(_userAppService.GetAllAvailableRoles(), "Title", "Title");            
            ViewBag.RoleList = selectList;

            List<CourseViewModel> lstCourseViewModel = _courseModuleService.GetAllCourses().OrderBy(o => o.Title).ToList();
            //var selectListCourse = new SelectList(_courseModuleService.GetAllCourses(), "Code", "Title");         
            ViewBag.CourseList = lstCourseViewModel;
           // ViewBag.Courses = selectListCourse.;            
            return View();
        }

        /// <summary>
        /// The Users instance.
        /// </summary>
        /// <returns></returns>
        [ActionName("Users")]
        [HttpPost]
        public ActionResult Users(PageViewAllFilterViewModel pageViewFilterModel)
        {
            //StaffViewModel staff = _staffService.GetStaffByMemberShipId(CurrentUser.Id);
            ViewData["Pager"] = pageViewFilterModel;
            ViewData["Courses"] = _courseModuleService.GetCoursesByStaff(CurrentUser.Id).Select(v => new SelectListItem { Value = v.Id.ToString(), Text = v.Title }).ToArray();
            ViewData["Users"] = _userAppService.GetStudentUsersByCompany(CurrentUser.CompanyId, pageViewFilterModel.SelectedFilter);
            ViewData["Roles"] = _userAppService.GetAllAvailableRoles().Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Title }).ToArray();      


            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UserListFilteredPartial(string filter)
        {
           // StaffViewModel staff = _staffService.GetStaffByMemberShipId(CurrentUser.Id);
          //  var users = _userAppService.GetStudentUsersByCompany(staff.CompanyId, filter);
            List<UserViewModel> lstUserViewModel = _userAppService.GetAllUsersByCompany(CurrentUser.CompanyId,0);

            

            var matchingvalues = lstUserViewModel.Where(x => x.FirstName.StartsWith(filter,StringComparison.OrdinalIgnoreCase)).ToList();

            return PartialView("_UserListPartial", matchingvalues);
        }

        [HttpPost]
        public void UpdateUser(string userId, bool isEnabled)
        {
            var uId = userId;
            UserViewModel userViewModel = _userAppService.GetUserById(userId.ToInteger());
            userViewModel.AccountDisabled = !isEnabled;
            _userAppService.UpdateUser(userViewModel);
            //_userAppService.UserManager.Update(

        }

        [HttpPost]
        public ActionResult RemoveUserFromCourse(int userId, int courseId)
        {
            if (_userAppService.RemoveUserFromCourse(userId, courseId))
            {
                ViewData["UserIdentifier"] = userId;
                return PartialView("_CourseTagPartial", _courseModuleService.GetAllStudentCourses(userId));
            }
            return View();
        }

        public ActionResult AutoCompleteUsers(string term)
        {
            var json = Json((from user in _staffService.GetAllStaff()
                             where user.FullName.ToUpper().Contains(term.ToUpper())
                             select new { userName = user.FullName, id = user.Id }).ToArray(), JsonRequestBehavior.AllowGet);
            return json;
        }

        public void UpdateOrder(List<string> draggedItemId, string type)
        {
            switch (type)
            {
                case "courses":
                    UpdateCourseOrder(draggedItemId);
                    break;
                case "modules":
                    UpdateModuleOrder(draggedItemId);
                    break;
                case "questions":
                    UpdateQuestionOrder(draggedItemId);
                    break;
                case "units":
                    UpdateUnitOrder(draggedItemId);
                    break;
            }
        }

        /// <summary>
        /// The Users instance.
        /// </summary>
        /// <returns></returns>
        [ActionName("CreateUser")]
        [HttpPost]
        public ActionResult CreateUser(UserViewModel user)
        {
            StaffViewModel staff = _staffService.GetStaffByMemberShipId(_currentUser.Membership_Id);

         
            try
            {
                if (ModelState.IsValid)
                {
                    UserViewModel existingUser = _userAppService.GetUserByUserName(user.Email);
                    // if user exists then add it to the selected course
                    if (existingUser != null)
                    {
                        existingUser.FirstName = user.FirstName;
                        existingUser.LastName = user.LastName;
                        if (!SelectedCourseAlreadyExistsFor(existingUser, user.DefaultCourseId))
                        {
                            CourseRegistrationViewModel registration = new CourseRegistrationViewModel() { Course_Id = user.DefaultCourseId, Student_Id = existingUser.Id };
                            _courseModuleService.CreateCourseRegistration(registration);
                            _studentService.UpdateStudentUser((StudentViewModel)existingUser);
                        }
                        else
                        {
                            ModelState.AddModelError("", string.Format("The user {0} has already been assign to the course '{1}'", existingUser.UserName, _courseModuleService.GetCourseById(existingUser.DefaultCourseId).Title));
                        }

                    }
                    // if user doesn't exist then create a new one
                    else
                    {
                        if (user._roleViewModel == "Student")
                        {
                            UserViewModel studentViewModel = new StudentViewModel()
                            {
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                Email = user.Email,
                                UserName = user.Email,
                                Password = "Password123",
                                UserGender = (int)GenderType.NotSpecified,
                                CompanyId = _currentUser.CompanyId
                            };                            
                            cog.WebSecurity.CreateUserAndAccount(studentViewModel.UserName, studentViewModel.Password);

                            if (cog.WebSecurity.UserExists(studentViewModel.UserName))
                            {
                                CourseRegistrationViewModel registration = new CourseRegistrationViewModel() { Course_Id = user.CourseId };

                                ((StudentViewModel)studentViewModel).CourseRegistrations = new List<CourseRegistrationViewModel> { registration };
                                var _user = _userAppService.CreateUser(cog.WebSecurity.GetUserId(studentViewModel.UserName), studentViewModel);
                                if (_user != null)
                                {
                                    // TODO - pick the role from the Roles list availbable on the UserFormPartial view.
                                    _userAppService.AssignRole(_user.Id, Service.C.Roles.Student);
                                    SendRegisterEmail(studentViewModel as StudentViewModel);
                                }
                            }
                        }

                       

                        if(user._roleViewModel=="Teacher")
                        {
                            StaffViewModel staffViewModel = new StaffViewModel()
                            {
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                Email = user.Email,
                                UserName = user.Email,
                                Password = "Password123",
                                UserGender = (int)GenderType.NotSpecified,
                                CompanyId = _currentUser.CompanyId,
                                Position_Id = user.Position,
                                DepartmentId = user.Department
                            };

                           
                            cog.WebSecurity.CreateUserAndAccount(staffViewModel.UserName, staffViewModel.Password);

                            if (cog.WebSecurity.UserExists(staffViewModel.UserName))
                            {
                                CourseRegistrationViewModel registration = new CourseRegistrationViewModel() { Course_Id = user.CourseId };
                            

                                var _user = _userAppService.CreateUser(cog.WebSecurity.GetUserId(staffViewModel.UserName), staffViewModel);
                                if (_user != null)
                                {
                                    // TODO - pick the role from the Roles list availbable on the UserFormPartial view.
                                    _userAppService.AssignRole(_user.Id, Service.C.Roles.Teacher);
                                  // revisit  SendRegisterEmail(staffViewModel as StaffViewModel);
                                }
                            }


                        }


                        
                    }
                    return RedirectToAction("Users");
                }

            }
            catch (MembershipCreateUserException e)
            {
                ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error creating user. Please try again. If the problem persists, please contact your system administrator.");
            }

            //StaffViewModel staff = _staffService.GetStaffByMemberShipId(CurrentUser.Id);
            //ViewData["Pager"] = pageViewFilterModel;
            ViewData["Courses"] = _courseModuleService.GetCoursesByStaff(staff.Id).Select(v => new SelectListItem { Value = v.Id.ToString(), Text = v.Title }).ToArray();
            ViewData["Users"] = _userAppService.GetStudentUsersByCompany(staff.CompanyId, 10);
            return View("Users");
        }

        #endregion
        /// <summary>
        /// Errors the code to string.
        /// </summary>
        /// <param name="createStatus">The create status.</param>
        /// <returns></returns>
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        private void UpdateCourseOrder(List<string> draggedItemId)
        {
            /*********************************
             * Current implementation works perfect with non-pagination results but the logic doesn't support pagination in place. 
             * This makes it more complex to handle the results. 
             *********************************/
            int sort = 0;
            foreach (var courseId in draggedItemId)
            {
                int id = 0;
                if (int.TryParse(courseId, out id))
                {
                    var course = _courseModuleService.GetCourseById(id);
                    course.SortOrder = sort++;
                    _courseModuleService.UpdateCourse(course);
                }
                else
                {
                    throw new InvalidCastException();
                }
            }

            /*
             * This was initially implemented to order the courses accross all staff/teachers.
             * To me the reordering should only be done by Administrators.
             */
            /*var courses = _courseModuleService.GetCoursesWithDepartmentByStaffId(CurrentUser.Id, 0).OrderBy(o => o.SortOrder).Where(c => c.Id != draggedItemId).ToList();
            var currentCourse = new CourseViewModel();
            currentCourse = (from c in _courseModuleService.GetAllCourses()
                             where c.Id == draggedItemId
                             select c).FirstOrDefault();
            if (draggedDown)
                currentCourse.SortOrder += (newIndex);
            else
                currentCourse.SortOrder -= (newIndex);
            courses.Add(currentCourse);
            foreach (var course in courses)
            {
                if (course.SortOrder == currentCourse.SortOrder && course.Id != currentCourse.Id)
                {
                    if (draggedDown)
                        course.SortOrder--;
                    else
                        course.SortOrder++;
                }
            }
            IEnumerable<CourseViewModel> newCoursesList = courses;

            newCoursesList = newCoursesList.OrderBy(o => o.SortOrder);*/
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

        private void UpdateQuestionOrder(List<string> draggedItemId)
        {
            /*********************************
             * Current implementation works perfect with non-pagination results but the logic doesn't support pagination in place. 
             * This makes it more complex to handle the results. 
             *********************************/
            int sort = 0;
            foreach (var questionId in draggedItemId)
            {
                int id = 0;
                if (int.TryParse(questionId, out id))
                {
                    var question = _questionAppService.GetQuestionById(id);
                    question.SortOrder = sort++;
                    _questionAppService.EditQuestion(question);
                }
                else
                {
                    throw new InvalidCastException();
                }
            }
        }

        private void UpdateUnitOrder(List<string> draggedItemId)
        {
            /*********************************
             * Current implementation works perfect with non-pagination results but the logic doesn't support pagination in place. 
             * This makes it more complex to handle the results. 
             *********************************/
            int sort = 0;
            foreach (var unitId in draggedItemId)
            {
                int id = 0;
                if (int.TryParse(unitId, out id))
                {
                    var unit = _unitModuleAppService.GetUnit(id);
                    unit.SortOrder = sort++;
                    _unitModuleAppService.UpdateUnit(unit);
                }
                else
                {
                    throw new InvalidCastException();
                }
            }
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

        private TopicViewModel PrepareTopicViewModel(UnitViewModel unit, int discussionId)
        {
            TopicViewModel topicViewModel = new TopicViewModel();
            topicViewModel.IsTopic = true;
            topicViewModel.OriginatorId = unit.StaffId;
            topicViewModel.Title = unit.Title;
            topicViewModel.Description = unit.Description;
            topicViewModel.DiscussionId = discussionId;

            return topicViewModel;
        }

        protected string SendRegisterEmail(StudentViewModel model)
        {
            string email = model.Email.Trim();
            string url = "http://" + Request.Url.Authority + "/Account/Login";

            StringBuilder sb = new StringBuilder();
            sb.Append("<table><tr><td>Hello " + model.FirstName + " " + model.LastName + ",</td>");
            sb.Append("<br /><br />");
            sb.Append("<tr><td>You can login using below credentials:</td></tr><br />");

            sb.Append("<tr><td>Username: " + model.UserName + "</td></tr><br />");
            sb.Append("<tr><td>Password: " + model.Password + "</td></tr><br />");

            sb.Append("<tr><td><a href='" + url + "'>Click here</a> to Login to UniEBoard system.</td></tr><br />");

            sb.Append("<tr><td>Regards, UniEBoard </td></tr></table>");

            string bodyMessage = sb.ToString();

            var fromEmail = WebSite.Current.EmailSenderEmailAddress;
            var displayName = "";
            var subject = WebSite.Current.SubjectRegister.Replace("UserName", model.UserName);
            var smtpUserName = WebSite.Current.SMTPUserName;
            var smtpPassword = WebSite.Current.SMTPPassword;
            var smtpServer = WebSite.Current.SMTPServer;
            var smtpPort = WebSite.Current.SMTPPort;
            var cc = string.Empty;
            var bcc = string.Empty;
            var sslEnabled = WebSite.Current.SMTPEnableSSL;

            SmtpClient client = UniEBoard.Helpers.Email.EmailHelper.GetSmtpClient(smtpServer, smtpPort, smtpUserName, smtpPassword, sslEnabled);
            MailMessage message = UniEBoard.Helpers.Email.EmailHelper.GetMailMessage(fromEmail, displayName, email, subject, bodyMessage, cc, bcc);
            var emailSent = UniEBoard.Helpers.Email.EmailHelper.SendEmail(client, message);

            if (emailSent)
            {
                return "Email has been sent successfully to your email Id. You can reset your password.";
            }
            else
            {
                return "There was an error during sending email. Please contact the administrator";
            }
        }



        #endregion
        private bool SelectedCourseAlreadyExistsFor(UserViewModel user, int selectedCourse)
        {
            List<CourseViewModel> courses = user.Courses.Where(c => c.Id == selectedCourse).ToList();
            return (courses != null && courses.Count > 0);
        }



        public class OrderViewModel
        {
            public List<string> draggedItemId;
            public string type;
        }

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

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
        // GET: /User/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /User/Edit/5

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
        // GET: /User/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5

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
