using FluentValidation;
using HospitalAppointmentProject.Model.Dtos.Patients;

namespace HospitalAppointmentProject.Service.Validators;

public sealed class PatientValidator: AbstractValidator<PatientAddRequestDto>
{
    public PatientValidator()
    {
        RuleFor(p => p.FirstName)
            .NotEmpty()
            .WithMessage("Hasta adı boş geçilemez.")
            .MinimumLength(2)
            .WithMessage("Hasta adı en az 2 karakter olmalıdır.")
            .MaximumLength(50)
            .WithMessage("Hasta adı en fazla 50 karakter olabilir.")
            .Matches("^[a-zA-ZğüşıiöçĞÜŞİÖÇ\\s]+$")
            .WithMessage("Hasta adı yalnızca harflerden oluşmalıdır.");

        RuleFor(p => p.LastName)
            .NotEmpty()
            .WithMessage("Hasta soyadı boş geçilemez.")
            .MinimumLength(2)
            .WithMessage("Hasta soyadı en az 2 karakter olmalıdır.")
            .MaximumLength(50)
            .WithMessage("Hasta soyadı en fazla 50 karakter olabilir.")
            .Matches("^[a-zA-ZğüşıiöçĞÜŞİÖÇ\\s]+$")
            .WithMessage("Hasta soyadı yalnızca harflerden oluşmalıdır.");

        RuleFor(p => p.BirthDate)
            .NotNull()
            .WithMessage("Doğum tarihi boş olamaz.")
            .LessThan(DateTime.Now)
            .WithMessage("Doğum tarihi gelecekte bir tarih olamaz.")
            .GreaterThan(DateTime.Now.AddYears(-120))
            .WithMessage("Hasta yaşı 120 yıldan büyük olamaz.");
    }
}
