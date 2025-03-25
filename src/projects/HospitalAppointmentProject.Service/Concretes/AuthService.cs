using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Hashing;
using HospitalAppointmentProject.Model.Dtos.Users;
using HospitalAppointmentProject.Model.Entities;
using HospitalAppointmentProject.Service.Abstracts;
using HospitalAppointmentProject.Service.BusinessRules.Users;
using HospitalAppointmentProject.Service.Constants.Users;
namespace HospitalAppointmentProject.Service.Concretes;

public sealed class AuthService : IAuthService 
{
    private readonly IUserService _userService;
    private readonly UserBusinessRules _userBusinessRules;
    private readonly IMapper _mapper;

    public AuthService(IUserService userService, UserBusinessRules userBusinessRules, IMapper mapper)
    {
        _userService = userService;
        _userBusinessRules = userBusinessRules;
        _mapper = mapper;
    }

    public async Task<string> LoginAsync(LoginRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        await _userBusinessRules.SearchByEmailAsync(requestDto.Email);

        var user = await _userService.GetByEmailAsync(requestDto.Email, cancellationToken);

        var verifyPassword = HashingHelper.VerifyPasswordHash(
            requestDto.Password,
            Convert.FromBase64String(user.PasswordHash),
            Convert.FromBase64String(user.PasswordSalt)
        );

        if (!verifyPassword)
            throw new BusinessException(UsersMessages.PasswordIsWrong);

        return "Giriş Başarılı";

    }

    public async Task<string> RegisterAsync(RegisterRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        User user = _mapper.Map<User>(requestDto);

        var hashResult = HashingHelper.CreatePasswordHash(requestDto.Password);

        user.PasswordHash = hashResult.passwordHash;
        user.PasswordSalt = hashResult.passwordSalt;

        await _userService.AddAsync(user);

        return "Kayıt Başarıyla Oluşturuldu.";
    }
}
