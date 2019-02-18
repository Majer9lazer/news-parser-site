using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NewsParserSite.Core.Interfaces;
using NewsParserSite.DATA.Entities;

namespace NewsParserSite.Core.Implementation
{
    public class Parser : IParser
    {
        public static string SiteUrl = "https://almaty.aqparat.info";
        private static string SubCityUrl = "/city/36870-almaty/page-";
        private static int StartPage = 2;
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

        public List<News> ParsePagesToNews(int to)
        {

            var bag = new ConcurrentBag<List<News>>();
            var result = new ConcurrentBag<News>();
            Parallel.For(StartPage, to, (i) =>
            {
                string url = SiteUrl + SubCityUrl + i + ".html";
                var doc = this.GetDocumentByUrl(url);

                var res = new ConcurrentBag<News>(this.ConvertToNews(doc));
                Parallel.ForEach(res, (item) =>
                {
                    result.Add(item);
                });
            });

            return result.ToList();

        }

        public HtmlDocument GetDocumentByUrl(string url)
        {
            HtmlWeb web = new HtmlWeb();
            return web.Load(url);
        }

        public void BulkInsertRange(int to)
        {
            _repository.AddRange(ParsePagesToNews(to));
            _repository.Save();
        }

        public List<News> ParsePagesToNews(int @from, int to)
        {
            var bag = new ConcurrentBag<List<News>>();
            var result = new ConcurrentBag<News>();
            Parallel.For(from, to, (i) =>
            {
                string url = SiteUrl + SubCityUrl + i + ".html";
                var doc = this.GetDocumentByUrl(url);

                var res = new ConcurrentBag<News>(this.ConvertToNews(doc));
                Parallel.ForEach(res, (item) =>
                {
                    result.Add(item);
                });
            });

            return result.ToList();
        }

        public void BulkInsertRange(int @from, int to)
        {
            _repository.AddRange(ParsePagesToNews(from, to));
            _repository.Save();
        }
    }
}
