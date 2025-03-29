using AutoMapper;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Model.Dtos.Patients;
using HospitalAppointmentProject.Model.Entities;
using HospitalAppointmentProject.Service.Abstracts;
using HospitalAppointmentProject.Service.BusinessRules.Patients;
using HospitalAppointmentProject.Service.Constants.Patients;
using HospitalAppointmentProject.Service.Validators;

namespace PatientAppointmentProject.Service.Concretes;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;
    private readonly PatientBusinessRules _businessRules;
    private readonly PatientValidator _validationRules;
    private readonly IValidationService _validationService;

    public PatientService(IPatientRepository patientRepository, IMapper mapper, PatientBusinessRules businessRules, PatientValidator validationRules, IValidationService validationService)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
        _businessRules = businessRules;
        _validationRules = validationRules;
        _validationService = validationService;
    }

    public async Task<string> AddAsync(PatientAddRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _validationService.ValidateAsync(_validationRules, dto);
        await _businessRules.PatientNameMustBeUniqueAsync(dto.FirstName);
        Patient patient = _mapper.Map<Patient>(dto);
        await _patientRepository.AddAsync(patient);
        return PatientMessages.PatientAddedMessage;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _businessRules.PatientIsPresentAsync(id);

        Patient patient = await _patientRepository.GetAsync(filter: x => x.Id == id, include: false, cancellationToken: cancellationToken);

        await _patientRepository.DeleteAsync(patient, cancellationToken);
    }

    public async Task<List<PatientResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        List<Patient> patients = await _patientRepository.GetAllAsync(enableTracking: false, cancellationToken: cancellationToken);
        var patientResponseDtos = _mapper.Map<List<PatientResponseDto>>(patients);
        return patientResponseDtos;
    }

    public async Task<PatientResponseDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await _businessRules.PatientIsPresentAsync(id);
        Patient patient = await _patientRepository.GetAsync(filter: x => x.Id == id, enableTracking: false, cancellationToken: cancellationToken);
        var patientResponseDtos = _mapper.Map<PatientResponseDto>(patient);
        return patientResponseDtos;
    }

    public async Task UpdateAsync(PatientUpdateRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _businessRules.PatientIsPresentAsync(dto.Id);
        ////Movie movie = await _movieRepository.GetAsync(filter: x => x.Id == dto.Id, include: false, cancellationToken: cancellationToken);
        Patient patient = _mapper.Map<Patient>(dto);
        await _patientRepository.UpdateAsync(patient, cancellationToken);
    }
}
