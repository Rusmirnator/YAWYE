using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YAWYE.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysController : ControllerBase
    {
        // GET: api/<DaysController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DaysController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DaysController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DaysController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DaysController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
