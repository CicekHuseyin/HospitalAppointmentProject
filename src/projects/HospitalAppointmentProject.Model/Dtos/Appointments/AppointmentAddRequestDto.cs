namespace HospitalAppointmentProject.Model.Dtos.Appointments;

public sealed class AppointmentAddRequestDto
{
    public int PatientId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string? Notes { get; set; }
}
