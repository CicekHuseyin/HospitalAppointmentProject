using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppointmentProject.Service.Validators
{
    public sealed class ValidationService : IValidationService
    {
        public async Task ValidateAsync<T>(IValidator<T> validator, T entity)
        {
            var validationResult = await validator.ValidateAsync(entity);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }
        }
    }
}
