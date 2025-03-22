using Core.CrossCuttingConcerns.Exceptions.Types;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Service.Constants.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppointmentProject.Service.BusinessRules.Doctors
{
    public sealed class DoctorBusinessRules(IDoctorRepository doctorRepository)
    {
        public async Task DoctorNameMustBeUniqueAsync(string name)
        {
            var isPresent = await doctorRepository.AnyAsync(x => x.FirstName == name.ToLower());
            if (isPresent)
            {
                throw new BusinessException(DoctorMessages.DoctorNameMustBeUnniqueMessage);
            }
        }

        public async Task DoctorIsPresentAsync(int id)
        {
            var isPresent = await doctorRepository.AnyAsync(x => x.Id == id);
            if (!isPresent)
            {
                throw new BusinessException(DoctorMessages.DoctorNotFoundMessage);
            }
        }
    }
}
