using Core.DataAccess.Repositories;
using HospitalAppointmentProject.DataAccess.Contexts;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HospitalAppointmentProject.DataAccess.Repositories.Concretes;

public sealed class AppointmentRepository : EfRepositoryBase<Appointment, int, BaseDbContext>, IAppointmentRepository
{
    public AppointmentRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<int> CountAsync(Expression<Func<Appointment, bool>> predicate)
    {
        return await Context.Appointments
                             .Where(predicate)
                             .CountAsync();
    }
}
