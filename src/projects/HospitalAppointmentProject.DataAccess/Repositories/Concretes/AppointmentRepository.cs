using Core.DataAccess.Repositories;
using HospitalAppointmentProject.DataAccess.Contexts;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Model.Entities;

namespace HospitalAppointmentProject.DataAccess.Repositories.Concretes;

public sealed class AppointmentRepository : EfRepositoryBase<Appointment, int, BaseDbContext>, IAppointmentRepository
{
    public AppointmentRepository(BaseDbContext context) : base(context)
    {
    }
}
