using HospitalAppointmentProject.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HospitalAppointmentProject.DataAccess.Contexts;

public sealed class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions opt) : base(opt)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
}
