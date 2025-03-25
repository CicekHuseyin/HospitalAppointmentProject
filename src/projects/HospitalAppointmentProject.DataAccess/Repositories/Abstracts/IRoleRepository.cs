using Core.DataAccess.Repositories;
using Core.Security.Entities;
using HospitalAppointmentProject.Model.Entities;

namespace HospitalAppointmentProject.DataAccess.Repositories.Abstracts;

public interface IRoleRepository : IRepository<Role, int>, IAsyncRepository<Role, int>
{
}

