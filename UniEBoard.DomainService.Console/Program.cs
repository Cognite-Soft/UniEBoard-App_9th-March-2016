using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;

using UniEBoard.Model.Interfaces.Repository;
using UniEBoard.Model.Interfaces.Adapter;
using UniEBoard.Model.DomainServices;
using UniEBoard.Model.Entities;
using System.Globalization;


namespace UniEBoard.DomainService.Console
{
    class Program
    {
        private static Mock<ITopicPostRepository> _topicPostRepository;
        private static Mock<IExceptionManagerAdapter> _exceptionManagerAdapter;
        private static Mock<ILoggingServiceAdapter> _loggingServiceAdapter;
        
        static void Main(string[] args)
        {
            TopicPostDomainService topicPostService = new TopicPostDomainService(_topicPostRepository.Object,
                _exceptionManagerAdapter.Object, _loggingServiceAdapter.Object);
            List<TopicPost> posts = topicPostService.GetTopicPostsByTopicId(3);
            System.Console.ReadLine();
        }
    }
}
