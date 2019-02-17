using System;
using NewsParserSite.Core.Implementation;
using NewsParserSite.Core.Interfaces;

namespace NewsParserSite.ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            INewsRepository repo = new SqlNewsRepository();
            var data = repo.GetTopTenWordsInNews();

            Console.Read();
        }
    }
}
