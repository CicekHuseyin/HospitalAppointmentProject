using Core.DataAccess.Repositories;
using HospitalAppointmentProject.Model.Entities;

namespace HospitalAppointmentProject.DataAccess.Repositories.Abstracts;

public interface IAppointmentRepository : IRepository<Appointment,int>,IAsyncRepository<Appointment,int>
{
}
