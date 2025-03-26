using AutoMapper;
using Core.Security.Entities;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.DataAccess.Repositories.Concretes;
using HospitalAppointmentProject.Model.Dtos.Users;
using HospitalAppointmentProject.Model.Entities;
using HospitalAppointmentProject.Service.Abstracts;
using HospitalAppointmentProject.Service.BusinessRules.Users;
using HospitalAppointmentProject.Service.Constants.Users;

namespace UserAppointmentProject.Service.Concretes;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _businessRules;

    public UserService(IUserRepository userRepository, IMapper mapper, UserBusinessRules businessRules)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<UserResponseDto?> AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await _businessRules.EmailMustBeUniqueAsync(user.Email);
        await _businessRules.UserNameMustBeUniqueAsync(user.Username);

        User created = await _userRepository.AddAsync(user, cancellationToken);

        UserResponseDto response = _mapper.Map<UserResponseDto>(created);

        return response;
    }

    public async Task<UserResponseDto?> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _businessRules.UserIsPresentAsync(id);

        User user = await _userRepository.GetAsync(filter: x => x.Id == id, include: false, cancellationToken: cancellationToken);

        User deleted = await _userRepository.DeleteAsync(user, cancellationToken);

        UserResponseDto userResponseDto = _mapper.Map<UserResponseDto>(deleted);

        return userResponseDto;
    }

    public async Task<List<UserResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        List<User> users = await _userRepository.GetAllAsync(enableTracking: false, cancellationToken: cancellationToken);
        var userResponseDtos = _mapper.Map<List<UserResponseDto>>(users);
        return userResponseDtos;
    }

    public async Task<UserResponseDto?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetAsync(filter: x => x.Email == email, include: false, enableTracking: false, cancellationToken: cancellationToken);

        var response = _mapper.Map<UserResponseDto>(user);

        return response;
    }

    public async Task<UserResponseDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await _businessRules.UserIsPresentAsync(id);
        User user = await _userRepository.GetAsync(filter: x => x.Id == id, enableTracking: false, cancellationToken: cancellationToken);
        var userResponseDtos = _mapper.Map<UserResponseDto>(user);
        return userResponseDtos;
    }

    public async Task<User> UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        await _businessRules.UserIsPresentAsync(user.Id);
        User updated = await _userRepository.UpdateAsync(user, cancellationToken);

        return updated;
    }
}
