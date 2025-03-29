using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppointmentProject.Service.Validators
{
    public interface IValidationService
    {
        Task ValidateAsync<T>(IValidator<T> validator, T entity);
    }
}
