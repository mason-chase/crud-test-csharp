
using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Handler;
using CleanArchitecture.Application.Repositories;
using CrudTest.Application.Test.Mocks;
using Moq;
using Shouldly;

namespace CrudTest.Application.Test.Customer.Commands;
public class DeleteCustomerCommandHandlerTests
{
    private readonly Mock<ICustomerRepository> _mockRepo;
    public DeleteCustomerCommandHandlerTests()
    {
        _mockRepo = MockCustomerRepository.GetCustomerRepository();
    }

    [Theory]
    [InlineData(1)]
    public async Task Delete_withCurrectCutomerId(int CustomerId)
    {
        var handler = new DeleteCustomerHandler(_mockRepo.Object);

        var result = await handler.Handle(new DeleteCustomerCommand(CustomerId), CancellationToken.None);
        result.ShouldBeTrue();
        result.ShouldBeOfType<bool>();
    }
}
