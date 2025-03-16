using Core.DataAccess.Entities;

namespace HospitalAppointmentProject.Model.Entities;

public sealed class UserRole : Entity<int>
{
    public UserRole()
    {
        User=new User();
        Role=new Role();
    }

    public int UserId { get; set; }
    public User User { get; set; }

    public int RoleId { get; set; }
    public Role Role { get; set; }
}
