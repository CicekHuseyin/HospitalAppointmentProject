using HospitalAppointmentProject.Model.Dtos.Users;

namespace HospitalAppointmentProject.Service.Abstracts;

public interface IAuthService
{
    Task<string> RegisterAsync(RegisterRequestDto requestDto, CancellationToken cancellationToken = default);
    Task<string> LoginAsync(LoginRequestDto requestDto, CancellationToken cancellationToken = default);
}
