using Core.DataAccess.Repositories;
using Core.Security.Entities;
using HospitalAppointmentProject.DataAccess.Contexts;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;

namespace HospitalAppointmentProject.DataAccess.Repositories.Concretes;

public sealed class RoleRepository : EfRepositoryBase<Role, int, BaseDbContext>, IRoleRepository
{
    public RoleRepository(BaseDbContext context) : base(context)
    {
    }
}
