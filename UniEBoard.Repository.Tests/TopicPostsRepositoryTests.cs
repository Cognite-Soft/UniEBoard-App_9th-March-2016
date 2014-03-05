using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit;
using NUnit.Framework;
using Moq;
using UniEBoard.Model.Interfaces.Repository;
using mod = UniEBoard.Model.Entities;

namespace UniEBoard.Repository.Tests
{
    [TestFixture]
    public class TopicPostsRepositoryTests
    {
        Mock<ITopicPostRepository> _topicPostRepository;

        [SetUp]
        protected void Setup()
        {
            _topicPostRepository = new Mock<ITopicPostRepository>();
        }

        [Test]
        [Category("GetAllTopicPosts")]
        public void Verify_If_TopicPosts_Exist()
        {
            List<mod.TopicPost> topicPostList = new List<mod.TopicPost>();
            topicPostList.Add(new mod.TopicPost()
            {
                Id = 1,
                Title = "Title"
            });
            int minimumNumberOfTopicPosts = 1;
            _topicPostRepository.Setup(tp => tp.GetAllTopicPosts()).Returns(topicPostList);
            Assert.GreaterOrEqual(_topicPostRepository.Object.GetAllTopicPosts().Count, minimumNumberOfTopicPosts);
        }

        [Test]
        [Category("GetTopicPostsByTopicId")]
        public void Verify_If_TopicPosts_Exist_GetTopicPostsByTopic()
        {
            List<mod.TopicPost> topicPostList = new List<mod.TopicPost>();
            topicPostList.Add(new mod.TopicPost()
            {
                Id = 1,
                Title = "Title"
            });
            int minimumNumberOfTopicPosts = 1;
            _topicPostRepository.Setup(tp => tp.GetTopicPostsByTopicId(It.IsAny<int>())).Returns(topicPostList);
            Assert.GreaterOrEqual(_topicPostRepository.Object.GetTopicPostsByTopicId(1).Count, minimumNumberOfTopicPosts);
        }
        
    }
}
