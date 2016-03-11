using System;
using System.Collections.Generic;
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
    public class DiscussionDomainServiceTests
    {
        private Mock<IDiscussionRepository> _discussionRepository;
        private Mock<IExceptionManagerAdapter> _exceptionManagerAdapter;
        private Mock<ILoggingServiceAdapter> _loggingServiceAdapter;

        [SetUp]
        protected void SetUp()
        {
            _discussionRepository = new Mock<IDiscussionRepository>();
            _exceptionManagerAdapter = new Mock<IExceptionManagerAdapter>();
            _loggingServiceAdapter = new Mock<ILoggingServiceAdapter>();
        }

        [Test]
        [Category("Constructor")]
        [Category("DiscussionDomainService")]
        public void Constructor_DiscussionDomainService_Pos()
        {
            DiscussionDomainService discussionService = new DiscussionDomainService(_discussionRepository.Object, _exceptionManagerAdapter.Object, _loggingServiceAdapter.Object);
            Assert.AreEqual(_discussionRepository.Object, discussionService.DiscussionRepository);
            Assert.AreEqual(_exceptionManagerAdapter.Object, discussionService.ExceptionManager);
            Assert.AreEqual(_loggingServiceAdapter.Object, discussionService.LoggingService);
        }
    }
}
