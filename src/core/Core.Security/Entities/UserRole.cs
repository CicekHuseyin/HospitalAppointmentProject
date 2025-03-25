using Core.DataAccess.Entities;

namespace Core.Security.Entities;

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
