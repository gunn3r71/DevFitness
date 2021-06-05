using DevFitness.API.Core.Entities;
using DevFitness.API.Models.InputModels;
using DevFitness.API.Models.ViewModels;
using DevFitness.API.Persistence;
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
        private readonly DevFitnessDbContext _context;

        public MealsController(DevFitnessDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(int userId)
        {
            var allMeals = _context.Meals.Where(x => x.UserId == userId).ToList();
            var allMealsViewModel = allMeals.Select(x => new MealViewModel(x.Id,x.Description,x.Calories,x.Date));
            return Ok(allMealsViewModel);
        }
        
        [HttpGet("{mealId}")]
        public IActionResult Get(int userId,int mealId)
        {
            var meal = _context.Meals.SingleOrDefault(x => x.Id == mealId && x.UserId == userId);
            if (meal == null)
                return NotFound($"Cannot find mealt with id: {mealId}");
            
            var mealviewModel = new MealViewModel(meal.Id, meal.Description, meal.Calories, meal.Date);

            return Ok(mealviewModel);
        }

        [HttpPost]
        public IActionResult Post(int userId,[FromBody] CreateMealInputModel meal)
        {
            var _meal = new Meal(meal.Description,meal.Calories,meal.Date,userId);
            _context.Meals.Add(_meal);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { UserId = userId, MealId = _meal.Id}, meal);
        }

        [HttpPut("{mealId}")]
        public IActionResult Put(int userId, int mealId, [FromBody] UpdateMealInputModel meal)
        {
            var _meal = _context.Meals.SingleOrDefault(x => x.Id == mealId && x.UserId == userId);
            if (_meal == null)
                return NotFound($"Cannot find meal with id: {mealId}");

            _meal.Update(meal.Description,meal.Calories, meal.Date);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{mealId}")]
        public IActionResult Delete(int userId, int mealId)
        {
            var _meal = _context.Meals.SingleOrDefault(x => x.Id == mealId && x.UserId == userId);
            if (_meal == null)
                return NotFound($"Cannot find meal with id: {mealId}");

            _meal.Desactivate();

            _context.SaveChanges();

            return NoContent();
        }
    }
}
