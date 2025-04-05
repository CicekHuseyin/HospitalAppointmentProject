using Core.CrossCuttingConcerns.Exceptions.Types;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Model.Entities;
using HospitalAppointmentProject.Service.BusinessRules.Doctors;
using HospitalAppointmentProject.Service.Constants.Doctors;
using Moq;
using NUnit.Framework;
using System;
using System.Linq.Expressions;

namespace Service.Test.BusinessRules;

public class DoctorBusinessRulesTest
{
    private DoctorBusinessRules _businessRules;
    private Mock<IDoctorRepository> _repository;

    [SetUp]
    public void SetUp()
    {
        _repository= new Mock<IDoctorRepository>();
        _businessRules = new DoctorBusinessRules(_repository.Object);
    }
    //unit test asenkron ise Task senkron ise void ile yazılmalıdır.

    //MetodunAdı_Olay_BeklenenDavranış

    [Test]
    public async Task DoctorNameMustBeUniqueAsync_WhenNameExists_ShouldThrowBusinessException()
    {
        //Arrange: Verilerin hazırlandığı yer.
        string doctorName = "Berke";
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<Doctor, bool>>>(), true, default)).ReturnsAsync(true);

        //Act:Metodun çalıştığı yer.
        var ex = Assert.ThrowsAsync<BusinessException>(() =>
        _businessRules.DoctorNameMustBeUniqueAsync(doctorName)
        );

        //Assert:Bu işlemin sonucunda beklenen seneryo

        Assert.That(ex.Message, Is.EqualTo(DoctorMessages.DoctorNameMustBeUnniqueMessage));
    }

    [Test]
    public async Task DoctorNameMustBeUniqueAsync_WhenDoesNotNameExists_ShouldNotThrowException()
    {
        // Arrange
        string doctorName = "Berke";
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<Doctor, bool>>>(), true, default))
                   .ReturnsAsync(false);

        // Act & Assert

        Assert.DoesNotThrowAsync(() => _businessRules.DoctorNameMustBeUniqueAsync(doctorName));
    }

    [Test]
    public async Task DoctorIsPresentAsync_WhenDoctorExists_ShouldNotThrowException()
    {
        // Arrange
        int doctorId = 1;
        _repository
            .Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<Doctor, bool>>>(), true, default))
            .ReturnsAsync(true);

        // Act & Assert
        Assert.DoesNotThrowAsync(() => _businessRules.DoctorIsPresentAsync(doctorId));
    }

    [Test]
    public async Task DoctorIsPresentAsync_WhenDoctorDoesNotExist_ShouldThrowBusinessException()
    {
        // Arrange
        int doctorId = 1;
        _repository
            .Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<Doctor, bool>>>(), true, default))
            .ReturnsAsync(false);

        // Act & Assert
        var exception = Assert.ThrowsAsync<BusinessException>(() =>
            _businessRules.DoctorIsPresentAsync(doctorId));

        Assert.That(exception!.Message, Is.EqualTo(DoctorMessages.DoctorNotFoundMessage));
    }

    [Test]
    public async Task CheckDoctorLimitAsync_WhenDoctorLimitNotReached_ShouldNotThrowException()
    {
        // Arrange
        int hospitalId = 1;
        string specialization = "Kardiyoloji";
        _repository
            .Setup(repo => repo.CountAsync(
                It.Is<Expression<Func<Doctor, bool>>>(expr => expr.Compile().Invoke(new Doctor { HospitalId = hospitalId, Specialty = specialization })),
                true,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(1); // Doctor sayısı 1, yani limit aşılmadı

        // Act & Assert
        Assert.DoesNotThrowAsync(() => _businessRules.CheckDoctorLimitAsync(hospitalId, specialization));
    }

    [Test]
    public async Task CheckDoctorLimitAsync_WhenDoctorLimitReached_ShouldThrowBusinessException()
    {
        // Arrange
        int hospitalId = 1;
        string specialization = "Kardiyoloji";
        _repository
            .Setup(repo => repo.CountAsync(
                It.Is<Expression<Func<Doctor, bool>>>(expr => expr.Compile().Invoke(new Doctor { HospitalId = hospitalId, Specialty = specialization })),
                true,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(2); // Doctor sayısı 2, yani limit aşılmış

        // Act & Assert
        var exception = Assert.ThrowsAsync<BusinessException>(() =>
            _businessRules.CheckDoctorLimitAsync(hospitalId, specialization));

        Assert.That(exception!.Message, Is.EqualTo(DoctorMessages.CheckDoctorLimitAsync));
    }
}
