using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NewsParserSite.Core.Interfaces;
using NewsParserSite.DATA.Entities;

namespace NewsParserSite.Core.Implementation
{
    public class SqlNewsRepository : INewsRepository
    {
        private readonly ParserSiteDb _db;
        private bool _disposed = false;

        public SqlNewsRepository()
        {
            _db = new ParserSiteDb();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }

            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public List<News> GetAll()
        {
            return _db.News.ToList();
        }

        public News GetEntityById(int id)
        {
            return _db.News.Find(id);
        }

        public void Add(News entity)
        {
            _db.News.Add(entity);
        }

        public void Update(News entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(int id)
        {
            News findElement = _db.News.Find(id);
            if (findElement != null)
                _db.News.Remove(findElement);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public List<News> GetNewsByDateRange(DateTime @from, DateTime to)
        {
            return _db.News.Where(w => w.DateOfPublish >= from && w.DateOfPublish <= to).ToList();
        }

        public Dictionary<string, string> GetTopTenWordsInNews()
        {
            StringBuilder builder = new StringBuilder();
            var result2 = GetAll().Select(s => s.Description).ToList();
            foreach (string s in result2)
                builder.AppendLine(s);

            string bigText = builder.ToString();

            // сначала разбиваем на слова по пробелам
            // делаем фильтрацию чтобы исключить предлоги, союзы и т.д.
            // сортируем по убыванию
            // берем первые 10 записей 
            // превращаем в Dictionary чтобы выглядело как - "привет - 3"

            var result = bigText.Split(' ')
                .Where(w => w.Length > 2&& !Regex.IsMatch(w, "[\r\n|\r|\n]"))
                .GroupBy(g => g)
                .OrderByDescending(d => d.Count())
                .Take(10)
                .ToDictionary(d => d.Key, c => c.Count().ToString());

            return result;
        }

        public List<News> SearchByText(string text)
        {
            return _db.News.Where(w => w.Description.Contains(text)).ToList();
        }

        public void AddRange(List<News> list)
        {
            _db.News.AddRange(list);
        }
    }
}