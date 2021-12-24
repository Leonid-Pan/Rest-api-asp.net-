using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myfirstwebapi.Models;
using myfirstwebapi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public AnimalsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _context.Animals.ToListAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _context.Animals.FindAsync(id);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Animal model)
        {
            if (model == null)
                return BadRequest();

            _context.Animals.Add(model);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Animal model)
        {
            if (model == null)
                return BadRequest();

            _context.Update(model);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _context.Animals.FindAsync(id);
            if (response == null)
                return NotFound();
            _context.Animals.Remove(response);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
