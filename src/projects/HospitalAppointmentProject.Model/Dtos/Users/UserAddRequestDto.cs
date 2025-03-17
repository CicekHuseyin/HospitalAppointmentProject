namespace HospitalAppointmentProject.Model.Dtos.Users;

public sealed class UserAddRequestDto
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public string? PasswordSalt { get; set; }
}
