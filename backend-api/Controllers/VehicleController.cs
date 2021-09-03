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
    public class VehicleController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        // constructor
        public VehicleController(AplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: api/<VehicleController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listVehicles = await _context.Vehicles.ToListAsync();
                return Ok(listVehicles);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<VehicleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var Vehicle = await _context.Vehicles.FindAsync(id);

                if(Vehicle == null)
                {
                    return NotFound(new { message = "The Id of Vehicle not exists!" });
                }

                return Ok(Vehicle);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<VehicleController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Vehicle vehicle)
        {
            try
            {
                // checking if licensePlate exist
                var result = _context.Vehicles.FromSqlRaw($"SELECT * From Vehicles Where LicensePlate = '{vehicle.LicensePlate}'").FirstOrDefault();
                       
                if(result != null)
                {
                    return BadRequest(new { message = "The LicensePlate from vehicle was taken" });
                }

                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return Ok(new { message = "The vehicle was created successfully", vehicle });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<VehicleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Vehicle vehicle)
        {
            try
            {
                if (id != vehicle.Id)
                {
                    return NotFound(new { message = "The id vehicle " + id + "not exists" });
                }

                _context.Update(vehicle);
                await _context.SaveChangesAsync();
                return Ok(new { message = "The vehicle was updated successfuly!" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var vehicle = await _context.Vehicles.FindAsync(id);
                
                if(vehicle == null)
                {
                    return NotFound(new { message = "The Id vehicle" + id + " not exists" });
                }

                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
                return Ok(new { message = "The vehicle was deleted successfuly" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
