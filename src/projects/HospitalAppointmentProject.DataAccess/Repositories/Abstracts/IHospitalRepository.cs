using Core.DataAccess.Repositories;
using HospitalAppointmentProject.Model.Entities;

namespace HospitalAppointmentProject.DataAccess.Repositories.Abstracts;

public interface IHospitalRepository : IRepository<Hospital,int>,IAsyncRepository<Hospital,int>
{
}
