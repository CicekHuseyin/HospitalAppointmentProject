namespace HospitalAppointmentProject.Model.Dtos.Roles;

public sealed class RoleUpdateRequestDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}
