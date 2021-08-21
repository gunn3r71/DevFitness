using System;
using System.Threading.Tasks;
using AutoMapper;
using DevFitness.API.Models.users.InputModels;
using DevFitness.API.Models.users.ViewModels;
using DevFitness.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using DevFitness.Core.Interfaces.Services;

namespace DevFitness.API.Controllers
{
    /// <summary>
    /// Users API
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Dependency Injection Builder
        /// </summary>
        /// <param name="userService">Service</param>
        /// <param name="mapper">Auto Mapper</param>
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var _user = await _userService.GetById(id);
                
                var userViewModel = _mapper.Map<UserViewModel>(_user);

                return Ok(userViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>201</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserInputModel userInputModel)
        {
            try
            {
                var user = _mapper.Map<User>(userInputModel);

                await _userService.Add(user);

                return CreatedAtAction(nameof(GetById), new { Id = user.Id });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

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
