using AutoMapper;
using DevFitness.API.Models.InputModels;
using DevFitness.API.Models.ViewModels;
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
        //private readonly DevFitnessDbContext _context;
        //private readonly IMapper _mapper;
        //public UsersController(DevFitnessDbContext context, IMapper mapper)
        //{
        //    _context = context;
        //    _mapper = mapper;
        //}

        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    var _user = _context.Users.SingleOrDefault(x => x.Id == id && x.Active);

        //    if (_user == null)
        //        return NotFound($"Cannot find user with id: {id}");

        //    var userViewModel = _mapper.Map<UserViewModel>(_user);

        //    return Ok(userViewModel);
        //}
        ///// api/users método HTTP POST
        ///// <summary>
        ///// Create a new user
        ///// </summary>
        ///// <remarks>
        ///// {
        /////     "fullname"
        ///// }
        ///// </remarks>
        ///// <param name="user"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public IActionResult Post([FromBody] CreateUserInputModel user)
        //{
        //    var _user = _mapper.Map<User>(user);

        //    _context.Users.Add(_user);
        //    _context.SaveChanges();

        //    return CreatedAtAction(nameof(Get), new { Id = _user.Id}, user);
        //}

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] UpdateUserInputModel user)
        //{
        //    var _user = _context.Users.SingleOrDefault(x => x.Id == id);
        //    if (_user == null)
        //        return NotFound($"Cannot find user with id: {id}");

        //    _user.Update(user.Height,user.Weight);
        //    _context.SaveChanges();

        //    return NoContent();
        //}
    }
}
