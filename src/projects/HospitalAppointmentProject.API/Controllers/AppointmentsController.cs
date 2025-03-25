using HospitalAppointmentProject.Model.Dtos.Appointments;
using HospitalAppointmentProject.Model.Dtos.Hospitals;
using HospitalAppointmentProject.Service.Abstracts;
using HospitalAppointmentProject.Service.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(AppointmentAddRequestDto dto)
        {
            var result = await _appointmentService.AddAsync(dto);

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _appointmentService.GetAllAsync();
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(AppointmentUpdateRequestDto dto)
        {
            await _appointmentService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _appointmentService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id) => Ok(await _appointmentService.GetByIdAsync(id));
    }
}

