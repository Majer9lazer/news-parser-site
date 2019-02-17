using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using NewsParserSite.Core.Interfaces;
using NewsParserSite.DATA.Entities;

namespace NewsParserSite.Core.Implementation
{
    public class Parser : IParser
    {
        public const string SiteUrl = "https://almaty.aqparat.info";
        public const string MainXPathToFeedsBlock = "//div[@class='hfeed']";
        public const string MainXPathToArticlesBlock = "//article[@class='hentry entry xfolkentry gradient']";
        public const string SubXpathToTheme = "/header/h2/a";
        public const string SubXpathToDescription = "/section";
        public const string SubXpathDateOfPublish = "/h3/span/abbr";
        public const string SubXpathTimeOfPublish = "/h3/span/span";
        private readonly INewsRepository _repository;

        public Parser()
        {
            _repository = new SqlNewsRepository();
        }
        public void Run()
        {
            var document = this.GetDocument();
            var news = this.ConvertToNews(document);
            _repository.AddRange(news);
            _repository.Save();
        }

        public List<News> ConvertToNews(HtmlDocument doc)
        {

            var mainBlock = doc.DocumentNode.SelectSingleNode(MainXPathToFeedsBlock);
            var newsBlocks = mainBlock.SelectNodes(MainXPathToArticlesBlock);
            var result = newsBlocks.Select(s => new News()
            {
                Theme = s.SelectSingleNode(s.XPath + SubXpathToTheme).InnerText,
                Description = s.SelectSingleNode(s.XPath + SubXpathToDescription).InnerText,
                DateOfPublish = DateTime.Parse(s.SelectSingleNode(s.XPath + SubXpathDateOfPublish).Attributes["title"].Value
                                               + " " + s.SelectSingleNode(s.XPath + SubXpathTimeOfPublish).InnerText)
            }).ToList();
            return result;
        }

        public HtmlDocument GetDocument()
        {
            HtmlWeb web = new HtmlWeb();
            return web.Load(SiteUrl);
        }

    }
}
