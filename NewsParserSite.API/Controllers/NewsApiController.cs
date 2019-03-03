using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NewsParserSite.Core.Implementation;
using NewsParserSite.Core.Interfaces;
using NewsParserSite.DATA.Entities;

namespace NewsParserSite.API.Controllers
{
    [Authorize]
    public class NewsApiController : ApiController
    {

        private readonly INewsRepository _repository;

        public NewsApiController() : this(new SqlNewsRepository())
        {

        }

        public NewsApiController(INewsRepository repository)
        {
            _repository = repository;
        }

        // GET api/<controller>
        [HttpGet]
        [Route("api/news/all")]
        public IEnumerable<News> Get()
        {
            return _repository.GetAll();
        }

        // POST api/<controller>
        public void Post([FromBody] News value)
        {
            _repository.Add(value);
            _repository.Save();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] News newValue)
        {
            var elem = _repository.GetEntityById(id);
            elem.DateOfPublish = newValue.DateOfPublish;
            elem.Description = newValue.Description;
            elem.Theme = newValue.Theme;
            _repository.Update(elem);
            _repository.Save();
        }
        /// <summary>
        /// Получение 10 самых используемых слов в новостях
        /// доступно по адресу : "api/news/topten"
        /// </summary>
        /// <returns></returns>
        // api/news/topten
        [HttpGet]
        [Route("api/news/topten")]
        public Dictionary<string, string> GetTopTenPopularWords()
        {
            return _repository.GetTopTenWordsInNews();
        }

        // api/news/posts?from=&to
        [HttpPost]
        [Route("api/news/posts")]
        public IEnumerable<News> GetPostByDateRange(string from, string to)
        {
            return _repository.GetNewsByDateRange(DateTime.ParseExact(from, "yyyy-dd-MM", DateTimeFormatInfo.CurrentInfo), DateTime.ParseExact(to, "yyyy-dd-MM", DateTimeFormatInfo.CurrentInfo));
        }
        [HttpPost]
        [Route("api/news/search")]
        public List<News> GetPostsBySearchText(string text)
        {
            return _repository.SearchByText(text);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _repository.Remove(id);
            _repository.Save();
        }
    }
}