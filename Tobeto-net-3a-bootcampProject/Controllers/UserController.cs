using Business.Abstracts;
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

        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            await _userManager.Add(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userManager.Delete(user);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userManager.Get(id);
            if (user == null)
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            if (id == null)
            {
                return BadRequest();
            }

            //var existingUser = await _userManager.Get(id);
            //if (existingUser == null)
            //{
            //    return NotFound();
            //}

            await _userManager.Update(user);
            return Ok();
        }
    }
}
