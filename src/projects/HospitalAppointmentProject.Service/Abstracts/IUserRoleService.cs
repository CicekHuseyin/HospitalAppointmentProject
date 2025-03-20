using HospitalAppointmentProject.Model.Dtos.UserRoles;

namespace HospitalAppointmentProject.Service.Abstracts;

public interface IUserRoleService
{
    Task<string> AddAsync(UserRoleAddRequestDto dto, CancellationToken cancellationToken = default);

    Task UpdateAsync(UserRoleUpdateRequestDto dto, CancellationToken cancellationToken = default);

    Task<List<UserRoleResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<UserRoleResponseDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
