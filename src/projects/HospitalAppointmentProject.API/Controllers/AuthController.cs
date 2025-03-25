using HospitalAppointmentProject.Model.Dtos.Users;
using HospitalAppointmentProject.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("Register")]

        public async Task<IActionResult> Register(RegisterRequestDto dto)
        {
            var result = await authService.RegisterAsync(dto);
            return Ok(result);
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login(LoginRequestDto dto)
        {
            var result = await authService.LoginAsync(dto);
            return Ok(result);
        }
    }
}
