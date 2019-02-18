using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NewsParserSite.DATA.Entities;

namespace NewsParserSite.Core.Interfaces
{
    public interface INewsRepository : IRepository<News>
    {
        List<News> GetNewsByDateRange(DateTime from, DateTime to);

        Dictionary<string, string> GetTopTenWordsInNews();
        List<News> SearchByText(string name);
        void AddRange(List<News> list);
    }
}   
