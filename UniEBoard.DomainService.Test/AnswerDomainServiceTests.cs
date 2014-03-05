using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using UniEBoard.Model.Interfaces.Repository;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Model.DomainServices;
using UniEBoard.Model.Entities;

namespace UniEBoard.DomainService.Test
{
    [TestFixture]
    public class AnswerDomainServiceTests
    {
        private Mock<IAnswerRepository> answerRepository;
        private Mock<IExceptionManagerAdapter> exceptionManagerAdapter;
        private Mock<ILoggingServiceAdapter> loggingServiceAdapter;

        [SetUp]
        protected void SetUp()
        {
            System.Diagnostics.Debugger.Launch();
            answerRepository = new Mock<IAnswerRepository>();
            exceptionManagerAdapter = new Mock<IExceptionManagerAdapter>();
            loggingServiceAdapter = new Mock<ILoggingServiceAdapter>();
        }

        [Test]
        [Category("Constructor")]
        [Category("AnswerDomainService")]
        public void Constructor_AnswerDomainService_Pos()
        {
            AnswerDomainService answerService = new AnswerDomainService(answerRepository.Object, exceptionManagerAdapter.Object, loggingServiceAdapter.Object);
            Assert.AreEqual(answerRepository.Object, answerService.AnswerRepository);
            Assert.AreEqual(exceptionManagerAdapter.Object, answerService.ExceptionManager);
            Assert.AreEqual(loggingServiceAdapter.Object, answerService.LoggingService);
        }

        [Test]
        [Category("Positive Tests")]
        [Category("GetAnswersByQuizEntryId")]
        public void Verify_If_QuizEntry_Exists_GetAnswersByQuizEntryId_Pos()
        {
            List<Answer> answerList = new List<Answer>();
            answerList.Add(new Answer(){Id = 2, QuizEntryId = 1});
            answerRepository.Setup(ar => ar.GetAnswerByQuizEntryId(It.IsAny<int>())).Returns(answerList);
            AnswerDomainService answerService = new AnswerDomainService(answerRepository.Object, exceptionManagerAdapter.Object, loggingServiceAdapter.Object);
            Assert.AreEqual(answerList, answerService.GetAnswersByQuizEntryId(1));
        }

        [Test]
        [Category("Negative Tests")]
        [Category("GetAnswersByQuizEntryId")]
        public void Verify_If_Quiz_Entry_Does_Not_Exist_GetAnswersByQuizEntryId_Neg()
        {
            List<Answer> answerList = new List<Answer>();
            answerRepository.Setup(ar => ar.GetAnswerByQuizEntryId(It.IsAny<int>())).Returns(answerList);
            IAnswerDomainService answerService = new AnswerDomainService(answerRepository.Object, exceptionManagerAdapter.Object, loggingServiceAdapter.Object);
            Assert.AreEqual(answerList, answerService.GetAnswersByQuizEntryId(1));
            answerRepository.Verify(ar => ar.GetAnswerByQuizEntryId(1));
        }

        [Test]
        [Category("Negative Tests")]
        [Category("GetAnswersByQuizEntryId")]
        public void Verify_If_Quiz_Repository_Errors_GetAnswersByQuizEntryId_Neg()
        {
            List<Answer> answerList = new List<Answer>();
            answerRepository.Setup(ar => ar.GetAnswerByQuizEntryId(It.IsAny<int>())).Throws(new Exception());
            IAnswerDomainService answerService = new AnswerDomainService(answerRepository.Object, exceptionManagerAdapter.Object, loggingServiceAdapter.Object);
            Assert.AreEqual(answerList, answerService.GetAnswersByQuizEntryId(1));
            answerRepository.Verify(ar => ar.GetAnswerByQuizEntryId(1));
        }
    }
}
