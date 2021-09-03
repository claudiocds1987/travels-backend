using Microsoft.AspNetCore.Mvc;
using backend_api.Models; // Para cuando hagamos el Post mas adelante
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
    public class BrandController : ControllerBase
    {
        private readonly AplicationDbContext _context;
       
        //constructor
        public BrandController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<BrandController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listBrand = await _context.Brands.ToListAsync();
                return Ok(listBrand);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var brand = await _context.Brands.FindAsync(id);

                if (brand == null)
                {
                    return NotFound(new { message = "The Id of Brand not exist!" });
                }

                return Ok(brand);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<BrandController>
        [HttpPost]
        public async Task<IActionResult>Post([FromBody] Brand brand)
        {
            try
            {
                _context.Add(brand);
                await _context.SaveChangesAsync();
                return Ok(new { message = "The Brand was created successfully!", brand });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<BrandController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Brand brand)
        {
            try
            {
                if(id != brand.Id)
                {
                    return NotFound(new { message = "The id brand " + id + "not exists" });
                }

                _context.Update(brand);
                await _context.SaveChangesAsync();
                return Ok(new { message = "The brand was updated successfully!" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // finding brand by id
                var brand = await _context.Brands.FindAsync(id);

                if(brand == null)
                {
                    return NotFound(new { message = "The Id brand" + id + " not exists" });
                }

                _context.Brands.Remove(brand);
                await _context.SaveChangesAsync();
                return Ok(new { message = "The brand was deleted successfuly" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        
        }
    }
}
