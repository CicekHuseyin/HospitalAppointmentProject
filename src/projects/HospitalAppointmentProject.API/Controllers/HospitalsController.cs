using HospitalAppointmentProject.Model.Dtos.Doctors;
using HospitalAppointmentProject.Model.Dtos.Hospitals;
using HospitalAppointmentProject.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        private readonly IHospitalService _hospitalService;

        public HospitalsController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(HospitalAddRequestDto dto)
        {
            var result = await _hospitalService.AddAsync(dto);

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _hospitalService.GetAllAsync();
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(HospitalUpdateRequestDto dto)
        {
            await _hospitalService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _hospitalService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id) => Ok(await _hospitalService.GetByIdAsync(id));
    }
}

