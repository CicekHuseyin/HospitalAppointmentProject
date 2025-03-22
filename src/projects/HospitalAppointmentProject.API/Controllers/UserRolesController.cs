using HospitalAppointmentProject.Model.Dtos.Hospitals;
using HospitalAppointmentProject.Model.Dtos.UserRoles;
using HospitalAppointmentProject.Service.Abstracts;
using HospitalAppointmentProject.Service.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRolesController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(UserRoleAddRequestDto dto)
        {
            var result = await _userRoleService.AddAsync(dto);

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _userRoleService.GetAllAsync();
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(UserRoleUpdateRequestDto dto)
        {
            await _userRoleService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _userRoleService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id) => Ok(await _userRoleService.GetByIdAsync(id));
    }
}
