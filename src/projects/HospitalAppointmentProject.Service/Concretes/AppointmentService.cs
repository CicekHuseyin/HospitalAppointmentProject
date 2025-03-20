using AutoMapper;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Model.Dtos.Appointments;
using HospitalAppointmentProject.Model.Entities;
using HospitalAppointmentProject.Service.Abstracts;

namespace HospitalAppointmentProject.Service.Concretes;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;

    public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }

    public async Task<string> AddAsync(AppointmentAddRequestDto dto, CancellationToken cancellationToken = default)
    {
        //await _businessRules.MovieTitleMustBeUniqueAsync(dto.Name);
        Appointment appointment = _mapper.Map<Appointment>(dto);
        await _appointmentRepository.AddAsync(appointment);
        return "Buraya Business Roles gelecek";
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        //await _businessRules.MovieIsPresentAsync(id);

        Appointment appointment = await _appointmentRepository.GetAsync(filter: x => x.Id == id, include: false, cancellationToken: cancellationToken);

        await _appointmentRepository.DeleteAsync(appointment, cancellationToken);
    }

    public async Task<List<AppointmentResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        List<Appointment> appointments = await _appointmentRepository.GetAllAsync(enableTracking: false, cancellationToken: cancellationToken);
        var appointmentResponseDtos = _mapper.Map<List<AppointmentResponseDto>>(appointments);
        return appointmentResponseDtos;
    }

    public async Task<AppointmentResponseDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        //await _businessRules.MovieIsPresentAsync(id);
        Appointment appointment = await _appointmentRepository.GetAsync(filter: x => x.Id == id, enableTracking: false, cancellationToken: cancellationToken);
        var appointmentResponseDtos = _mapper.Map<AppointmentResponseDto>(appointment);
        return appointmentResponseDtos;
    }

    public async Task UpdateAsync(AppointmentUpdateRequestDto dto, CancellationToken cancellationToken = default)
    {
        //await _businessRules.MovieIsPresentAsync(dto.Id);
        ////Movie movie = await _movieRepository.GetAsync(filter: x => x.Id == dto.Id, include: false, cancellationToken: cancellationToken);
        Appointment appointment = _mapper.Map<Appointment>(dto);
        await _appointmentRepository.UpdateAsync(appointment, cancellationToken);
    }
}
