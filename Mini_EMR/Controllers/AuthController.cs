using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_EMR.Models.Auth;
using Mini_EMR.Services.Interfaces;

namespace Mini_EMR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            var response = await _authService.LoginAsync(model);

            if (response == null)
            {
                return Unauthorized(new 
                {
                    Message = "Invalid Username or Password"
                });
            }

            return Ok(response);
        }

        [HttpGet("doctors")]
        [Authorize]
        public async Task<IActionResult> GetDoctorsAsync()
        {
            var doctors = await _authService
                .GetDoctorsAsync();

            return Ok(doctors);
        }
    }
}
