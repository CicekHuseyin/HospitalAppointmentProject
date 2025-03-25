using HospitalAppointmentProject.DataAccess.Contexts;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.DataAccess.Repositories.Concretes;
using HospitalAppointmentProject.Service.Abstracts;
using HospitalAppointmentProject.Service.BusinessRules.Doctors;
using HospitalAppointmentProject.Service.BusinessRules.Hospitals;
using HospitalAppointmentProject.Service.BusinessRules.Patients;
using HospitalAppointmentProject.Service.BusinessRules.Users;
using HospitalAppointmentProject.Service.Concretes;
using HospitalAppointmentProject.Service.Mappers.Profiles;
using HospitalDoctorProject.Service.Abstracts;
using HospitalDoctorProject.Service.Concretes;
using Microsoft.EntityFrameworkCore;
using PatientAppointmentProject.Service.Concretes;
using RoleAppointmentProject.Service.Concretes;
using System.Reflection;
using UserAppointmentProject.Service.Concretes;
using UserRoleAppointmentProject.Service.Concretes;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<BaseDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IHospitalService, HospitalService>();
builder.Services.AddScoped<IHospitalRepository, HospitalRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();


builder.Services.AddScoped<DoctorBusinessRules>();
builder.Services.AddScoped<HospitalBusinessRules>();
builder.Services.AddScoped<PatientBusinessRules>();
builder.Services.AddScoped<UserBusinessRules>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
