using HospitalAppointmentProject.Model.Dtos.Hospitals;

namespace HospitalAppointmentProject.Service.Abstracts;

public interface IHospitalService
{
    Task<string> AddAsync(HospitalAddRequestDto dto, CancellationToken cancellationToken = default);

    Task UpdateAsync(HospitalUpdateRequestDto dto, CancellationToken cancellationToken = default);

    Task<List<HospitalResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<HospitalResponseDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
