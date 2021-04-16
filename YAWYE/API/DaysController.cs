using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YAWYE.Core;
using YAWYE.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YAWYE.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysController : ControllerBase
    {
        private readonly IDayData dayData;

        public DaysController(IDayData dayData)
        {
            this.dayData = dayData;
        }
        public DayDTO DayDTO { get; set; }
        public Day Day { get; set; }

        [HttpGet]
        public ActionResult<DayDTO> GetToday()
        {
            Day = dayData.GetByDate(DateTime.Now.Date, User.Identity.Name);
            Day ??= new Day();

            return Ok(ApiRepository.DayToDto(Day));
        }


        [HttpGet("{date}")]
        ///Time not needed, can be 0 
        public ActionResult<DayDTO> GetBySpecificDate(string datePicked)
        {
            Day = dayData.GetByDate(DateTime.Parse(datePicked).Date, User.Identity.Name);
            return Ok(ApiRepository.DayToDto(Day));
        }


        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DaysController>/5
        [HttpPatch("{id}")]
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
