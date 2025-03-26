using Core.Security.Entities;
using HospitalAppointmentProject.Model.Dtos.Users;
using HospitalAppointmentProject.Model.Entities;

namespace HospitalAppointmentProject.Service.Abstracts;

public interface IUserService
{
    Task<UserResponseDto?> AddAsync(User user, CancellationToken cancellationToken = default);

    Task<User> UpdateAsync(User user, CancellationToken cancellationToken = default);

    Task<List<UserResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<UserResponseDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<UserResponseDto?> DeleteAsync(int id, CancellationToken cancellationToken = default);

    Task<UserResponseDto?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
}
