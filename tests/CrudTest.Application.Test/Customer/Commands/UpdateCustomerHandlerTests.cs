using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Handler;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.DTO;
using CleanArchitecture.Domain.Exceptions;
using CrudTest.Application.Test.Mocks;
using Moq;
using Shouldly;

namespace CrudTest.Application.Test.Customer.Commands;
public class UpdateCustomerHandlerTests
{
    private readonly Mock<ICustomerRepository> _mockRepo;
    private readonly CleanArchitecture.Domain.Models.Customer _customer;
    private readonly UpdateCustomerHandler _handler;
    public UpdateCustomerHandlerTests()
    {
        _mockRepo = MockCustomerRepository.GetCustomerRepository();

        _handler = new UpdateCustomerHandler(_mockRepo.Object);

        _customer = new CleanArchitecture.Domain.Models.Customer
        {
            Id = 1,
            Firstname = "exampleName",
            Lastname = "AzaliexampleLName",
            PhoneNumber = "3214654155",
            Email = "Raminazali9@gmail.com",
            DateOfBirth = new DateTime(1998, 1, 12),
            BankAccountNumber = "5210-2345-6585-6773",
        };
    }
    // Because this Update Method Is Void Method And there is no Response i Can Just Check My Exception That may happens 
    [Fact]
    public async Task Customer_Update_WithValidData()
    {
        var result = await _handler.Handle(new UpdateCustomerCommand(_customer) { }, CancellationToken.None);

        var Customers = await _mockRepo.Object.GetList();

        result.ShouldBeTrue();

        result.ShouldBeOfType<bool>();

        Customers.Count.ShouldBe(3);
    }

    [Theory]
    [InlineData(false,"sgasgsag")]
    public async Task Customer_Update_InvalidEmail(bool Expected, string InvalidEmail)
    {
        _customer.Email = InvalidEmail;
        var result = await _handler.Handle(new UpdateCustomerCommand(_customer) { }, CancellationToken.None);

        var Customers = await _mockRepo.Object.GetList();

        result.ShouldBe(Expected);

        result.ShouldBeOfType<bool>();

        Customers.Count.ShouldBe(3);
    }

    [Theory]
    [InlineData(false,"1234568789")]
    public async Task Customer_Update_InvalidPhoneNumber(bool Expected, string PhoneNumber)
    {
        _customer.PhoneNumber = PhoneNumber;
        var result = await _handler.Handle(new UpdateCustomerCommand(_customer) { }, CancellationToken.None);

        var Customers = await _mockRepo.Object.GetList();

        result.ShouldBe(Expected);

        result.ShouldBeOfType<bool>();

        Customers.Count.ShouldBe(3);
    }

    [Theory]
    [InlineData(false,"345435748641")]
    public async Task Customer_Update_InvalidBankAccountNumber(bool Expected,string BankAccountNumber)
    {
        _customer.BankAccountNumber = BankAccountNumber;

        var result = await _handler.Handle(new UpdateCustomerCommand(_customer) { }, CancellationToken.None);

        var Customers = await _mockRepo.Object.GetList();

        result.ShouldBe(Expected);

        result.ShouldBeOfType<bool>();

        Customers.Count.ShouldBe(3);
    }
}
