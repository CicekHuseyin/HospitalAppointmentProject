using Core.CrossCuttingConcerns.Exceptions.Types;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.DataAccess.Repositories.Concretes;
using HospitalAppointmentProject.Service.Constants.Hospitals;
using HospitalAppointmentProject.Service.Constants.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppointmentProject.Service.BusinessRules.Patients
{
    public sealed class PatientBusinessRules(IPatientRepository patientRepository)
    {
        public async Task PatientNameMustBeUniqueAsync(string name)
        {
            var isPresent = await patientRepository.AnyAsync(x => x.FirstName == name.ToLower());
            if (isPresent)
            {
                throw new BusinessException(PatientMessages.PatientNameMustBeUnniqueMessage);
            }
        }

        public async Task PatientIsPresentAsync(int id)
        {
            var isPresent = await patientRepository.AnyAsync(x => x.Id == id);
            if (!isPresent)
            {
                throw new BusinessException(PatientMessages.PatientNotFoundMessage);
            }
        }
    }
}
