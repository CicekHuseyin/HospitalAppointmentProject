﻿using AutoMapper;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Model.Dtos.Doctors;
using HospitalAppointmentProject.Model.Entities;
using HospitalAppointmentProject.Service.BusinessRules.Doctors;
using HospitalAppointmentProject.Service.Constants.Doctors;
using HospitalAppointmentProject.Service.Validators;
using HospitalDoctorProject.Service.Abstracts;

namespace HospitalDoctorProject.Service.Concretes;

public class DoctorService :IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMapper _mapper;
    private readonly DoctorBusinessRules _businessRules;
    private readonly DoctorValidator _validationRules;
    private readonly IValidationService _validationService;

    public DoctorService(IDoctorRepository doctorRepository, IMapper mapper, DoctorBusinessRules businessRules, DoctorValidator validationRules, IValidationService validationService)
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
        _businessRules = businessRules;
        _validationRules = validationRules;
        _validationService = validationService;
    }

    public async Task<string> AddAsync(DoctorAddRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _validationService.ValidateAsync(_validationRules, dto);
        await _businessRules.CheckDoctorLimitAsync(dto.HospitalId, dto.Specialty);
        await _businessRules.DoctorNameMustBeUniqueAsync(dto.FirstName);
        Doctor doctor = _mapper.Map<Doctor>(dto);
        await _doctorRepository.AddAsync(doctor);
        return DoctorMessages.DoctorAddedMessage;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _businessRules.DoctorIsPresentAsync(id);

        Doctor doctor = await _doctorRepository.GetAsync(filter: x => x.Id == id, include: false, cancellationToken: cancellationToken);

        await _doctorRepository.DeleteAsync(doctor, cancellationToken);
    }

    public async Task<List<DoctorResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        List<Doctor> doctors = await _doctorRepository.GetAllAsync(enableTracking: false, cancellationToken: cancellationToken);
        var doctorResponseDtos = _mapper.Map<List<DoctorResponseDto>>(doctors);
        return doctorResponseDtos;
    }

    public async Task<DoctorResponseDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await _businessRules.DoctorIsPresentAsync(id);
        Doctor doctor = await _doctorRepository.GetAsync(filter: x => x.Id == id, enableTracking: false, cancellationToken: cancellationToken);
        var doctorResponseDtos = _mapper.Map<DoctorResponseDto>(doctor);
        return doctorResponseDtos;
    }

    public async Task UpdateAsync(DoctorUpdateRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _businessRules.DoctorIsPresentAsync(dto.Id);
        ////Movie movie = await _movieRepository.GetAsync(filter: x => x.Id == dto.Id, include: false, cancellationToken: cancellationToken);
        Doctor doctor = _mapper.Map<Doctor>(dto);
        await _doctorRepository.UpdateAsync(doctor, cancellationToken);
    }
}
