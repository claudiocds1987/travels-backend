using Microsoft.AspNetCore.Mvc;
using backend_api.Models; // Para cuando hagamos el Post mas adelante
using Microsoft.EntityFrameworkCore; // importar arriba de todo para que reconozca el método ToListAsync()
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        private readonly AplicationDbContext _context;
        // constructor
        public CountryController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<CountryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ListCountries = await _context.Countries.ToListAsync();
                return Ok(ListCountries);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var country = await _context.Countries.FindAsync(id);

                if(country == null)
                {
                    return NotFound(new { message = "El ID de Country no existe!"});
                }

                return Ok(country);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<CountryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Country country)
        {
            try
            {
                _context.Add(country);
                await _context.SaveChangesAsync();
                return Ok(new { message = "The Country was saved successfully", country });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Country country)
        {
            try
            {
                if(id != country.Id)
                {
                    return NotFound(new { message = "The Id country " + id + " not exists" });
                }

                _context.Update(country);
                await _context.SaveChangesAsync();
                return Ok(new { message = "The country was updated successfuly!" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // finding country by id
                var country = await _context.Countries.FindAsync(id);

                if(country == null)
                {
                    return NotFound(new { message = "The Id not exists" });
                }
                // deleting country from db
                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
                return Ok(new { message = "The country was deleted successfully!" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
