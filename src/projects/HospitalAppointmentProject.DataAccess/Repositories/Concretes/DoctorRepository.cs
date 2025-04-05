using Core.DataAccess.Repositories;
using HospitalAppointmentProject.DataAccess.Contexts;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HospitalAppointmentProject.DataAccess.Repositories.Concretes;

public sealed class DoctorRepository : EfRepositoryBase<Doctor, int, BaseDbContext>, IDoctorRepository
{
    public DoctorRepository(BaseDbContext context) : base(context)
    {

    }
}
