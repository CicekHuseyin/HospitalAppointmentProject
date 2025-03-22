using HospitalAppointmentProject.Model.Dtos.Hospitals;
using HospitalAppointmentProject.Model.Dtos.Roles;
using HospitalAppointmentProject.Service.Abstracts;
using HospitalAppointmentProject.Service.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(RoleAddRequestDto dto)
        {
            var result = await _roleService.AddAsync(dto);

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _roleService.GetAllAsync();
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(RoleUpdateRequestDto dto)
        {
            await _roleService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _roleService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id) => Ok(await _roleService.GetByIdAsync(id));
    }
}
