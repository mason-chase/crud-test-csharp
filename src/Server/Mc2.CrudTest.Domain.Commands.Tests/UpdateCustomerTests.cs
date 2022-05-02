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
    [Trait("(Command) Update Customer", "")]
    public class UpdateCustomerTests
    {
        [Theory]
        [AutoMoqData]
        void Execute_CustomerUpdated(
             [Frozen] Mock<ICustomerRepository> repositoryMock,
             UpdateCustomerCommand sut)
        {
            repositoryMock
             .Setup(repo => repo.GetBy(It.IsAny<Guid>(), It.IsAny<Name>(), It.IsAny<DateTime>())).Returns(It.IsAny<Customer>());

            repositoryMock
                 .Setup(repo => repo.GetBy(It.IsAny<Guid>(), It.IsAny<string>())).Returns(It.IsAny<Customer>());


            var customer = TestCustomer.Create();
            repositoryMock
                 .Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(customer);

            repositoryMock
              .Setup(repo => repo.Update(It.IsAny<Customer>()));

            var dto = TestCustomer.Dto();
            sut.Execute(customer.Id, dto);

            repositoryMock
                .Verify(repo => repo.Update(It.Is<Customer>(c =>
                    c == customer &&
                    c.Name.First == dto.FirstName &&
                    c.Name.Last == dto.LastName)), Times.Once);         

        }

        [Theory]
        [AutoMoqData]
        void Execute_DuplicateCustomerNameAndDateOfBirthException(
              [Frozen] Mock<ICustomerRepository> repositoryMock,
              UpdateCustomerCommand sut,
              CustomerDto dto)
        {
            var customer1 = TestCustomer.Create();
            var customer2 = TestCustomer.Create();

            repositoryMock
                .Setup(repo => repo.GetBy(It.IsAny<Guid>(), It.IsAny<Name>(), It.IsAny<DateTime>())).Returns(customer1);

            repositoryMock
                 .Setup(repo => repo.GetBy(It.IsAny<Guid>(), It.IsAny<string>())).Returns(It.IsAny<Customer>());

            repositoryMock
                 .Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(customer1);


            dto.DateOfBirth = customer2.DateOfBirth;
            dto.FirstName = customer2.Name.First;
            dto.LastName = customer2.Name.Last;

            var thrownException = Try.CatchOrNull(() =>
                    sut.Execute(customer1.Id, dto));

            thrownException.Should().NotBeNull();
            thrownException.Should()
                .BeOfType<DuplicateCustomerNameAndDateOfBirthException>();
        }



        [Theory]
        [AutoMoqData]
        void Execute_DuplicateCustomerEmailException(
              [Frozen] Mock<ICustomerRepository> repositoryMock,
              UpdateCustomerCommand sut)
        {
            //Arrange
            var customer1 = TestCustomer.Create();
            var customer2 = TestCustomer.Create();

            repositoryMock
            .Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(customer1);

            repositoryMock
                 .Setup(repo => repo.GetBy(It.IsAny<Guid>(), It.IsAny<Name>(), It.IsAny<DateTime>())).Returns(It.IsAny<Customer>());

            repositoryMock
                 .Setup(repo => repo.GetBy(It.IsAny<Guid>(), It.IsAny<string>())).Returns(customer1);

            var dto = TestCustomer.Dto();
            dto.Email = customer2.Email;

            //Act
            var thrownException = Try.CatchOrNull(() =>
                    sut.Execute(customer1.Id, dto));

            //Assert
            thrownException.Should().NotBeNull();
            thrownException.Should()
                .BeOfType<DuplicateCustomerEmailException>();
        }

        [Theory]
        [AutoMoqData]
        void Execute_CustomerNotFoundException(
              [Frozen] Mock<ICustomerRepository> repositoryMock,
              UpdateCustomerCommand sut)
        {
            //Arrange
            Customer customer = null;
            repositoryMock
                 .Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(customer);

            //Act
            var thrownException = Try.CatchOrNull(() =>
                   sut.Execute(Guid.NewGuid(), TestCustomer.Dto()));


            //Assert
            thrownException.Should().NotBeNull();
            thrownException.Should()
                .BeOfType<CustomerNotFoundException>();
        }
    }
}
