using FluentValidation;
using HospitalAppointmentProject.Model.Dtos.Doctors;
using HospitalAppointmentProject.Model.Dtos.Hospitals;

namespace HospitalAppointmentProject.Service.Validators;

public sealed class DoctorValidator : AbstractValidator<DoctorAddRequestDto>
{
    public DoctorValidator()
    {
        RuleFor(d => d.FirstName)
            .NotEmpty()
            .WithMessage("Doktor adı boş geçilemez.")
            .MinimumLength(2)
            .WithMessage("Doktor adı en az 2 karakter olmalıdır.")
            .MaximumLength(50)
            .WithMessage("Doktor adı en fazla 50 karakter olabilir.")
            .Matches("^[a-zA-ZğüşıiöçĞÜŞİÖÇ\\s]+$")
            .WithMessage("Doktor adı yalnızca harflerden oluşmalıdır.");

        RuleFor(d => d.LastName)
            .NotEmpty()
            .WithMessage("Doktor soyadı boş geçilemez.")
            .MinimumLength(2)
            .WithMessage("Doktor soyadı en az 2 karakter olmalıdır.")
            .MaximumLength(50)
            .WithMessage("Doktor soyadı en fazla 50 karakter olabilir.")
            .Matches("^[a-zA-ZğüşıiöçĞÜŞİÖÇ\\s]+$")
            .WithMessage("Doktor soyadı yalnızca harflerden oluşmalıdır.");

        RuleFor(d => d.Specialty)
            .NotEmpty()
            .WithMessage("Uzmanlık alanı boş geçilemez.")
            .MinimumLength(3)
            .WithMessage("Uzmanlık alanı en az 3 karakter olmalıdır.")
            .MaximumLength(100)
            .WithMessage("Uzmanlık alanı en fazla 100 karakter olabilir.");

        RuleFor(d => d.HospitalId)
            .GreaterThan(0)
            .WithMessage("Geçerli bir Hastane ID giriniz.");
    }
}
