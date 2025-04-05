using Core.CrossCuttingConcerns.Exceptions.Types;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Service.Constants.Hospitals;

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
