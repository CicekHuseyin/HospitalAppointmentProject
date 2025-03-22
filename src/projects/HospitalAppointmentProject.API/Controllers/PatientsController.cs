using HospitalAppointmentProject.Model.Dtos.Hospitals;
using HospitalAppointmentProject.Model.Dtos.Patients;
using HospitalAppointmentProject.Service.Abstracts;
using HospitalAppointmentProject.Service.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(PatientAddRequestDto dto)
        {
            var result = await _patientService.AddAsync(dto);

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _patientService.GetAllAsync();
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(PatientUpdateRequestDto dto)
        {
            await _patientService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _patientService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id) => Ok(await _patientService.GetByIdAsync(id));
    }
}
