using Business.Abstracts;
using Business.Requests.Application;
using Business.Requests.BootcampState;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tobeto_net_3a_bootcampProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampStateController : BaseController
    {
        private readonly IBootcampStateService _bootcampStateService;

        public BootcampStateController(IBootcampStateService bootcampStateService)
        {
            _bootcampStateService = bootcampStateService;
        }

        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(CreateBootcampStateRequest request)
        {
            return HandleDataResult(await _bootcampStateService.AddAsync(request));
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> getAllAsync()
        {
            return HandleDataResult(await _bootcampStateService.GetAllAsync());
        }

        [HttpPost("GetByIdAsync")]
        public async Task<IActionResult> getByIdAsync(GetByIdBootcampStateRequest request)
        {
            return HandleDataResult(await _bootcampStateService.GetByIdAsync(request));
        }

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(DeleteBootcampStateRequest request)
        {
            return HandleResult(await _bootcampStateService.DeleteAsync(request));
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(UpdateBootcampStateRequest request)
        {
            return HandleDataResult(await _bootcampStateService.UpdateAsync(request));
        }
    }
}
