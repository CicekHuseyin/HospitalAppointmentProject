using Core.DataAccess.Repositories;
using HospitalAppointmentProject.Model.Entities;

namespace HospitalAppointmentProject.DataAccess.Repositories.Abstracts;

public interface IPatientRepository : IRepository<Patient, int>, IAsyncRepository<Patient, int>
{
}
