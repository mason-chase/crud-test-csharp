using FluentAssertions;
using Mc2.CrudTest.TestTools;
using System;
using Xunit;

namespace Mc2.CrudTest.Domain.Model.Tests
{
    [Trait("(Domain) Customer", "")]
    public class CustomerTests
    {
        [Fact]
        void Create_CustomerCreated()
        {
            var customer = TestCustomer.Create();
            var id = Guid.NewGuid();

            var result = Customer.Create(id, customer.Name, customer.DateOfBirth, customer.PhoneNumber, customer.Email, customer.BankAccountNumber);

            result.Name.Equals(customer.Name);
            result.Id.Should().Be(id);
            result.DateOfBirth.Should().Be(customer.DateOfBirth);
            result.PhoneNumber.Should().Be(customer.PhoneNumber);
            result.Email.Should().Be(customer.Email);
            result.BankAccountNumber.Should().Be(customer.BankAccountNumber);
        }

    }
}
