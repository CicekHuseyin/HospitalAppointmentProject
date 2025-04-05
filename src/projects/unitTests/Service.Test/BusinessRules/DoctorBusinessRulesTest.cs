using Core.CrossCuttingConcerns.Exceptions.Types;
using HospitalAppointmentProject.DataAccess.Repositories.Abstracts;
using HospitalAppointmentProject.Model.Entities;
using HospitalAppointmentProject.Service.BusinessRules.Doctors;
using HospitalAppointmentProject.Service.Constants.Doctors;
using Moq;
using NUnit.Framework;
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
        //_businessRules = new DoctorBusinessRules(_repository.Object);
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

        //Assert.AreEqual(ex.Message, DoctorMessages.DoctorNameMustBeUnniqueMessage);
        Assert.Equals(ex.Message, DoctorMessages.DoctorNameMustBeUnniqueMessage);


    }
}
