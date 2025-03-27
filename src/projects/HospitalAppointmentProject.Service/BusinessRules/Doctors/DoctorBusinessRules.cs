using Core.CrossCuttingConcerns.Exceptions.Types;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.DataAccess.Repositories.Concretes;
using HospitalAppointmentProject.Service.Constants.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppointmentProject.Service.BusinessRules.Doctors
{
    public sealed class DoctorBusinessRules
    {
        private readonly IDoctorRepository _iDoctorRepository;
        private readonly DoctorRepository _doctorRepository;

        public DoctorBusinessRules(IDoctorRepository iDoctorRepository, DoctorRepository doctorRepository)
        {
            _iDoctorRepository = doctorRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task DoctorNameMustBeUniqueAsync(string name)
        {
            var isPresent = await _iDoctorRepository.AnyAsync(x => x.FirstName == name.ToLower());
            if (isPresent)
            {
                throw new BusinessException(DoctorMessages.DoctorNameMustBeUnniqueMessage);
            }
        }

        public async Task DoctorIsPresentAsync(int id)
        {
            var isPresent = await _iDoctorRepository.AnyAsync(x => x.Id == id);
            if (!isPresent)
            {
                throw new BusinessException(DoctorMessages.DoctorNotFoundMessage);
            }
        }

        public async Task CheckDoctorLimitAsync(int hospitalId, string specialization)
        {
            int doctorCount = await _doctorRepository
                .CountAsync(d => d.HospitalId == hospitalId && d.Specialty.ToUpper() == specialization.ToUpper());

            if (doctorCount >= 2)
            {
                throw new BusinessException(DoctorMessages.CheckDoctorLimitAsync);
            }
        }

    }
}
