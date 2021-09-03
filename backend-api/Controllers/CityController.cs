using Microsoft.AspNetCore.Mvc;
using backend_api.Models; // Para cuando hagamos el Post mas adelante
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        //constructor
        public CityController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<CityController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listCities = await _context.Cities.ToListAsync();   
                return Ok(listCities);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var city= await _context.Cities.FindAsync(id);

                if(city == null)
                {
                    return NotFound(new { message = "The Id of City not exist!" });
                }

                return Ok(city);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CityController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] City city)
        {
            try
            {
                _context.Add(city);
                await _context.SaveChangesAsync();
                return Ok(new { message = "The city was created successfully!", city });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] City city)
        {
            try
            {
                if(id != city.Id)
                {
                    return NotFound(new { message = "The Id city" + id + " not exists" });
                }

                _context.Update(city);
                await _context.SaveChangesAsync();
                return Ok(new { message = "The city was updated successfully!" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // finding city by id
                var city = await _context.Cities.FindAsync(id);

                if(city == null)
                {
                    return NotFound(new { message = "The Id city" + id + " not exists" });
                }

                _context.Cities.Remove(city);
                await _context.SaveChangesAsync();
                return Ok(new { message = "The city was deleted successfuly" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
