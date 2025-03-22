using AutoMapper;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
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

    public async Task<string> AddAsync(UserAddRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _businessRules.UserNameMustBeUniqueAsync(dto.Username);
        User user = _mapper.Map<User>(dto);
        await _userRepository.AddAsync(user);
        return UsersMessages.UserAddedMessage;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _businessRules.UserIsPresentAsync(id);

        User user = await _userRepository.GetAsync(filter: x => x.Id == id, include: false, cancellationToken: cancellationToken);

        await _userRepository.DeleteAsync(user, cancellationToken);
    }

    public async Task<List<UserResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        List<User> users = await _userRepository.GetAllAsync(enableTracking: false, cancellationToken: cancellationToken);
        var userResponseDtos = _mapper.Map<List<UserResponseDto>>(users);
        return userResponseDtos;
    }

    public async Task<UserResponseDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await _businessRules.UserIsPresentAsync(id);
        User user = await _userRepository.GetAsync(filter: x => x.Id == id, enableTracking: false, cancellationToken: cancellationToken);
        var userResponseDtos = _mapper.Map<UserResponseDto>(user);
        return userResponseDtos;
    }

    public async Task UpdateAsync(UserUpdateRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _businessRules.UserIsPresentAsync(dto.Id);
        ////Movie movie = await _movieRepository.GetAsync(filter: x => x.Id == dto.Id, include: false, cancellationToken: cancellationToken);
        User user = _mapper.Map<User>(dto);
        await _userRepository.UpdateAsync(user, cancellationToken);
    }
}
