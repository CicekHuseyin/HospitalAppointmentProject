using AutoMapper;
using HospitalAppointmentProject.Model.Dtos.Appointments;
using HospitalAppointmentProject.Model.Dtos.Doctors;
using HospitalAppointmentProject.Model.Dtos.Hospitals;
using HospitalAppointmentProject.Model.Dtos.Patients;
using HospitalAppointmentProject.Model.Dtos.Roles;
using HospitalAppointmentProject.Model.Dtos.UserRoles;
using HospitalAppointmentProject.Model.Dtos.Users;
using HospitalAppointmentProject.Model.Entities;

namespace HospitalAppointmentProject.Service.Mappers.Profiles;

public sealed class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<AppointmentAddRequestDto, Appointment>();
        CreateMap<AppointmentUpdateRequestDto, Appointment>();
        CreateMap<Appointment, AppointmentResponseDto>();

        CreateMap<DoctorAddRequestDto, Doctor>();
        CreateMap<DoctorUpdateRequestDto, Doctor>();
        CreateMap<Doctor, DoctorResponseDto>();

        CreateMap<HospitalAddRequestDto, Hospital>();
        CreateMap<HospitalUpdateRequestDto, Hospital>();
        CreateMap<Hospital, HospitalResponseDto>();

        CreateMap<PatientAddRequestDto, Patient>();
        CreateMap<PatientUpdateRequestDto, Patient>();
        CreateMap<Patient, PatientResponseDto>();

        CreateMap<RoleAddRequestDto, Role>();
        CreateMap<RoleUpdateRequestDto, Role>();
        CreateMap<Role, RoleResponseDto>();

        CreateMap<UserRoleAddRequestDto, UserRole>();
        CreateMap<UserRoleUpdateRequestDto, UserRole>();
        CreateMap<UserRole, UserRoleResponseDto>();

        CreateMap<UserAddRequestDto, User>();
        CreateMap<UserUpdateRequestDto, User>();
        CreateMap<User, UserResponseDto>();

        CreateMap<RegisterRequestDto, User>();


    }
}
