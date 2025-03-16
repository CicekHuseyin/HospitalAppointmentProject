using Core.DataAccess.Entities;

namespace HospitalAppointmentProject.Model.Entities;

public sealed class User : Entity<int>
{
    public User()
    {
        Username = string.Empty;
        Email = string.Empty;
        PasswordHash = string.Empty;
        PasswordSalt = string.Empty;
        UserRoles = new List<UserRole>();
    }

    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
}
