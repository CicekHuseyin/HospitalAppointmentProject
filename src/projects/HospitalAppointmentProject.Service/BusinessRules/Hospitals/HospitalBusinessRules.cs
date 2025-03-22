using Core.CrossCuttingConcerns.Exceptions.Types;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.DataAccess.Repositories.Concretes;
using HospitalAppointmentProject.Service.Constants.Doctors;
using HospitalAppointmentProject.Service.Constants.Hospitals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppointmentProject.Service.BusinessRules.Hospitals
{
    public sealed class HospitalBusinessRules(IHospitalRepository hospitalRepository)
    {
        public async Task HospitalNameMustBeUniqueAsync(string name)
        {
            var isPresent = await hospitalRepository.AnyAsync(x => x.Name == name.ToLower());
            if (isPresent)
            {
                throw new BusinessException(HospitalMessages.HospitalNameMustBeUnniqueMessage);
            }
        }

        public async Task HopitalIsPresentAsync(int id)
        {
            var isPresent = await hospitalRepository.AnyAsync(x => x.Id == id);
            if (!isPresent)
            {
                throw new BusinessException(HospitalMessages.HospitalNotFoundMessage);
            }
        }
    }
}
