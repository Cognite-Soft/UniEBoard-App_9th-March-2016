using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using UniEBoard.Model.Interfaces.Repository;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.Interfaces.DomainService;
using UniEBoard.Model.DomainServices;
using UniEBoard.Model.Entities;
using UniEBoard.Service.ApplicationServices;
using UniEBoard.Service.Interfaces.ApplicationService;
using UniEBoard.Service.Models;

namespace UniEBoard.AppService.Test
{
    [TestFixture]
    public class DiscussionAppServiceTests
    {
        private Mock<IDiscussionDomainService> _discussionDomainService;
        private Mock<ITopicDomainService> _topicService;
        private Mock<ITopicPostDomainService> _postService;
        private Mock<IObjectMapperAdapter> _objectMapperAdapter;
        private Mock<ICacheAdapter> _cacheServiceAdapter;
        private Mock<IExceptionManagerAdapter> _exceptionManagerAdapter;
        private Mock<ILoggingServiceAdapter> _loggingServiceAdapter;
        private Mock<IDiscussionAppService> _discussionAppService;

        [SetUp]
        protected void SetUp()
        {
            _discussionDomainService = new Mock<IDiscussionDomainService>();
            _topicService = new Mock<ITopicDomainService>();
            _postService = new Mock<ITopicPostDomainService>();
            _objectMapperAdapter = new Mock<IObjectMapperAdapter>();
            _cacheServiceAdapter = new Mock<ICacheAdapter>();
            _exceptionManagerAdapter = new Mock<IExceptionManagerAdapter>();
            _loggingServiceAdapter = new Mock<ILoggingServiceAdapter>();
            _discussionAppService = new Mock<IDiscussionAppService>();
        }

        [Test]
        [Category("Constructor")]
        [Category("DiscussionAppService")]
        public void Constructor_DiscussionAppService_Pos()
        {
            /*DiscussionAppService discussionAppService = new DiscussionAppService(_objectMapperAdapter.Object, _cacheServiceAdapter.Object, _exceptionManagerAdapter.Object, _loggingServiceAdapter.Object, _discussionDomainService.Object, _topicService.Object, _postService.Object);
            Assert.AreEqual(_discussionDomainService.Object, discussionAppService.DiscussionManager);
            Assert.AreEqual(_topicService.Object, discussionAppService.TopicManager);
            Assert.AreEqual(_postService.Object, discussionAppService.PostManager);
            Assert.AreEqual(_exceptionManagerAdapter.Object, discussionAppService.ExceptionManager);
            Assert.AreEqual(_loggingServiceAdapter.Object, discussionAppService.LoggingService);
            Assert.AreEqual(_cacheServiceAdapter.Object, discussionAppService.CacheService);
            Assert.AreEqual(_objectMapperAdapter.Object, discussionAppService.ObjectMapper);*/
        }

        [Test]
        [Category("GetAllTopicPosts")]
        public void Verify_Get_All_TopicPosts()
        {
            List<TopicPostViewModel> topicPostList = new List<TopicPostViewModel>();
            topicPostList.Add(new TopicPostViewModel()
            {
                Id = 1,
                Title = "Title"
            });
            int minimumNumberOfTopicPosts = 1;
            _discussionAppService.Setup(da => da.GetAllTopicPosts()).Returns(topicPostList);
            Assert.GreaterOrEqual(_discussionAppService.Object.GetAllTopicPosts().Count, minimumNumberOfTopicPosts);
        }

        [Test]
        [Category("GetTopicPostsByTopic")]
        public void Verify_If_TopicPosts_Exist_GetTopicPostsByTopic()
        {
            List<TopicPostViewModel> topicPostList = new List<TopicPostViewModel>();
            topicPostList.Add(new TopicPostViewModel()
            {
                Id = 1,
                Title = "Title"
            });
            int minimumNumberOfTopicPosts = 1;
            _discussionAppService.Setup(da => da.GetTopicPostsByTopic(It.IsAny<int>())).Returns(topicPostList);
            Assert.GreaterOrEqual(_discussionAppService.Object.GetTopicPostsByTopic(1).Count, minimumNumberOfTopicPosts);
        }

        [Test]
        [Category("AddTopicPost")]
        public void Verify_Add_TopicPost()
        {
            
        }

        [Test]
        [Category("AddNewTopicPost")]
        public void Verify_AddNewTopicPost()
        {
            string title = "Title of the post", body = "Body of the post";
            int topicId = 3, newTopicPostId = 1, currentUserId = 2;

            _discussionAppService.Setup(da => da.AddNewTopicPost(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(newTopicPostId);
            Assert.AreNotEqual(_discussionAppService.Object.AddNewTopicPost(title, body, topicId, currentUserId), 0);
        }

        [Test]
        [Category("AddNewTopicPost")]
        public void Verify_AddTopicPostReply()
        {
            string title = "Title of the post", body = "Body of the post";
            int topicId = 3, topicPostId = 0, newTopicPostId = 1, currentUserId = 2;

            _discussionAppService.Setup(da => da.AddTopicPostReply(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(newTopicPostId);
            Assert.AreNotEqual(_discussionAppService.Object.AddTopicPostReply(topicPostId, title, body, topicId, currentUserId), 0);
        }

    }
}
