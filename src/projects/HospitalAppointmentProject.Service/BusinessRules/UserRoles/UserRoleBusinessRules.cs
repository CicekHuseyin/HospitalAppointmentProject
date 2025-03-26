using Core.CrossCuttingConcerns.Exceptions.Types;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.DataAccess.Repositories.Concretes;
using HospitalAppointmentProject.Service.Constants.Roles;
using HospitalAppointmentProject.Service.Constants.UserRoles;

namespace HospitalAppointmentProject.Service.BusinessRules.UserRoles;

public sealed class UserRoleBusinessRules(IUserRoleRepository userRoleRepository)
{
    public async Task UserRoleIsPresentAsync(int id)
    {
        var isPresent = await userRoleRepository.AnyAsync(x => x.Id == id);
        if (!isPresent)
        {
            throw new BusinessException(UserRoleMessages.UserRoleNotFoundMessage);
        }
    }
}
