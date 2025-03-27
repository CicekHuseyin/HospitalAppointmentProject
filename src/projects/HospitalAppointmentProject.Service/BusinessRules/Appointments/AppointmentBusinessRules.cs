using Core.CrossCuttingConcerns.Exceptions.Types;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.DataAccess.Repositories.Concretes;
using HospitalAppointmentProject.Service.Constants.Appointments;
using HospitalAppointmentProject.Service.Constants.Doctors;

namespace HospitalAppointmentProject.Service.BusinessRules.Appointments;

public sealed class AppointmentBusinessRules
{
    private readonly IAppointmentRepository _iAppointmentRepository;
    private readonly AppointmentRepository _appointmentRepository;

    public AppointmentBusinessRules(IAppointmentRepository iAppointmentRepository, AppointmentRepository appointmentRepository)
    {
        _iAppointmentRepository = iAppointmentRepository;
        _appointmentRepository = appointmentRepository;
    }

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
        var isPresent = await _iAppointmentRepository.AnyAsync(x => x.Id == id);
        if (!isPresent)
        {
            throw new BusinessException(AppointmentMessages.AppointmentNotFoundMessage);
        }
    }

    public async Task CheckPatientAppointmentLimitAsync(int patientId, int doctorId, DateTime appointmentDate)
    {
        DateTime oneWeekAgo = appointmentDate.AddDays(-7);
        //Hastanın 7 gün önceki randevularını kontrol etmek için tarih aralığı oluşturduk.

        int appointmentCount = await _appointmentRepository.CountAsync(a =>
            a.PatientId == patientId &&
            a.DoctorId == doctorId &&
            a.AppointmentDate > oneWeekAgo);
        //Count Fonksiyonu:appointments tablosunda aynı hasta ve doktor için son 7 gün içinde kaç randevu var kontrol edilir.

        if (appointmentCount > 0)
        {
            throw new BusinessException(AppointmentMessages.CheckPatientAppointmentLimitAsync);
        }
    }

}
