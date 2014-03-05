using NUnit.Framework;
using Moq;
using UniEBoard.Model.Interfaces.Repository;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.DomainServices;
using UniEBoard.Model.Entities;
using UniEBoard.Model.Interfaces.DomainService;
using System.Collections.Generic;
using System;
using System.Globalization;

namespace UniEBoard.DomainService.Test
{
    [TestFixture]
    public class TopicPostDomainServiceTests
    {
        private Mock<ITopicPostRepository> _topicPostRepository;
        private Mock<IExceptionManagerAdapter> _exceptionManagerAdapter;
        private Mock<ILoggingServiceAdapter> _loggingServiceAdapter;
        private Mock<ITopicPostDomainService> _topicPostDomainService;

        [SetUp]
        protected void SetUp()
        {
            _topicPostRepository = new Mock<ITopicPostRepository>();
            _exceptionManagerAdapter = new Mock<IExceptionManagerAdapter>();
            _loggingServiceAdapter = new Mock<ILoggingServiceAdapter>();
            _topicPostDomainService = new Mock<ITopicPostDomainService>();
                
                //new TopicPostDomainService(_topicPostRepository.Object, _exceptionManagerAdapter.Object, _loggingServiceAdapter.Object);
        }

        [Test]
        [Category("Constructor")]
        [Category("TopicPostDomainService")]
        public void Constructor_TopicPostDomainService_Pos()
        {
            TopicPostDomainService topicPostService = new TopicPostDomainService(_topicPostRepository.Object, _exceptionManagerAdapter.Object, _loggingServiceAdapter.Object);
            Assert.AreEqual(_topicPostRepository.Object, topicPostService.TopicPostRepository);
            Assert.AreEqual(_exceptionManagerAdapter.Object, topicPostService.ExceptionManager);
            Assert.AreEqual(_loggingServiceAdapter.Object, topicPostService.LoggingService);
        }

        /*[Test]
        [Category("Positive Test")]
        [Category("GetTopicPostsByTopicId")]*/
        public void Verify_If_TopicPosts_Exists_For_Topic_Pos()
        {
            List<TopicPost> topicPostList = new List<TopicPost>();
            topicPostList.Add(new TopicPost()
            {
                Id = 1,
                IP = "192.168.0.1",
                Title = "My Post",
                Status = 1,
                Body = "Body of the post",
                DateCreated = DateTime.ParseExact("2013-04-09", "yyyy-mm-dd", DateTimeFormatInfo.InvariantInfo),
                Votes = 3,
                PostedByUserId = 2, 
                ParentTopicPostId = null,
                TopicId = 3
            });
            TopicPostDomainService topicPostService = new TopicPostDomainService(_topicPostRepository.Object, 
                _exceptionManagerAdapter.Object, _loggingServiceAdapter.Object);
            //_topicPostRepository.Setup(tp => tp.);
            Assert.AreEqual(topicPostList, topicPostService.GetTopicPostsByTopicId(3));
        }

        [Test]
        [Category("GetAllTopicPosts")]
        public void Verify_If_TopicPosts_Exist()
        {
            List<TopicPost> topicPostList = new List<TopicPost>();
            topicPostList.Add(new TopicPost()
            {
                Id = 1,
                Title = "Title"
            });
            int minimumNumberOfTopicPosts = 1;
            _topicPostDomainService.Setup(tp => tp.GetAllTopicPosts()).Returns(topicPostList);
            Assert.GreaterOrEqual(_topicPostDomainService.Object.GetAllTopicPosts().Count, minimumNumberOfTopicPosts);
        }

        [Test]
        [Category("GetTopicPostsByTopic")]
        public void Verify_If_TopicPosts_Exist_GetTopicPostsByTopic()
        {
            List<TopicPost> topicPostList = new List<TopicPost>();
            topicPostList.Add(new TopicPost()
            {
                Id = 1,
                Title = "Title"
            });
            int minimumNumberOfTopicPosts = 1;
            _topicPostDomainService.Setup(tp => tp.GetTopicPostsByTopicId(It.IsAny<int>())).Returns(topicPostList);
            Assert.GreaterOrEqual(_topicPostDomainService.Object.GetTopicPostsByTopicId(1).Count, minimumNumberOfTopicPosts);
        }
    }
}
