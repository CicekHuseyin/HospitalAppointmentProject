using Core.CrossCuttingConcerns.Exceptions.Types;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.DataAccess.Repositories.Concretes;
using HospitalAppointmentProject.Service.Constants.Doctors;
using HospitalAppointmentProject.Service.Constants.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppointmentProject.Service.BusinessRules.Roles
{
    public sealed class RoleBusinessRules(IRoleRepository roleRepository)
    {
        public async Task RoleNameMustBeUniqueAsync(string name)
        {
            var isPresent = await roleRepository.AnyAsync(x => x.Name == name.ToLower());
            if (isPresent)
            {
                throw new BusinessException(RoleMessages.RoleNameMustBeUnniqueMessage);
            }
        }

        public async Task RoleIsPresentAsync(int id)
        {
            var isPresent = await roleRepository.AnyAsync(x => x.Id == id);
            if (!isPresent)
            {
                throw new BusinessException(RoleMessages.RoleNotFoundMessage);
            }
        }
    }
}
