using System.Collections.Generic;
using HtmlAgilityPack;
using NewsParserSite.DATA.Entities;

namespace NewsParserSite.Core.Interfaces
{
    public interface IParser
    {
        void Run();
        List<News> ConvertToNews(HtmlDocument doc);
        HtmlDocument GetDocument();
        List<News> ParsePagesToNews(int to);
        HtmlDocument GetDocumentByUrl(string url);
        void BulkInsertRange(int to);
        List<News> ParsePagesToNews(int from, int to);
        void BulkInsertRange(int from, int to);
    }
}