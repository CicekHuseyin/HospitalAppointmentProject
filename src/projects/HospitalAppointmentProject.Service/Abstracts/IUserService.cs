using HospitalAppointmentProject.Model.Dtos.Users;

namespace HospitalAppointmentProject.Service.Abstracts;

public interface IUserService
{
    Task<string> AddAsync(UserAddRequestDto dto, CancellationToken cancellationToken = default);

    Task UpdateAsync(UserUpdateRequestDto dto, CancellationToken cancellationToken = default);

    Task<List<UserResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<UserResponseDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
