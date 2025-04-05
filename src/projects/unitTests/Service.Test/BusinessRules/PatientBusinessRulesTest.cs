using Core.CrossCuttingConcerns.Exceptions.Types;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Model.Entities;
using HospitalAppointmentProject.Service.BusinessRules.Patients;
using HospitalAppointmentProject.Service.Constants.Patients;
using Moq;
using NUnit.Framework;
using System.Linq.Expressions;

namespace Service.Test.BusinessRules;

public class PatientBusinessRulesTest
{
    private PatientBusinessRules _businessRules;
    private Mock<IPatientRepository> _repository;

    [SetUp]
    public void SetUp()
    {
        _repository = new Mock<IPatientRepository>();
        _businessRules = new PatientBusinessRules(_repository.Object);
    }

    [Test]
    public async Task PatientNameMustBeUniqueAsync_WhenNameExists_ShouldThrowBusinessException()
    {
        // Arrange: Verilerin hazırlandığı yer
        string patientName = "John";
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<Patient, bool>>>(), true, default))
                   .ReturnsAsync(true);

        // Act: Metodun çalıştığı yer
        var ex = Assert.ThrowsAsync<BusinessException>(() =>
            _businessRules.PatientNameMustBeUniqueAsync(patientName)
        );

        // Assert: Beklenen hata mesajı
        Assert.That(ex.Message, Is.EqualTo(PatientMessages.PatientNameMustBeUnniqueMessage));
    }

    [Test]
    public async Task PatientNameMustBeUniqueAsync_WhenNameDoesNotExist_ShouldNotThrowException()
    {
        // Arrange: Verilerin hazırlandığı yer
        string patientName = "John";
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<Patient, bool>>>(), true, default))
                   .ReturnsAsync(false);

        // Act & Assert: Hata fırlatılmamalı
        Assert.DoesNotThrowAsync(() => _businessRules.PatientNameMustBeUniqueAsync(patientName));
    }

    [Test]
    public async Task PatientIsPresentAsync_WhenPatientExists_ShouldNotThrowException()
    {
        // Arrange: Verilerin hazırlandığı yer
        int patientId = 1;
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<Patient, bool>>>(), true, default))
                   .ReturnsAsync(true);

        // Act & Assert: Hata fırlatılmamalı
        Assert.DoesNotThrowAsync(() => _businessRules.PatientIsPresentAsync(patientId));
    }

    [Test]
    public async Task PatientIsPresentAsync_WhenPatientDoesNotExist_ShouldThrowBusinessException()
    {
        // Arrange: Verilerin hazırlandığı yer
        int patientId = 1;
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<Patient, bool>>>(), true, default))
                   .ReturnsAsync(false);

        // Act: Metodun çalıştığı yer
        var ex = Assert.ThrowsAsync<BusinessException>(() =>
            _businessRules.PatientIsPresentAsync(patientId)
        );

        // Assert: Beklenen hata mesajı
        Assert.That(ex.Message, Is.EqualTo(PatientMessages.PatientNotFoundMessage));
    }

}
