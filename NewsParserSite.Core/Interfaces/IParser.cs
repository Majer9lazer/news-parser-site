using System.Collections.Generic;
using HtmlAgilityPack;
using NewsParserSite.DATA.Entities;

namespace NewsParserSite.Core.Interfaces
{
    public interface IParser
    {
        void Run();
        void BulkInsertRange(int to);
        void BulkInsertRange(int from, int to);
        HtmlDocument GetDocument();
        HtmlDocument GetDocumentByUrl(string url);
        List<News> ConvertToNews(HtmlDocument doc);
        List<News> ParsePagesToNews(int to);
        List<News> ParsePagesToNews(int from, int to);
    }
}