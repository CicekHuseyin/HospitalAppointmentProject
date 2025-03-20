using Core.DataAccess.Repositories;
using HospitalAppointmentProject.DataAccess.Contexts;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Model.Entities;

namespace HospitalAppointmentProject.DataAccess.Repositories.Concretes;

public sealed class HospitalRepository : EfRepositoryBase<Hospital, int, BaseDbContext>, IHospitalRepository
{
    public HospitalRepository(BaseDbContext context) : base(context)
    {
    }
}
