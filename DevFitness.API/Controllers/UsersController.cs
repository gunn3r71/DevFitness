using DevFitness.API.Models.InputModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFitness.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //return NotFound();
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserInputModel user)
        {
            return CreatedAtAction(nameof(Get), new { Id = 10}, user);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] UpdateUserInputModel user)
        {
            //return NotFound();
            //return BadRequest();
            return NoContent();
        }
    }
}
