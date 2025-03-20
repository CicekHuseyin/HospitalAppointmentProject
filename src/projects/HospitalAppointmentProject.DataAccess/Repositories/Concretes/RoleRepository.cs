using Core.DataAccess.Repositories;
using HospitalAppointmentProject.DataAccess.Contexts;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Model.Entities;

namespace HospitalAppointmentProject.DataAccess.Repositories.Concretes;

public sealed class RoleRepository : EfRepositoryBase<Role, int, BaseDbContext>, IRoleRepository
{
    public RoleRepository(BaseDbContext context) : base(context)
    {
    }
}
