using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Handler;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.DTO;
using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.Domain.Models;
using CrudTest.Application.Test.Mocks;
using Moq;
using Shouldly;

namespace CrudTest.Application.Test.CustomerTypes.Commands;
public class AddCustomerCommandHandlerTests
{
    /// <summary>
    ///  At These Test I Used Moq , Shouldly And xunitCore Packages For My Testing Porposes
    /// </summary>
    private readonly Mock<ICustomerRepository> _mockRepo;
    private readonly CustomerDTO _customer;
    private readonly AddCustomerHandler _handler;
    public AddCustomerCommandHandlerTests()
    {
        _mockRepo = MockCustomerRepository.GetCustomerRepository();

        _handler = new AddCustomerHandler(_mockRepo.Object);

        _customer = new CustomerDTO
        {
            Firstname = "exampleName",
            Lastname = "AzaliexampleLName",
            PhoneNumber = "3214654155",
            Email = "Raminazali9@gmail.com",
            DateOfBirth = new DateTime(1998, 1, 12),
            BankAccountNumber = "5210-2345-6585-6773",
        };
    }


    [Fact]
    public async Task Customer_InsertHanlder_ValidRequest()
    {
        var result = await _handler.Handle(new AddCustomerCommand(_customer) { }, CancellationToken.None);

        var Customers = await _mockRepo.Object.GetList();

        result.ShouldBeOfType<CleanArchitecture.Domain.Models.Customer>();

        Customers.Count.ShouldBe(4);
    }
    [Theory]
    [InlineData(3,"123456789")]
    public async Task Customer_InsertHanlder_InvalidEmailAddress(int ExpectedCount,string WrongPhoneNumber)
    {
        _customer.PhoneNumber = WrongPhoneNumber;
        NotValidPhoneNumber ex = await Should.ThrowAsync<NotValidPhoneNumber>(async () => await _handler.Handle(new AddCustomerCommand(_customer) { }, CancellationToken.None));

        var result = await _mockRepo.Object.GetList();

        result.Count.ShouldBe(ExpectedCount);
        ex.ShouldNotBeNull();
    }
    [Theory]
    [InlineData(3, "4651348")]
    public async Task Customer_InsertHanlder_InvalidBankAcountNumber(int ExpectedCount, string WrongBankAccountNumber)
    {
        _customer.BankAccountNumber = WrongBankAccountNumber;
        NotValidBankAccountNumber ex = await Should.ThrowAsync<NotValidBankAccountNumber>(async () => await _handler.Handle(new AddCustomerCommand(_customer) { }, CancellationToken.None));

        var result = await _mockRepo.Object.GetList();

        result.Count.ShouldBe(ExpectedCount);
        ex.ShouldNotBeNull();
    }
    [Theory]
    [InlineData(3, "asgasgsagas")]
    public async Task Customer_InsertHanlder_InvalidPhoneNumber(int ExpectedCount, string WrongEmail)
    {
        _customer.Email = WrongEmail;
        NotValidEmail ex = await Should.ThrowAsync<NotValidEmail>(async () => await _handler.Handle(new AddCustomerCommand(_customer) { }, CancellationToken.None));

        var result = await _mockRepo.Object.GetList();

        result.Count.ShouldBe(ExpectedCount);
        ex.ShouldNotBeNull();
    }
}
