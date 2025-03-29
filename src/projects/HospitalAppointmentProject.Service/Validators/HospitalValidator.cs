using FluentValidation;
using HospitalAppointmentProject.Model.Dtos.Hospitals;

namespace HospitalAppointmentProject.Service.Validators;

public sealed class HospitalValidator : AbstractValidator<HospitalAddRequestDto>
{
    public HospitalValidator()
    {
        RuleFor(h => h.Name)
            .NotEmpty()
            .WithMessage("Hastane adı boş geçilemez.")
            .MinimumLength(3)
            .WithMessage("Hastane adı en az 3 karakter olmalıdır.")
            .MaximumLength(100)
            .WithMessage("Hastane adı en fazla 100 karakter olabilir.")
            .Matches("^[a-zA-ZğüşıiöçĞÜŞİÖÇ\\s]+$")
            .WithMessage("Hastane adı yalnızca harflerden oluşmalıdır.");

        RuleFor(h => h.Address)
            .NotEmpty()
            .WithMessage("Adres boş geçilemez.")
            .MinimumLength(10)
            .WithMessage("Adres en az 10 karakter olmalıdır.")
            .MaximumLength(200)
            .WithMessage("Adres en fazla 200 karakter olabilir.");

        RuleFor(h => h.City)
            .NotEmpty()
            .WithMessage("Şehir adı boş geçilemez.")
            .MinimumLength(3)
            .WithMessage("Şehir adı en az 3 karakter olmalıdır.")
            .MaximumLength(50)
            .WithMessage("Şehir adı en fazla 50 karakter olabilir.")
            .Matches("^[a-zA-ZğüşıiöçĞÜŞİÖÇ\\s]+$")
            .WithMessage("Şehir adı yalnızca harflerden oluşmalıdır.");
    }
}
