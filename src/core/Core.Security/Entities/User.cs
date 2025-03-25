using Core.DataAccess.Entities;

namespace Core.Security.Entities;

public sealed class User : Entity<int>
{
    public User()
    {
        Username = string.Empty;
        Email = string.Empty;
        PasswordHash = Array.Empty<byte>();
        PasswordSalt = Array.Empty<byte>();
        UserRoles = new List<UserRole>();
    }

    public string Username { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; } 
    public byte[] PasswordSalt { get; set; } 

    public ICollection<UserRole> UserRoles { get; set; }
}
