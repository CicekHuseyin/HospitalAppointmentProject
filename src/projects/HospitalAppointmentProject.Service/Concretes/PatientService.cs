using AutoMapper;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Model.Dtos.Patients;
using HospitalAppointmentProject.Model.Entities;
using HospitalAppointmentProject.Service.Abstracts;

namespace PatientAppointmentProject.Service.Concretes;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;

    public PatientService(IPatientRepository patientRepository, IMapper mapper)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
    }

    public async Task<string> AddAsync(PatientAddRequestDto dto, CancellationToken cancellationToken = default)
    {
        //await _businessRules.MovieTitleMustBeUniqueAsync(dto.Name);
        Patient patient = _mapper.Map<Patient>(dto);
        await _patientRepository.AddAsync(patient);
        return "Buraya Business Roles gelecek";
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        //await _businessRules.MovieIsPresentAsync(id);

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
        //await _businessRules.MovieIsPresentAsync(id);
        Patient patient = await _patientRepository.GetAsync(filter: x => x.Id == id, enableTracking: false, cancellationToken: cancellationToken);
        var patientResponseDtos = _mapper.Map<PatientResponseDto>(patient);
        return patientResponseDtos;
    }

    public async Task UpdateAsync(PatientUpdateRequestDto dto, CancellationToken cancellationToken = default)
    {
        //await _businessRules.MovieIsPresentAsync(dto.Id);
        ////Movie movie = await _movieRepository.GetAsync(filter: x => x.Id == dto.Id, include: false, cancellationToken: cancellationToken);
        Patient patient = _mapper.Map<Patient>(dto);
        await _patientRepository.UpdateAsync(patient, cancellationToken);
    }
}
