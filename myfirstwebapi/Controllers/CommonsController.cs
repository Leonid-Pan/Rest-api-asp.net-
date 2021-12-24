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
    public class CommonsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public CommonsController(ApplicationContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Common model)
        {
            if (model == null)
                return BadRequest();

            _context.Commons.Add(model);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

