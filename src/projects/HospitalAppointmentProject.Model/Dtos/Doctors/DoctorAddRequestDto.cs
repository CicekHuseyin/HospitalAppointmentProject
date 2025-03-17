namespace HospitalAppointmentProject.Model.Dtos.Doctors;

public sealed class DoctorAddRequestDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Specialty { get; set; }

    public int HospitalId { get; set; }
}
