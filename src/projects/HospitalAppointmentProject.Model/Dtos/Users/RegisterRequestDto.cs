﻿namespace HospitalAppointmentProject.Model.Dtos.Users;

public sealed class RegisterRequestDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? UserName { get; set; }
}
