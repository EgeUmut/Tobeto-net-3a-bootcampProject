using Business.Abstracts;
using Business.Dtos.Register;
using Core.Utilities.Security.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tobeto_net_3a_bootcampProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("Employee register")]
        public async Task<IActionResult> Register(EmployeeForRegisterDto registerDto)
        {
            var result = await _authService.Register(registerDto);
            return HandleDataResult(result);
        }

        [HttpPost("Instructor register")]
        public async Task<IActionResult> Register(InstructorForRegisterDto registerDto)
        {
            var result = await _authService.Register(registerDto);
            return HandleDataResult(result);
        }

        [HttpPost("Applicant register")]
        public async Task<IActionResult> Register(ApplicantForRegisterDto registerDto)
        {
            var result = await _authService.Register(registerDto);
            return HandleDataResult(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var result = await _authService.Login(userForLoginDto);
            return HandleDataResult(result);
        }

        [HttpPost("test")]
        public async Task<IActionResult> test(UserForLoginDto userForLoginDto)
        {
            //var result = await _authService.Login(userForLoginDto);  Burada sorun var
            string a = "asd";
            return Ok(a);
        }
    }
}
