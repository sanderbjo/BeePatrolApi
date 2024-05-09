using beefamily.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace beefamily.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Hives2Controller : ControllerBase
    {
        // GET: api/<HivesController>
        [HttpGet]
        public IEnumerable<Hive> Get()
        {

            Hive hive1 = new Hive();
            Hive hive2 = new Hive();

            List<Hive> hives = new List<Hive>();
            hives.Add(hive1);
            hives.Add(hive2);

            return hives;
 
        }

        // GET api/<HivesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HivesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HivesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HivesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
