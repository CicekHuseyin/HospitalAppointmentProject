
using Core.CrossCuttingConcerns.Exceptions.Types;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Model.Entities;
using HospitalAppointmentProject.Service.BusinessRules.Doctors;
using HospitalAppointmentProject.Service.BusinessRules.Hospitals;
using HospitalAppointmentProject.Service.Constants.Hospitals;
using Moq;
using NUnit.Framework;
using System.Linq.Expressions;

namespace Service.Test.BusinessRules;

public class HospitalBusinessRulesTest
{
    private HospitalBusinessRules _businessRules;
    private Mock<IHospitalRepository> _repository;

    [SetUp]
    public void SetUp()
    {
        _repository = new Mock<IHospitalRepository>();
        _businessRules = new HospitalBusinessRules(_repository.Object);
    }

    [Test]
    public async Task HospitalNameMustBeUniqueAsync_WhenNameExists_ShouldThrowBusinessException()
    {
        // Arrange: Verilerin hazırlandığı yer
        string hospitalName = "City Hospital";
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<Hospital, bool>>>(), true, default))
                   .ReturnsAsync(true);

        // Act: Metodun çalıştığı yer
        var ex = Assert.ThrowsAsync<BusinessException>(() =>
            _businessRules.HospitalNameMustBeUniqueAsync(hospitalName)
        );

        // Assert: Beklenen hata mesajı
        Assert.That(ex.Message, Is.EqualTo(HospitalMessages.HospitalNameMustBeUnniqueMessage));
    }

    [Test]
    public async Task HospitalNameMustBeUniqueAsync_WhenNameDoesNotExist_ShouldNotThrowException()
    {
        // Arrange: Verilerin hazırlandığı yer
        string hospitalName = "City Hospital";
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<Hospital, bool>>>(), true, default))
                   .ReturnsAsync(false);

        // Act & Assert: Hata fırlatılmamalı
        Assert.DoesNotThrowAsync(() => _businessRules.HospitalNameMustBeUniqueAsync(hospitalName));
    }

    [Test]
    public async Task HopitalIsPresentAsync_WhenHospitalExists_ShouldNotThrowException()
    {
        // Arrange: Verilerin hazırlandığı yer
        int hospitalId = 1;
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<Hospital, bool>>>(), true, default))
                   .ReturnsAsync(true);

        // Act & Assert: Hata fırlatılmamalı
        Assert.DoesNotThrowAsync(() => _businessRules.HopitalIsPresentAsync(hospitalId));
    }

    [Test]
    public async Task HopitalIsPresentAsync_WhenHospitalDoesNotExist_ShouldThrowBusinessException()
    {
        // Arrange: Verilerin hazırlandığı yer
        int hospitalId = 1;
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<Hospital, bool>>>(), true, default))
                   .ReturnsAsync(false);

        // Act: Metodun çalıştığı yer
        var ex = Assert.ThrowsAsync<BusinessException>(() =>
            _businessRules.HopitalIsPresentAsync(hospitalId)
        );

        // Assert: Beklenen hata mesajı
        Assert.That(ex.Message, Is.EqualTo(HospitalMessages.HospitalNotFoundMessage));
    }

}
