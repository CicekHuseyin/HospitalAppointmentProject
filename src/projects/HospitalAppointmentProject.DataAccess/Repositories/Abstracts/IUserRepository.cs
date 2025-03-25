using Core.DataAccess.Repositories;
using Core.Security.Entities;
using HospitalAppointmentProject.Model.Entities;

namespace HospitalAppointmentProject.DataAccess.Repositories.Abstracts;

public interface IUserRepository : IRepository<User,int>,IAsyncRepository<User,int>
{
}
