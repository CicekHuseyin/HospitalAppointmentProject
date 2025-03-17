namespace HospitalAppointmentProject.Model.Dtos.UserRoles;

public sealed class UserRoleUpdateRequestDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
}
