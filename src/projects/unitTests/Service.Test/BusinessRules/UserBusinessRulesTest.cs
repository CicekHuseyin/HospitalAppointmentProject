using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Entities;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Service.BusinessRules.Users;
using HospitalAppointmentProject.Service.Constants.Users;
using Moq;
using NUnit.Framework;
using System.Linq.Expressions;

namespace Service.Test.BusinessRules;

public class UserBusinessRulesTest
{
    private UserBusinessRules _businessRules;
    private Mock<IUserRepository> _repository;

    [SetUp]
    public void SetUp()
    {
        _repository = new Mock<IUserRepository>();
        _businessRules = new UserBusinessRules(_repository.Object);
    }

    [Test]
    public async Task UserNameMustBeUniqueAsync_WhenUserNameExists_ShouldThrowBusinessException()
    {
        // Arrange: Verilerin hazırlandığı yer
        string userName = "existingUser";
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<User, bool>>>(), true, default))
                   .ReturnsAsync(true);

        // Act: Metodun çalıştığı yer
        var ex = Assert.ThrowsAsync<BusinessException>(() =>
            _businessRules.UserNameMustBeUniqueAsync(userName)
        );

        // Assert: Hata mesajı doğrulaması
        Assert.That(ex.Message, Is.EqualTo(UsersMessages.UserNameMustBeUnniqueMessage));
    }

    [Test]
    public async Task UserNameMustBeUniqueAsync_WhenUserNameDoesNotExist_ShouldNotThrowBusinessException()
    {
        // Arrange: Verilerin hazırlandığı yer
        string userName = "newUser";
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<User, bool>>>(), true, default))
                   .ReturnsAsync(false);

        // Act & Assert: Hata fırlatılmamalı
        Assert.DoesNotThrowAsync(() => _businessRules.UserNameMustBeUniqueAsync(userName));
    }

    [Test]
    public async Task UserIsPresentAsync_WhenUserExists_ShouldNotThrowBusinessException()
    {
        // Arrange: Verilerin hazırlandığı yer
        int userId = 1;
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<User, bool>>>(), true, default))
                   .ReturnsAsync(true);

        // Act & Assert: Hata fırlatılmamalı
        Assert.DoesNotThrowAsync(() => _businessRules.UserIsPresentAsync(userId));
    }

    [Test]
    public async Task UserIsPresentAsync_WhenUserDoesNotExist_ShouldThrowBusinessException()
    {
        // Arrange: Verilerin hazırlandığı yer
        int userId = 1;
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<User, bool>>>(), true, default))
                   .ReturnsAsync(false);

        // Act: Metodun çalıştığı yer
        var ex = Assert.ThrowsAsync<BusinessException>(() =>
            _businessRules.UserIsPresentAsync(userId)
        );

        // Assert: Hata mesajı doğrulaması
        Assert.That(ex.Message, Is.EqualTo(UsersMessages.UserNotFoundMessage));
    }

    [Test]
    public async Task EmailMustBeUniqueAsync_WhenEmailExists_ShouldThrowBusinessException()
    {
        // Arrange: Verilerin hazırlandığı yer
        string email = "existingEmail@gmail.com";
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<User, bool>>>(), true, default))
                   .ReturnsAsync(true);

        // Act: Metodun çalıştığı yer
        var ex = Assert.ThrowsAsync<BusinessException>(() =>
            _businessRules.EmailMustBeUniqueAsync(email)
        );

        // Assert: Hata mesajı doğrulaması
        Assert.That(ex.Message, Is.EqualTo(UsersMessages.EmailMustBeUnique));
    }

    [Test]
    public async Task EmailMustBeUniqueAsync_WhenEmailDoesNotExist_ShouldNotThrowBusinessException()
    {
        // Arrange: Verilerin hazırlandığı yer
        string email = "newEmail@gmail.com";
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<User, bool>>>(), true, default))
                   .ReturnsAsync(false);

        // Act & Assert: Hata fırlatılmamalı
        Assert.DoesNotThrowAsync(() => _businessRules.EmailMustBeUniqueAsync(email));
    }

    [Test]
    public async Task SearchByEmailAsync_WhenEmailExists_ShouldNotThrowNotFoundException()
    {
        // Arrange: Verilerin hazırlandığı yer
        string email = "existingEmail@gmail.com";
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<User, bool>>>(), true, default))
                   .ReturnsAsync(true);

        // Act & Assert: Hata fırlatılmamalı
        Assert.DoesNotThrowAsync(() => _businessRules.SearchByEmailAsync(email));
    }

    [Test]
    public async Task SearchByEmailAsync_WhenEmailDoesNotExist_ShouldThrowNotFoundException()
    {
        // Arrange: Verilerin hazırlandığı yer
        string email = "nonExistingEmail@gmail.com";
        _repository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<User, bool>>>(), true, default))
                   .ReturnsAsync(false);

        // Act: Metodun çalıştığı yer
        var ex = Assert.ThrowsAsync<NotFoundException>(() =>
            _businessRules.SearchByEmailAsync(email)
        );

        // Assert: Hata mesajı doğrulaması
        Assert.That(ex.Message, Is.EqualTo(UsersMessages.UserNotFoundMessage));
    }
}
