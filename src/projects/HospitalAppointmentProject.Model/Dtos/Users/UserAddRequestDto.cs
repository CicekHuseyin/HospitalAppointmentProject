namespace HospitalAppointmentProject.Model.Dtos.Users;

public sealed class UserAddRequestDto
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
}
