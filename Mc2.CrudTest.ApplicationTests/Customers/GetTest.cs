using Mc2.CrudTest.Application.Customers.QueryHandlers;
using Mc2.CrudTest.DataAccess;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.ApplicationTests.Customers
{
    public class GetTest
    {
        private readonly DataContext _mockDataContext;

        public GetTest()
        {
            _mockDataContext = GetDatabaseContext();
        }

        private DataContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new DataContext(options);
            return databaseContext;
        }

        [Fact]
        public async void On_Success_ReturnCustomerById()
        {
            //Arrange
            var customer = Customer.CreateCustomer(100, "Hadi", "Hadi", DateTime.Now, 3133333335, "Hadi@ardebili.com", "123123");
            _mockDataContext.Customers.Add(customer);
            await _mockDataContext.SaveChangesAsync();
            GetCustomerById request = new GetCustomerById { CustomerId = 100 };
            var service = new GetCustomerByIdQueryHandler(_mockDataContext);

            //Act
            var result = await service.Handle(request, CancellationToken.None);
     
            //Assert
            Assert.Equal(customer, result);
        }

        [Fact]
        public async void On_Success_ReturnsAllCustomers()
        {
            //Arrange
            var customer1 = Customer.CreateCustomer(101, "Mason", "Mason", DateTime.Now, 3133333335, "Mason@Chase.com", "123");
            _mockDataContext.Customers.Add(customer1);
            await _mockDataContext.SaveChangesAsync();
            GetAllCustomersQuery request = new GetAllCustomersQuery();
            var service = new GetAllCustomersQueryHandler(_mockDataContext);

            //Act
            var result = await service.Handle(request, CancellationToken.None);

            //Assert
            Assert.Equal(1, result.Count());
        }
    }
}