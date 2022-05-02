using AutoFixture.Xunit2;
using FluentAssertions;
using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Repositories;
using Mc2.CrudTest.Domain.Model;
using Mc2.CrudTest.Domain.Model.Exceptions;
using Mc2.CrudTest.Domain.Model.ValueObject;
using Mc2.CrudTest.TestTools;
using Moq;
using System;
using Xunit;

namespace Mc2.CrudTest.Domain.Commands.Tests
{
    [Trait("(Command) Add Customer", "")]
    public class AddCustomerTests
    {
        [Theory]
        [AutoMoqData]
        void Execute_CustomerAdded(
          [Frozen] Mock<ICustomerRepository> repositoryMock,
          AddCustomerCommand sut,
          Guid id)
        {
            repositoryMock
                .Setup(repo => repo.Add(It.IsAny<Customer>()));

            repositoryMock
             .Setup(repo => repo.GetBy(It.IsAny<Guid>(), It.IsAny<Name>(), It.IsAny<DateTime>())).Returns(It.IsAny<Customer>());

            repositoryMock
                 .Setup(repo => repo.GetBy(It.IsAny<Guid>(), It.IsAny<string>())).Returns(It.IsAny<Customer>());

            var dto = TestCustomer.Dto();
            sut.Execute(id, dto);

            repositoryMock
                .Verify(repo => repo.Add(It.Is<Customer>(c =>
                    c.Name.First == dto.FirstName
                    && c.Name.Last == dto.LastName
                    && c.DateOfBirth == dto.DateOfBirth))
                , Times.Once);

        }

        [Theory]
        [AutoMoqData]
        void Execute_DuplicateCustomerNameAndDateOfBirthException(
              [Frozen] Mock<ICustomerRepository> repositoryMock,
              AddCustomerCommand sut,
              CustomerDto dto)
        {
            var customer = TestCustomer.Create();

            repositoryMock
                .Setup(repo => repo.GetBy(It.IsAny<Guid>(), It.IsAny<Name>(), It.IsAny<DateTime>())).Returns(customer);


            dto.DateOfBirth = customer.DateOfBirth;
            dto.FirstName = customer.Name.First;
            dto.LastName = customer.Name.Last;

            var thrownException = Try.CatchOrNull(() =>
                    sut.Execute(Guid.NewGuid(), dto));

            thrownException.Should().NotBeNull();
            thrownException.Should()
                .BeOfType<DuplicateCustomerNameAndDateOfBirthException>();
        }



        [Theory]
        [AutoMoqData]
        void Execute_DuplicateCustomerEmailException(
              [Frozen] Mock<ICustomerRepository> repositoryMock,
              AddCustomerCommand sut,
              CustomerDto dto)
        {
            var customer = TestCustomer.Create();

            repositoryMock
                 .Setup(repo => repo.GetBy(It.IsAny<Guid>(), It.IsAny<Name>(), It.IsAny<DateTime>())).Returns(It.IsAny<Customer>());

            repositoryMock
                 .Setup(repo => repo.GetBy(It.IsAny<Guid>(), It.IsAny<string>())).Returns(customer);

            dto.Email = customer.Email;

            var thrownException = Try.CatchOrNull(() =>
                    sut.Execute(Guid.NewGuid(), dto));

            thrownException.Should().NotBeNull();
            thrownException.Should()
                .BeOfType<DuplicateCustomerEmailException>();
        }
    }
}
