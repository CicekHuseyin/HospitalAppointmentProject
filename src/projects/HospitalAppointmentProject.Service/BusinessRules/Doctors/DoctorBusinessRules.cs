using Core.CrossCuttingConcerns.Exceptions.Types;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.DataAccess.Repositories.Concretes;
using HospitalAppointmentProject.Service.Constants.Doctors;

namespace HospitalAppointmentProject.Service.BusinessRules.Doctors
{
    public sealed class DoctorBusinessRules
    {
        private readonly IDoctorRepository _iDoctorRepository;

        public DoctorBusinessRules(IDoctorRepository iDoctorRepository)
        {
            _iDoctorRepository = iDoctorRepository;
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
            int doctorCount = await _iDoctorRepository
                .CountAsync(d => d.HospitalId == hospitalId && d.Specialty.ToUpper() == specialization.ToUpper());

            if (doctorCount >= 2)
            {
                throw new BusinessException(DoctorMessages.CheckDoctorLimitAsync);
            }
        }

    }
}
