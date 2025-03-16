using Core.DataAccess.Entities;

namespace HospitalAppointmentProject.Model.Entities;

public sealed class Appointment : Entity<int>
{
    public Appointment()
    {
        Patient = new Patient();
        AppointmentDate = DateTime.Now;
        Notes = string.Empty;
    }

    public Doctor Doctor { get; set; }

    public int PatientId { get; set; }
    public Patient Patient { get; set; }

    public DateTime AppointmentDate { get; set; }
    public string Notes { get; set; }
}
