﻿using Business.Abstracts;
using Business.Requests.User;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tobeto_net_3a_bootcampProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userManager;

        public UserController(IUserService userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            await _userManager.AddAsync(request);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteUserRequest request)
        {
            var user = await _userManager.GetByIdAsync(request.Id);
            if (user == null)
            {
                return NotFound();
            }

            await _userManager.DeleteAsync(request);
            return Ok();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userManager.GetByIdAsync(id);
            if (user.Id == 0 && user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userManager.GetAll();
            return Ok(users);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateUserRequest request)
        {
            if (request.Id == null)
            {
                return BadRequest();
            }

            //var existingUser = await _userManager.Get(id);
            //if (existingUser == null)
            //{
            //    return NotFound();
            //}

            await _userManager.UpdateAsync(request);
            return Ok();
        }
    }
}