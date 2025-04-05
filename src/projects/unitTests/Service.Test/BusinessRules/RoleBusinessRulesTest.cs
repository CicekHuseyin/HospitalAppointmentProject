using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Entities;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Service.BusinessRules.Roles;
using HospitalAppointmentProject.Service.Constants.Roles;
using Moq;
using NUnit.Framework;
using System.Linq.Expressions;

namespace Service.Test.BusinessRules;

public class RoleBusinessRulesTest
{
    private RoleBusinessRules _businessRules;
    private Mock<IRoleRepository> _repository;

    [SetUp]
    public void SetUp()
    {
        _repository = new Mock<IRoleRepository>();
        _businessRules = new RoleBusinessRules(_repository.Object);
    }

    [Test]
    public async Task RoleNameMustBeUniqueAsync_WhenNameExists_ShouldThrowBusinessException()
    {
        // Arrange: Verilerin hazırlandığı yer
        string roleName = "Admin";
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<Role, bool>>>(), true, default))
                   .ReturnsAsync(true);

        // Act: Metodun çalıştığı yer
        var ex = Assert.ThrowsAsync<BusinessException>(() =>
            _businessRules.RoleNameMustBeUniqueAsync(roleName)
        );

        // Assert: Beklenen hata mesajı
        Assert.That(ex.Message, Is.EqualTo(RoleMessages.RoleNameMustBeUnniqueMessage));
    }

    [Test]
    public async Task RoleNameMustBeUniqueAsync_WhenNameDoesNotExist_ShouldNotThrowException()
    {
        // Arrange: Verilerin hazırlandığı yer
        string roleName = "Admin";
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<Role, bool>>>(), true, default))
                   .ReturnsAsync(false);

        // Act & Assert: Hata fırlatılmamalı
        Assert.DoesNotThrowAsync(() => _businessRules.RoleNameMustBeUniqueAsync(roleName));
    }

    [Test]
    public async Task RoleIsPresentAsync_WhenRoleExists_ShouldNotThrowException()
    {
        // Arrange: Verilerin hazırlandığı yer
        int roleId = 1;
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<Role, bool>>>(), true, default))
                   .ReturnsAsync(true);

        // Act & Assert: Hata fırlatılmamalı
        Assert.DoesNotThrowAsync(() => _businessRules.RoleIsPresentAsync(roleId));
    }

    [Test]
    public async Task RoleIsPresentAsync_WhenRoleDoesNotExist_ShouldThrowBusinessException()
    {
        // Arrange: Verilerin hazırlandığı yer
        int roleId = 1;
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<Role, bool>>>(), true, default))
                   .ReturnsAsync(false);

        // Act: Metodun çalıştığı yer
        var ex = Assert.ThrowsAsync<BusinessException>(() =>
            _businessRules.RoleIsPresentAsync(roleId)
        );

        // Assert: Beklenen hata mesajı
        Assert.That(ex.Message, Is.EqualTo(RoleMessages.RoleNotFoundMessage));
    }

}
