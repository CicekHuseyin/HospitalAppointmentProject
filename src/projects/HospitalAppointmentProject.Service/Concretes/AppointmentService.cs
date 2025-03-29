using AutoMapper;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Model.Dtos.Appointments;
using HospitalAppointmentProject.Model.Entities;
using HospitalAppointmentProject.Service.Abstracts;
using HospitalAppointmentProject.Service.BusinessRules.Appointments;
using HospitalAppointmentProject.Service.Constants.Appointments;
using HospitalAppointmentProject.Service.Validators;

namespace HospitalAppointmentProject.Service.Concretes;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;
    private readonly AppointmentBusinessRules _businessRules;
    private readonly AppointmentValidator _validationRules;
    private readonly IValidationService _validationService;

    public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper, AppointmentBusinessRules businessRules, AppointmentValidator validationRules, IValidationService validationService)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
        _businessRules = businessRules;
        _validationRules = validationRules;
        _validationService = validationService;
    }

    public async Task<string> AddAsync(AppointmentAddRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _validationService.ValidateAsync(_validationRules, dto);
        await _businessRules.CheckPatientAppointmentLimitAsync(dto.PatientId,dto.DoctorId,dto.AppointmentDate);
        Appointment appointment = _mapper.Map<Appointment>(dto);
        await _appointmentRepository.AddAsync(appointment);
        return AppointmentMessages.AppointmentAddedMessage;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _businessRules.AppointmentIsPresentAsync(id);

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
        await _businessRules.AppointmentIsPresentAsync(id);
        Appointment appointment = await _appointmentRepository.GetAsync(filter: x => x.Id == id, enableTracking: false, cancellationToken: cancellationToken);
        var appointmentResponseDtos = _mapper.Map<AppointmentResponseDto>(appointment);
        return appointmentResponseDtos;
    }

    public async Task UpdateAsync(AppointmentUpdateRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _businessRules.AppointmentIsPresentAsync(dto.Id);
        ////Movie movie = await _movieRepository.GetAsync(filter: x => x.Id == dto.Id, include: false, cancellationToken: cancellationToken);
        Appointment appointment = _mapper.Map<Appointment>(dto);
        await _appointmentRepository.UpdateAsync(appointment, cancellationToken);
    }
}
