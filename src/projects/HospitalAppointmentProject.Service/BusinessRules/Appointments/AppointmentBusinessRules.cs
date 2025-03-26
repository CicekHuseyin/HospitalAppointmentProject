using Core.CrossCuttingConcerns.Exceptions.Types;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.DataAccess.Repositories.Concretes;
using HospitalAppointmentProject.Service.Constants.Appointments;
using HospitalAppointmentProject.Service.Constants.Doctors;

namespace HospitalAppointmentProject.Service.BusinessRules.Appointments;

public sealed class AppointmentBusinessRules(IAppointmentRepository appointmentRepository)
{
    //public async Task AppointmentNameMustBeUniqueAsync(string name)
    //{
    //    var isPresent = await appointmentRepository.AnyAsync(x => x.Notes == name.ToLower());
    //    if (isPresent)
    //    {
    //        throw new BusinessException(DoctorMessages.DoctorNameMustBeUnniqueMessage);
    //    }
    //}

    public async Task AppointmentIsPresentAsync(int id)
    {
        var isPresent = await appointmentRepository.AnyAsync(x => x.Id == id);
        if (!isPresent)
        {
            throw new BusinessException(AppointmentMessages.AppointmentNotFoundMessage);
        }
    }
}
