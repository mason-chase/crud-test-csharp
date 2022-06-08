using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Handler;
using CleanArchitecture.Application.Queries;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Models;
using CrudTest.Application.Test.Mocks;
using Moq;
using Shouldly;

namespace CrudTest.Application.Test.CustomerTypes.Queries;
public class GetByIdQueriesHandlerTests
{
    /// <summary>
    ///  At These Test I Used Moq , Shouldly And xunitCore Packages For My Testing Porposes
    /// </summary>
    private readonly Mock<ICustomerRepository> _mockRepo;
    public GetByIdQueriesHandlerTests()
    {
        _mockRepo = MockCustomerRepository.GetCustomerRepository();
    }

    [Theory]
    [InlineData(1)]
    public async Task GetByCustomerByIdThree(int CustomerId)
    {
        var handler = new GetCustomerByIdHandler(_mockRepo.Object);

        var result = await handler.Handle(new GetCustomerByIdQuery(CustomerId), CancellationToken.None);
        result.ShouldNotBeNull();
        result.ShouldBeOfType<CleanArchitecture.Domain.Models.Customer>();
    }
}
