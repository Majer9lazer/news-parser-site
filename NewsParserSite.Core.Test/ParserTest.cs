using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml.XPath;
using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsParserSite.Core.Interfaces;
using NewsParserSite.DATA.Entities;

namespace NewsParserSite.Core.Test
{
    [TestClass]
    public class ParserTest
    {
        private IParser _parser;
        [TestInitialize]
        public void InitParser()
        {
            _parser = new Parser();
        }
        [TestMethod]
        public void GetDocumentTest()
        {

            var doc = _parser.GetDocument();
            var mainBlock = doc.DocumentNode.SelectSingleNode("//div[@class='hfeed']");
            var newsBlocks = mainBlock.SelectNodes("//article[@class='hentry entry xfolkentry gradient']");
            var test = newsBlocks.Select(s => new News()
            {
                Theme = s.SelectSingleNode(s.XPath + "/header/h2/a").InnerText,
                Description = s.SelectSingleNode(s.XPath + "/section").InnerText,
                DateOfPublish = DateTime.Parse(s.SelectSingleNode(s.XPath + "/h3/span/abbr").Attributes["title"].Value
                + " " + s.SelectSingleNode(s.XPath + "/h3/span/span").InnerText)
            }).ToList();
            Assert.IsNotNull(test);
            Assert.IsTrue(test.Count > 2);
        }
    }

}
