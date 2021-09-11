using System;
using System.Threading.Tasks;
using AutoMapper;
using DevFitness.API.Models.users.InputModels;
using DevFitness.API.Models.users.ViewModels;
using DevFitness.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using DevFitness.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;

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
        /// <remarks>
        /// GET api/v1/users/1
        /// </remarks>>
        /// <param name="id">User id</param>
        /// <returns>The user</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _userService.GetById(id);
                
                var userViewModel = _mapper.Map<UserViewModel>(user);

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
        /// <param name="userInputModel">User</param>
        /// <returns>Get route</returns>
        /// <response code="201">Success</response>
        /// <response code="400">Invalid model state</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserInputModel userInputModel)
        {
            try
            {
                var user = _mapper.Map<User>(userInputModel);

                await _userService.Add(user);
                
                return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="user">User model</param>
        /// <returns>No content</returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUserInputModel user)
        {
            try
            {
                if (id != user.Id) return BadRequest("Invalid ID");

                await _userService.Update(_mapper.Map<User>(user));

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
