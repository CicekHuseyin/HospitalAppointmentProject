namespace HospitalAppointmentProject.Model.Dtos.Patients;

public sealed class PatientAddRequestDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
}
