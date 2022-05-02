using AutoFixture.Xunit2;
using Mc2.CrudTest.Application.Repositories;
using Mc2.CrudTest.Domain.Model;
using Mc2.CrudTest.TestTools;
using Moq;
using System;
using Xunit;

namespace Mc2.CrudTest.Domain.Commands.Tests
{
    [Trait("(Command) Delete Customer", "")]
    public class DeleteCustomerTests
    {
        [Theory]
        [AutoMoqData]
        void Execute_CustomerDeleted(
            [Frozen] Mock<ICustomerRepository> repositoryMock,
            DeleteCustomerCommand sut)
        {
            var customer = TestCustomer.Create();

            repositoryMock
                .Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(customer);

            repositoryMock
                .Setup(deleter => deleter.Delete(It.IsAny<Customer>()));

            sut.Execute(customer.Id);

            repositoryMock.Verify(deleter => deleter.Delete(It.Is<Customer>(c => c == customer)), Times.Once);
        }
    }
}
