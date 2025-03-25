using Core.Security.JWT;
using HospitalAppointmentProject.Model.Dtos.Users;

namespace HospitalAppointmentProject.Service.Abstracts;

public interface IAuthService
{
    Task<AccessToken> RegisterAsync(RegisterRequestDto requestDto, CancellationToken cancellationToken = default);
    Task<AccessToken> LoginAsync(LoginRequestDto requestDto, CancellationToken cancellationToken = default);
}
