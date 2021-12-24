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
    public class QuestionsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public QuestionsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _context.Questions.ToListAsync();
            return Ok(response);
        }

        //[HttpGet]
        //[Route("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var response = await _context.Questions.FindAsync(id);
        //    if (response == null)
        //        return NotFound();
        //    return Ok(response);
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Question model)
        {
            if (model == null)
                return BadRequest();

            _context.Questions.Add(model);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

