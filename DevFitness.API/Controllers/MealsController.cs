using DevFitness.API.Models.InputModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFitness.API.Controllers
{
    [Route("api/v1/users/{userId}/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(int userId)
        {
            //return NotFound();
            return Ok();
        }
        
        [HttpGet("{mealId}")]
        public IActionResult Get(int userId,int mealId)
        {
            //return NotFound();
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(int userId,[FromBody] CreateMealInputModel meal)
        {
            return CreatedAtAction(nameof(Get), new { Id = 10 }, meal);
        }

        [HttpPut("{mealId}")]
        public IActionResult Put(int userId, int mealId, [FromBody] UpdateMealInputModel meal)
        {
            //return NotFound();
            //return BadRequest();
            return NoContent();
        }

        [HttpDelete("{mealId}")]
        public IActionResult Delete(int userId, int mealId)
        {
            return NoContent();
        }
    }
}
}
