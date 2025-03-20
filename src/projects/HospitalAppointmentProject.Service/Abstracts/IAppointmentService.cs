using HospitalAppointmentProject.Model.Dtos.Appointments;

namespace HospitalAppointmentProject.Service.Abstracts;

public interface IAppointmentService
{
    Task<string> AddAsync(AppointmentAddRequestDto dto, CancellationToken cancellationToken = default);

    Task UpdateAsync(AppointmentUpdateRequestDto dto, CancellationToken cancellationToken = default);

    Task<List<AppointmentResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<AppointmentResponseDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
