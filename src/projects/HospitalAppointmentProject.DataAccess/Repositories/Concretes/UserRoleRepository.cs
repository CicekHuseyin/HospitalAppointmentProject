using Core.DataAccess.Repositories;
using Core.Security.Entities;
using HospitalAppointmentProject.DataAccess.Contexts;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Model.Entities;

namespace HospitalAppointmentProject.DataAccess.Repositories.Concretes
{
    public sealed class UserRoleRepository : EfRepositoryBase<UserRole, int, BaseDbContext>, IUserRoleRepository
    {
        public UserRoleRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
