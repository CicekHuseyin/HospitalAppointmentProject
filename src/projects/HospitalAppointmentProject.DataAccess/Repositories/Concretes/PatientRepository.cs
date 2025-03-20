using Core.DataAccess.Repositories;
using HospitalAppointmentProject.DataAccess.Contexts;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Model.Entities;

namespace HospitalAppointmentProject.DataAccess.Repositories.Concretes;

public sealed class PatientRepository : EfRepositoryBase<Patient, int, BaseDbContext>, IPatientRepository
{
    public PatientRepository(BaseDbContext context) : base(context)
    {
    }
}
