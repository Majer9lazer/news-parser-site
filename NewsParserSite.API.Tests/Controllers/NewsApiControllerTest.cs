using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsParserSite.API.Controllers;
using NewsParserSite.Core.Implementation;
using NewsParserSite.Core.Interfaces;

namespace NewsParserSite.API.Tests.Controllers
{
    [TestClass]
    public class NewsApiControllerTest
    {
        private  NewsApiController _controller;
        private  INewsRepository _repository;
        [TestInitialize]
        public void Setup()
        {
            //_repository = new SqlNewsRepository();
            //_controller = new NewsApiController(_repository);
        }
        [TestMethod]
        public void GetTopTenPopularWordsTest()
        {

        }
    }
}
