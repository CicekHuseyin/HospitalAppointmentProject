﻿namespace HospitalAppointmentProject.Model.Dtos.Hospitals;

public sealed class HospitalUpdateRequestDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
}
