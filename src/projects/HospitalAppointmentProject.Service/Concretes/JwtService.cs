using Core.Security.Entities;
using Core.Security.JWT;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointmentProject.Service.Concretes;

public sealed class JwtService : IJwtService
{
    private ITokenHelper _tokenHelper;
    private IUserRoleRepository _userRoleRepository;

    public JwtService(ITokenHelper tokenHelper, IUserRoleRepository userRoleRepository)
    {
        _tokenHelper = tokenHelper;
        _userRoleRepository = userRoleRepository;
    }

    public async Task<AccessToken> CreateAccessTokenAsync(User user)
    {
        List<Role> roles = await _userRoleRepository.Query()
            .AsNoTracking()
            .Where(u => u.Id == user.Id)
            .Select(r => new Role { Id = r.Id, Name = r.Role.Name })
            .ToListAsync();

        AccessToken accessToken = _tokenHelper.CreateToken(user, roles);
        return accessToken;
    }
}
