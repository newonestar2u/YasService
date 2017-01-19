namespace YasService.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Models.Context;

    public class YasController : ApiController
    {
        // GET: api/Yas
        [Route("Yas"), HttpGet]
        public IEnumerable<string> Get()
        {
            YasContext t = new YasContext();
            
            return new string[] { "value1", "value2" };
        }

        // GET: api/Yas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Yas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Yas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Yas/5
        public void Delete(int id)
        {
        }
    }
}
