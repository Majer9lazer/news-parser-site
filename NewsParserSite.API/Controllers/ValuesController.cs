using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NewsParserSite.Core.Implementation;
using NewsParserSite.Core.Interfaces;
using NewsParserSite.DATA.Entities;
using Newtonsoft.Json;

namespace NewsParserSite.API.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly INewsRepository _repo;

        public ValuesController()
        {
            _repo = new SqlNewsRepository();
        }
        // GET api/values
        public List<News> Get()
        {
            var data = _repo.GetAll();
            return data;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }
        [HttpPost]
        [Route("api/values/getinputparameter")]
        public string GetInputParamter(string val)
        {
            return string.Format("input value = {0}",val);
        }
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
