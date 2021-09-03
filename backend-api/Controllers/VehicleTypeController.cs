using backend_api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypeController : ControllerBase
    {

        private readonly AplicationDbContext _context;

        // constructor

        public VehicleTypeController(AplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: api/<VehicleTypeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<VehicleTypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VehicleTypeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VehicleType vehicleType)
        {
            try
            {
                _context.Add(vehicleType);
                await _context.SaveChangesAsync();
                return Ok(new { message = "The Type of vehicle was created", vehicleType });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<VehicleTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VehicleTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
