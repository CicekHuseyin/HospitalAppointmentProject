using HospitalAppointmentProject.Model.Dtos.Patients;

namespace HospitalAppointmentProject.Service.Abstracts;

public interface IPatientService 
{
    Task<string> AddAsync(PatientAddRequestDto dto, CancellationToken cancellationToken = default);

    Task UpdateAsync(PatientUpdateRequestDto dto, CancellationToken cancellationToken = default);

    Task<List<PatientResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<PatientResponseDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
