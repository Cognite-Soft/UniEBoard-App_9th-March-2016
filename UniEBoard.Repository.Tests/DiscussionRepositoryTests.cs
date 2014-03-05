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
    public class DiscussionRepositoryTests
    {
        Mock<IDiscussionRepository> _discussionRepository;

        [SetUp]
        protected void Setup()
        {
            _discussionRepository = new Mock<IDiscussionRepository>();
        }

        public void Test_FindDiscussionByTopicId()
        {
        }
    }
}
