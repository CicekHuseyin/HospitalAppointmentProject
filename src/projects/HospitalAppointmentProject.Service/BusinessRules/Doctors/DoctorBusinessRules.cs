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
        private readonly IDoctorRepository _ıDoctorRepository;
        private readonly DoctorRepository _doctorRepository;

        public DoctorBusinessRules(IDoctorRepository ıDoctorRepository, DoctorRepository doctorRepository)
        {
            _ıDoctorRepository = doctorRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task DoctorNameMustBeUniqueAsync(string name)
        {
            var isPresent = await _ıDoctorRepository.AnyAsync(x => x.FirstName == name.ToLower());
            if (isPresent)
            {
                throw new BusinessException(DoctorMessages.DoctorNameMustBeUnniqueMessage);
            }
        }

        public async Task DoctorIsPresentAsync(int id)
        {
            var isPresent = await _ıDoctorRepository.AnyAsync(x => x.Id == id);
            if (!isPresent)
            {
                throw new BusinessException(DoctorMessages.DoctorNotFoundMessage);
            }
        }

        public async Task CheckDoctorLimitAsync(int hospitalId, int specializationId)
        {
            int doctorCount = await _doctorRepository
                .CountAsync(d => d.HospitalId == hospitalId && d.Id == specializationId);

            if (doctorCount >= 2)
            {
                throw new BusinessException($"Bu hastanede {doctorCount} adet {specializationId} uzmanına sahip doktor bulunmaktadır. En fazla 10 doktor eklenebilir.");
            }
        }
    }
}
