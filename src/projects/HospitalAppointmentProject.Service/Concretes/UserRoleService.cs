using AutoMapper;
using Core.Security.Entities;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Model.Dtos.UserRoles;
using HospitalAppointmentProject.Model.Entities;
using HospitalAppointmentProject.Service.Abstracts;
using HospitalAppointmentProject.Service.BusinessRules.UserRoles;
using HospitalAppointmentProject.Service.Constants.UserRoles;

namespace UserRoleAppointmentProject.Service.Concretes;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IMapper _mapper;
    private readonly UserRoleBusinessRules _businessRules;

    public UserRoleService(IUserRoleRepository userRoleRepository, IMapper mapper, UserRoleBusinessRules businessRules)
    {
        _userRoleRepository = userRoleRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<string> AddAsync(UserRoleAddRequestDto dto, CancellationToken cancellationToken = default)
    {
        UserRole userRole = _mapper.Map<UserRole>(dto);
        await _userRoleRepository.AddAsync(userRole);
        return UserRoleMessages.UserRoleAddedMessage;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _businessRules.UserRoleIsPresentAsync(id);

        UserRole userRole = await _userRoleRepository.GetAsync(filter: x => x.Id == id, include: false, cancellationToken: cancellationToken);

        await _userRoleRepository.DeleteAsync(userRole, cancellationToken);
    }

    public async Task<List<UserRoleResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        List<UserRole> userRoles = await _userRoleRepository.GetAllAsync(enableTracking: false, cancellationToken: cancellationToken);
        var userRoleResponseDtos = _mapper.Map<List<UserRoleResponseDto>>(userRoles);
        return userRoleResponseDtos;
    }

    public async Task<UserRoleResponseDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await _businessRules.UserRoleIsPresentAsync(id);
        UserRole userRole = await _userRoleRepository.GetAsync(filter: x => x.Id == id, enableTracking: false, cancellationToken: cancellationToken);
        var userRoleResponseDtos = _mapper.Map<UserRoleResponseDto>(userRole);
        return userRoleResponseDtos;
    }

    public async Task UpdateAsync(UserRoleUpdateRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _businessRules.UserRoleIsPresentAsync(dto.Id);
        ////Movie movie = await _movieRepository.GetAsync(filter: x => x.Id == dto.Id, include: false, cancellationToken: cancellationToken);
        UserRole userRole = _mapper.Map<UserRole>(dto);
        await _userRoleRepository.UpdateAsync(userRole, cancellationToken);
    }
}
