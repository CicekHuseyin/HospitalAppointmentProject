using Core.CrossCuttingConcerns.Exceptions.Types;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.DataAccess.Repositories.Concretes;
using HospitalAppointmentProject.Service.Constants.Patients;
using HospitalAppointmentProject.Service.Constants.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppointmentProject.Service.BusinessRules.Users
{
    public sealed class UserBusinessRules(IUserRepository userRepository)
    {
        public async Task UserNameMustBeUniqueAsync(string name)
        {
            var isPresent = await userRepository.AnyAsync(x => x.Username == name.ToLower());
            if (isPresent)
            {
                throw new BusinessException(UsersMessages.UserNameMustBeUnniqueMessage);
            }
        }

        public async Task UserIsPresentAsync(int id)
        {
            var isPresent = await userRepository.AnyAsync(x => x.Id == id);
            if (!isPresent)
            {
                throw new BusinessException(UsersMessages.UserNotFoundMessage);
            }
        }
    }
}
