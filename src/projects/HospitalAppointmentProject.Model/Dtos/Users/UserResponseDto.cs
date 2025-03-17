namespace HospitalAppointmentProject.Model.Dtos.Users;

public sealed class UserResponseDto
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public string? PasswordSalt { get; set; }
}
