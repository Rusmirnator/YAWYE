using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YAWYE.Core;
using YAWYE.Core.DTOs;
using YAWYE.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YAWYE.API
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController] //Note: tries to bind so that [FromBody] is not needed to be passed to action
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
        public IActionResult GetToday()
        {
            try
            {
                Day = dayData.GetByDate(DateTime.Now.Date, User.Identity.Name);

                return Ok(ApiRepository.DayToDto(Day));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }


        [HttpGet("{date}")]
        ///Time not needed, can be 0 
        public IActionResult GetBySpecificDate(string datePicked)
        {
            try
            {
                Day = dayData.GetByDate(DateTime.Parse(datePicked).Date, User.Identity.Name);

                if (Day == null)
                {
                    return NotFound();
                }

                return Ok(ApiRepository.DayToDto(Day));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Day = dayData.GetById(id);

                if (Day == null)
                {
                    return NotFound();
                }

                return Ok(ApiRepository.DayToDto(Day));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }


        [HttpPost]
        public IActionResult Post(DayDTO dto)
        {
            try
            {
                Day = ApiRepository.DtoToDay(dto);

                var dayExists = dayData.GetByDate(DateTime.Now.Date, User.Identity.Name);

                if(dayExists != null)
                {
                    return BadRequest("Day already exists!");
                }

                dayData.Add(Day);

                if (dayData.Commit() > 0)
                {
                    return CreatedAtAction("GetById", new { id = Day.DayId }, Day);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();

        }

        // PUT api/<DaysController>/5
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, DayDTO dto)
        {
            try
            {
                Day = dayData.GetById(id);
                if(Day == null)
                {
                    return NotFound($"Could not find day with id:{id}");
                }

                ApiRepository.DtoToDay(dto, Day);
                dayData.Update(Day);

                if(dayData.Commit() > 0)
                {
                    return Ok("Updated!");
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return BadRequest();
        }

        // DELETE api/<DaysController>/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Day = dayData.GetById(id);

                if(Day == null)
                {
                    return NotFound($"Could not find day with id:{id}");
                }

                dayData.Delete(id);

                if(dayData.Commit() > 0)
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest("Failed to delete day");
        }
    }
}
