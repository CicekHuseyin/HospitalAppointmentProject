using Core.DataAccess.Repositories;
using HospitalAppointmentProject.Model.Entities;

namespace HospitalAppointmentProject.DataAccess.Repositories.Abstracts;

public interface IUserRoleRepository : IRepository<UserRole, int>, IAsyncRepository<UserRole, int>
{
}
