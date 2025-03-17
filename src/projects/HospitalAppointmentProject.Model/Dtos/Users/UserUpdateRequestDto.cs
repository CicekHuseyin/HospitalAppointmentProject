namespace HospitalAppointmentProject.Model.Dtos.Users;

public sealed class UserUpdateRequestDto
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public string? PasswordSalt { get; set; }
}
