using backend_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        // constructor
        public TravelController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<TravelController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var ListTravel = (from travel in _context.Travels
                                  join city in _context.Cities
                                  on travel.CityId equals city.Id
                                  join vehicleType in _context.VehicleTypes
                                  on travel.VehicleId equals vehicleType.Id
                                  join countryCode in _context.CountryCode
                                  on city.CountryId equals countryCode.CountryId
                                  select (new
                                  {
                                      TravelId = travel.Id,
                                      City = city.Name,
                                      CountryCode = countryCode.Code,
                                      VehicleType = vehicleType.Type,
                                      Date = travel.Date,
                                      State = travel.State
                                  })
                    ).ToList();

                return Ok(ListTravel);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<TravelController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TravelController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Travel travel)
        {
            try
            {
                _context.Add(travel);
                await _context.SaveChangesAsync();
                return Ok(new { message = "The travel was created successfully!", travel });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TravelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<TravelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
