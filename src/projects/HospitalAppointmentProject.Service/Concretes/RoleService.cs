using AutoMapper;
using Core.Security.Entities;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Model.Dtos.Roles;
using HospitalAppointmentProject.Model.Entities;
using HospitalAppointmentProject.Service.Abstracts;
using HospitalAppointmentProject.Service.BusinessRules.Roles;
using HospitalAppointmentProject.Service.Constants.Roles;

namespace RoleAppointmentProject.Service.Concretes;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;
    private readonly RoleBusinessRules _businessRules;

    public RoleService(IRoleRepository roleRepository, IMapper mapper, RoleBusinessRules businessRules)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<string> AddAsync(RoleAddRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _businessRules.RoleNameMustBeUniqueAsync(dto.Name);
        Role role = _mapper.Map<Role>(dto);
        await _roleRepository.AddAsync(role);
        return RoleMessages.RoleAddedMessage;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _businessRules.RoleIsPresentAsync(id);

        Role role = await _roleRepository.GetAsync(filter: x => x.Id == id, include: false, cancellationToken: cancellationToken);

        await _roleRepository.DeleteAsync(role, cancellationToken);
    }

    public async Task<List<RoleResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        List<Role> roles = await _roleRepository.GetAllAsync(enableTracking: false, cancellationToken: cancellationToken);
        var roleResponseDtos = _mapper.Map<List<RoleResponseDto>>(roles);
        return roleResponseDtos;
    }

    public async Task<RoleResponseDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await _businessRules.RoleIsPresentAsync(id);
        Role role = await _roleRepository.GetAsync(filter: x => x.Id == id, enableTracking: false, cancellationToken: cancellationToken);
        var roleResponseDtos = _mapper.Map<RoleResponseDto>(role);
        return roleResponseDtos;
    }

    public async Task UpdateAsync(RoleUpdateRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _businessRules.RoleIsPresentAsync(dto.Id);
        ////Movie movie = await _movieRepository.GetAsync(filter: x => x.Id == dto.Id, include: false, cancellationToken: cancellationToken);
        Role role = _mapper.Map<Role>(dto);
        await _roleRepository.UpdateAsync(role, cancellationToken);
    }
}
