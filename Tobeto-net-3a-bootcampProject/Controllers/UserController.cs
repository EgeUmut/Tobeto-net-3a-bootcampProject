using Business.Abstracts;
using Business.Requests.User;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tobeto_net_3a_bootcampProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userManager;

        public UserController(IUserService userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var addedUser = await _userManager.AddAsync(request);
            return HandleDataResult(addedUser);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteUserRequest request)
        {
            var item = await _userManager.DeleteAsync(request);
            return HandleResult(item);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(GetByIdUserRequest request)
        {
            var user = await _userManager.GetByIdAsync(request);

            return HandleDataResult(user);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userManager.GetAllAsync();
            return HandleDataResult(users);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateUserRequest request)
        {

            var updatedUser = await _userManager.UpdateAsync(request);
            return HandleDataResult(updatedUser);
        }
    }
}
