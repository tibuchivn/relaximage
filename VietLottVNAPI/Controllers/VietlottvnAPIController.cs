using System.Collections.Generic;
using System.Web.Http;
using VietLottVNAPI.Services;

namespace VietLottVNAPI.Controllers
{
    public class VietlottvnAPIController : ApiController
    {

        // GET: api/VietlottvnAPI
        public IEnumerable<string> Get()
        {
            var objService = new VietlottvnService();
            var lst = objService.GetAllAppearance001();

            return new string[] { "value1", "value2" };
        }

        // GET: api/VietlottvnAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/VietlottvnAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/VietlottvnAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/VietlottvnAPI/5
        public void Delete(int id)
        {
        }
    }
}
