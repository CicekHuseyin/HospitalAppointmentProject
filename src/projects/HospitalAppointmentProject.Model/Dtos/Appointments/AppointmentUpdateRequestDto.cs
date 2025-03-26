namespace HospitalAppointmentProject.Model.Dtos.Appointments;

public sealed class AppointmentUpdateRequestDto
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string? Notes { get; set; }
}
