using FluentValidation;
using HospitalAppointmentProject.Model.Dtos.Appointments;

namespace HospitalAppointmentProject.Service.Validators;

public sealed class AppointmentValidator :AbstractValidator<AppointmentAddRequestDto>
{
    public AppointmentValidator()
    {
        RuleFor(a => a.DoctorId)
            .GreaterThan(0)
            .WithMessage("Geçerli bir doktor ID giriniz.");

        RuleFor(a => a.PatientId)
            .GreaterThan(0)
            .WithMessage("Geçerli bir hasta ID giriniz.");

        RuleFor(a => a.AppointmentDate)
            .GreaterThan(DateTime.Now)
            .WithMessage("Randevu tarihi geçmiş bir tarih olamaz.");

        RuleFor(a => a.Notes)
            .MaximumLength(500)
            .WithMessage("Notlar en fazla 500 karakter olabilir.");
    }
}
