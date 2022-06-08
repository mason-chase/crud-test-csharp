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
public class GetCustomerRepositoryHandlerTests
{
    /// <summary>
    ///  At These Test I Used Moq , Shouldly And xunitCore Packages For My Testing Porposes
    /// </summary>
    private readonly Mock<ICustomerRepository> _mockRepo;
    public GetCustomerRepositoryHandlerTests()
    {
        _mockRepo = MockCustomerRepository.GetCustomerRepository();
    }
    [Fact]
    public async Task CustomersList_ShouldNotBeNull_ShouldBeOfTypeListOfCustomer()
    {
        var handler = new GetAllCustomerQueryHandler(_mockRepo.Object);

        var result = await handler.Handle(new GetAllCustomerQuery(), CancellationToken.None);
        result.ShouldBeOfType<List<CleanArchitecture.Domain.Models.Customer>>();
        result.ShouldNotBeNull();
        result.Count.ShouldBe(3);
    }
}
