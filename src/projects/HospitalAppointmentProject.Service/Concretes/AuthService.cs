using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
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
    private readonly IJwtService _jwtService;

    public AuthService(IUserService userService, UserBusinessRules userBusinessRules, IMapper mapper, IJwtService jwtService)
    {
        _userService = userService;
        _userBusinessRules = userBusinessRules;
        _mapper = mapper;
        _jwtService = jwtService;
    }

    public async Task<AccessToken> LoginAsync(LoginRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        await _userBusinessRules.SearchByEmailAsync(requestDto.Email);

        UserResponseDto user = await _userService.GetByEmailAsync(requestDto.Email, cancellationToken);

        var verifyPassword = HashingHelper.VerifyPasswordHash(
            requestDto.Password,
            Convert.FromBase64String(user.PasswordHash),
            Convert.FromBase64String(user.PasswordSalt)
        );

        if (!verifyPassword)
            throw new BusinessException(UsersMessages.PasswordIsWrong);

        User userWithToken = _mapper.Map<User>(user);

        AccessToken accessToken=await _jwtService.CreateAccessTokenAsync(userWithToken);

        return accessToken;

    }

    public async Task<AccessToken> RegisterAsync(RegisterRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        User user = _mapper.Map<User>(requestDto);

        var hashResult = HashingHelper.CreatePasswordHash(requestDto.Password);

        user.PasswordHash = hashResult.passwordHash;
        user.PasswordSalt = hashResult.passwordSalt;

        await _userService.AddAsync(user);

        return new AccessToken();
    }
}
