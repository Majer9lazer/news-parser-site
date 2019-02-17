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
    }
}