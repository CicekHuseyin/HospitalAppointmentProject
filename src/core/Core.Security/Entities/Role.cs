using Core.DataAccess.Entities;

namespace Core.Security.Entities;

public class Role : Entity<int>
{
    public Role()
    {
        Name = string.Empty;
        Description = string.Empty;
        UserRoles = new List<UserRole>();
    }

    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
}
