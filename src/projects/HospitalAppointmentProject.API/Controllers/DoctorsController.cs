using HospitalAppointmentProject.Model.Dtos.Doctors;
using HospitalDoctorProject.Service.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost("Add")]
        [AllowAnonymous]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAsync(DoctorAddRequestDto dto)
        {
            var result = await _doctorService.AddAsync(dto);

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _doctorService.GetAllAsync();
            return Ok(result);
        }

        [HttpPut("Update")]
        [AllowAnonymous]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(DoctorUpdateRequestDto dto)
        {
            await _doctorService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("Delete")]
        [AllowAnonymous]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _doctorService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id) => Ok(await _doctorService.GetByIdAsync(id));
    }
}
