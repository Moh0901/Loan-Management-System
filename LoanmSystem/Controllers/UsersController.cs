﻿

using LoanmSystem.DTO;
using LoanmSystem.Model;
using LoanmSystem.Repository;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.ComponentModel.DataAnnotations;

namespace LoanmSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
          
        }

        [Authorize(Roles = "admin")]
        // GET: api/Users
        [HttpGet]
        public IActionResult Getuser()
        {
            // var token = Request != null ? Request.Headers["Authorization"].ToString().Replace("Bearer", "") : "";
            var result = _userRepository.GetAllUsers();

            if (result == null || result.Count == 0)
            {
                return NotFound("No User Exists");
            }

            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound("User Not Found");
            }

            return Ok(user);
        }

        [Authorize(Roles = "admin")]
        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromRoute] int id, [FromBody] DTO.UserDTO user)
        {
            if (user == null)
            {
                return NotFound("User Not Found");
            }

            var updatedUser = _userRepository.UpdateUser(id, user);

            if (updatedUser != null)
            {
                var updatedUserDTO = new DTO.UserDTO()
                {
                    name = updatedUser.name,
                    username = updatedUser.username,
                    password = updatedUser.password,
                    role = updatedUser.role
                };
                return Ok(updatedUserDTO);
            }
            return NotFound("User Not Found");
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostUser(UserDTO user)
        {

            if (user == null)
            {
                return NotFound("User Not Found");
            }
            var newUser = _userRepository.AddUser(user);


            return CreatedAtAction("GetUser", new { id = newUser.id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {

            var user = _userRepository.DeleteUser(id);
            if (user == null)
            {
                return NotFound("User Not Found");
            }

            return Ok(user);
        }

    }
}
