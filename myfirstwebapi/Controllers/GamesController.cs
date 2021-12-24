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
    public class GamesController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public GamesController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _context.Games.ToListAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _context.Games.FindAsync(id);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Game model)
        {
            if (model == null)
                return BadRequest();

            _context.Games.Add(model);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Game model)
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
            var response = await _context.Games.FindAsync(id);
            if (response == null)
                return NotFound();
            _context.Games.Remove(response);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
