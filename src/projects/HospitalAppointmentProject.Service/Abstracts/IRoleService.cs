using HospitalAppointmentProject.Model.Dtos.Roles;

namespace HospitalAppointmentProject.Service.Abstracts;

public interface IRoleService
{
    Task<string> AddAsync(RoleAddRequestDto dto, CancellationToken cancellationToken = default);

    Task UpdateAsync(RoleUpdateRequestDto dto, CancellationToken cancellationToken = default);

    Task<List<RoleResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<RoleResponseDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
