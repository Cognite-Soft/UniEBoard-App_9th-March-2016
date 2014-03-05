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
    public class TopicDomainServiceTests
    {
        private Mock<ITopicRepository> _topicRepository;
        private Mock<IExceptionManagerAdapter> _exceptionManagerAdapter;
        private Mock<ILoggingServiceAdapter> _loggingServiceAdapter;

        [SetUp]
        protected void SetUp()
        {
            _topicRepository = new Mock<ITopicRepository>();
            _exceptionManagerAdapter = new Mock<IExceptionManagerAdapter>();
            _loggingServiceAdapter = new Mock<ILoggingServiceAdapter>();
        }

        [Test]
        [Category("Constructor")]
        [Category("TopicDomainService")]
        public void Constructor_TopicDomainService_Pos()
        {
            TopicDomainService topicService = new TopicDomainService(_topicRepository.Object, _exceptionManagerAdapter.Object, _loggingServiceAdapter.Object);
            Assert.AreEqual(_topicRepository.Object, topicService.TopicRepository);
            Assert.AreEqual(_exceptionManagerAdapter.Object, topicService.ExceptionManager);
            Assert.AreEqual(_loggingServiceAdapter.Object, topicService.LoggingService);
        }
    }
}
