using AutoMapper;
using DevFitness.API.Models.InputModels;
using DevFitness.API.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevFitness.API.Controllers
{
    [Route("api/v1/users/{userId}/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        //private readonly DevFitnessDbContext _context;
        //private readonly IMapper _mapper;

        //public MealsController(DevFitnessDbContext context,IMapper mapper)
        //{
        //    _context = context;
        //    _mapper = mapper;
        //}

        //[HttpGet]
        //public IActionResult Get(int userId)
        //{
        //    var allMeals = _context.Meals.Where(x => x.UserId == userId).ToList();
        //    var allMealsViewModel = allMeals.Select(x => _mapper.Map<MealViewModel>(x));
        //    return Ok(allMealsViewModel);
        //}
        
        //[HttpGet("{mealId}")]
        //public IActionResult Get(int userId,int mealId)
        //{
        //    var meal = _context.Meals.SingleOrDefault(x => x.Id == mealId && x.UserId == userId);
        //    if (meal == null)
        //        return NotFound($"Cannot find mealt with id: {mealId}");
            
        //    var mealviewModel = _mapper.Map<MealViewModel>(meal);

        //    return Ok(mealviewModel);
        //}

        //[HttpPost]
        //public IActionResult Post(int userId,[FromBody] CreateMealInputModel meal)
        //{
        //    var _meal = new Meal(meal.Description,meal.Calories,meal.Date,userId);
        //    _context.Meals.Add(_meal);
        //    _context.SaveChanges();

        //    return CreatedAtAction(nameof(Get), new { UserId = userId, MealId = _meal.Id}, meal);
        //}

        //[HttpPut("{mealId}")]
        //public IActionResult Put(int userId, int mealId, [FromBody] UpdateMealInputModel meal)
        //{
        //    var _meal = _context.Meals.SingleOrDefault(x => x.Id == mealId && x.UserId == userId);
        //    if (_meal == null)
        //        return NotFound($"Cannot find meal with id: {mealId}");

        //    _meal.Update(meal.Description,meal.Calories, meal.Date);
        //    _context.SaveChanges();

        //    return NoContent();
        //}

        //[HttpDelete("{mealId}")]
        //public IActionResult Delete(int userId, int mealId)
        //{
        //    var _meal = _context.Meals.SingleOrDefault(x => x.Id == mealId && x.UserId == userId);
        //    if (_meal == null)
        //        return NotFound($"Cannot find meal with id: {mealId}");

        //    _meal.Desactivate();

        //    _context.SaveChanges();

        //    return NoContent();
        //}
    }
}
