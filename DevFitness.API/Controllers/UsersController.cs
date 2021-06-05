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
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DevFitnessDbContext _context;

        public UsersController(DevFitnessDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var _user = _context.Users.SingleOrDefault(x => x.Id == id && x.Active);

            if (_user == null)
                return NotFound($"Cannot find user with id: {id}");

            var userViewModel = new UserViewModel(_user.Id,_user.FullName,_user.Height,_user.Weight,_user.BirthDate);

            return Ok(userViewModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserInputModel user)
        {
            var _user = new User(user.FullName,user.Height,user.Weight,user.BirthDate);

            _context.Users.Add(_user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { Id = _user.Id}, user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserInputModel user)
        {
            var _user = _context.Users.SingleOrDefault(x => x.Id == id);
            if (_user == null)
                return NotFound($"Cannot find user with id: {id}");

            _user.Update(user.Height,user.Weight);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
