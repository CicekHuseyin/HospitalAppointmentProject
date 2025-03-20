using AutoMapper;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Model.Dtos.Doctors;
using HospitalAppointmentProject.Model.Entities;

namespace HospitalDoctorProject.Service.Concretes;

public class DoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMapper _mapper;

    public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
    }

    public async Task<string> AddAsync(DoctorAddRequestDto dto, CancellationToken cancellationToken = default)
    {
        //await _businessRules.MovieTitleMustBeUniqueAsync(dto.Name);
        Doctor doctor = _mapper.Map<Doctor>(dto);
        await _doctorRepository.AddAsync(doctor);
        return "Buraya Business Roles gelecek";
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        //await _businessRules.MovieIsPresentAsync(id);

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
        //await _businessRules.MovieIsPresentAsync(id);
        Doctor doctor = await _doctorRepository.GetAsync(filter: x => x.Id == id, enableTracking: false, cancellationToken: cancellationToken);
        var doctorResponseDtos = _mapper.Map<DoctorResponseDto>(doctor);
        return doctorResponseDtos;
    }

    public async Task UpdateAsync(DoctorUpdateRequestDto dto, CancellationToken cancellationToken = default)
    {
        //await _businessRules.MovieIsPresentAsync(dto.Id);
        ////Movie movie = await _movieRepository.GetAsync(filter: x => x.Id == dto.Id, include: false, cancellationToken: cancellationToken);
        Doctor doctor = _mapper.Map<Doctor>(dto);
        await _doctorRepository.UpdateAsync(doctor, cancellationToken);
    }
}
