using Core.DataAccess.Repositories;
using HospitalAppointmentProject.Model.Entities;

namespace HospitalAppointmentProject.DataAccess.Repositories.Abstracts;

public interface IDoctorRepository : IRepository<Doctor,int>,IAsyncRepository<Doctor,int>
{
}
