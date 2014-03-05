using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using Moq;
using UniEBoard;
using UniEBoard.Controllers;
using UniEBoard.Service.Interfaces.ApplicationService;
using UniEBoard.Service.Models;

namespace UniEBoard.Controller.Test
{
    [TestFixture]
    public class AdminControllerTests
    {
        private Mock<IStudentAppService> _studentService;
        private Mock<IStaffAppService> _staffService;

        [SetUp]
        protected void Setup()
        {
            _studentService = new Mock<IStudentAppService>();
            _staffService = new Mock<IStaffAppService>();
        }

        /// <summary>
        /// Should_returns the all students.
        /// </summary>
        [Test]
        [Category("Positive Tests")]
        [Category("AdminController")]
        public void Should_return_All_Students()
        {
            // Given
            var models = new List<StudentViewModel> {new StudentViewModel() {Id = 1, FirstName = "Administrator"}};
            _studentService.Setup(ss => ss.GetAllStudents()).Returns(models);

            // When
            var controller = new AdminController(_staffService.Object,_studentService.Object);
            var result = (ViewResult)controller.Students();

            // Check
            Assert.That(result.Model, Is.EqualTo(models));
        }

        [Test]
        [Category("Positive Tests")]
        [Category("AdminController")]
        public void Should_return_specified_student_by_id()
        {
            // Given
            int studentId = 23;
            var model = new StudentViewModel() { Id = studentId, FirstName = "Chico" };
            _studentService.Setup(ss => ss.GetStudentByMemberShipId(It.IsAny<int>())).Returns(model);

            // When
            var controller = new AdminController(_staffService.Object, _studentService.Object);
            var result = (ViewResult)controller.Student(studentId);

            // Check
            Assert.That(result.Model, Is.EqualTo(model));
            _studentService.Verify(ss => ss.GetStudentByMemberShipId(studentId));
        }
    }
}
