using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Entities;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Service.BusinessRules.UserRoles;
using HospitalAppointmentProject.Service.Constants.UserRoles;
using Moq;
using NUnit.Framework;
using System.Linq.Expressions;

namespace Service.Test.BusinessRules;

public class UserRoleBusinessRulesTest
{
    private UserRoleBusinessRules _businessRules;
    private Mock<IUserRoleRepository> _repository;

    [SetUp]
    public void SetUp()
    {
        _repository = new Mock<IUserRoleRepository>();
        _businessRules = new UserRoleBusinessRules(_repository.Object);
    }

    [Test]
    public async Task UserRoleIsPresentAsync_WhenUserRoleExists_ShouldNotThrowBusinessException()
    {
        // Arrange: Verilerin hazırlandığı yer
        int userRoleId = 1;
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<UserRole, bool>>>(), true, default))
                   .ReturnsAsync(true);

        // Act & Assert: Hata fırlatılmamalı
        Assert.DoesNotThrowAsync(() => _businessRules.UserRoleIsPresentAsync(userRoleId));
    }

    [Test]
    public async Task UserRoleIsPresentAsync_WhenUserRoleDoesNotExist_ShouldThrowBusinessException()
    {
        // Arrange: Verilerin hazırlandığı yer
        int userRoleId = 1;
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<UserRole, bool>>>(), true, default))
                   .ReturnsAsync(false);

        // Act: Metodun çalıştığı yer
        var ex = Assert.ThrowsAsync<BusinessException>(() =>
            _businessRules.UserRoleIsPresentAsync(userRoleId)
        );

        // Assert: Beklenen hata mesajı
        Assert.That(ex.Message, Is.EqualTo(UserRoleMessages.UserRoleNotFoundMessage));
    }


}
