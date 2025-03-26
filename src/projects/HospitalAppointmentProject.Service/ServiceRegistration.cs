using HospitalAppointmentProject.Model.Entities;
using HospitalAppointmentProject.Service.Abstracts;
using HospitalAppointmentProject.Service.BusinessRules.Appointments;
using HospitalAppointmentProject.Service.BusinessRules.Doctors;
using HospitalAppointmentProject.Service.BusinessRules.Hospitals;
using HospitalAppointmentProject.Service.BusinessRules.Patients;
using HospitalAppointmentProject.Service.BusinessRules.Roles;
using HospitalAppointmentProject.Service.BusinessRules.UserRoles;
using HospitalAppointmentProject.Service.BusinessRules.Users;
using HospitalAppointmentProject.Service.Concretes;
using HospitalDoctorProject.Service.Abstracts;
using HospitalDoctorProject.Service.Concretes;
using Microsoft.Extensions.DependencyInjection;
using PatientAppointmentProject.Service.Concretes;
using RoleAppointmentProject.Service.Concretes;
using System.Reflection;
using UserAppointmentProject.Service.Concretes;
using UserRoleAppointmentProject.Service.Concretes;

namespace HospitalAppointmentProject.Service;

public static class ServiceRegistration
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IHospitalService, HospitalService>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<DoctorBusinessRules>();
        services.AddScoped<HospitalBusinessRules>();
        services.AddScoped<PatientBusinessRules>();
        services.AddScoped<UserBusinessRules>();
        services.AddScoped<AppointmentBusinessRules>();
        services.AddScoped<RoleBusinessRules>();
        services.AddScoped<UserBusinessRules>();
        services.AddScoped<UserRoleBusinessRules>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IJwtService,JwtService>();
        return services;
    }
}
