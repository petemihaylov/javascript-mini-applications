using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using WebApi.Models;
using WebApi.Dtos;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _userService.GetUsers();
            if (users != null) return Ok(users);
            return NotFound();
        }

        // GET api/users/{id}
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<User> GetUserById(Guid id)
        {
            return Ok(_userService.GetUserById(id));
        }

        // PUT api/users/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUser(UserDto userDto)
        {
            var user = _userService.UpdateUser(userDto);
            return user != null ? Ok(user) : BadRequest();
        }


        // DELETE api/users/{id}
        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUser(Guid id)
        {
            var user = _userService.DeleteUser(id);
            return user != null ? Ok(user) : BadRequest();
        }
    }
}