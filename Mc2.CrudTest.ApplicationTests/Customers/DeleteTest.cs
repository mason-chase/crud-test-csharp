using Mc2.CrudTest.Application.Customers.CommandHandlers;
using Mc2.CrudTest.Application.Customers.QueryHandlers;
using Mc2.CrudTest.DataAccess;
using Mc2.CrudTest.Domain.Commands;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.ApplicationTests.Customers
{
    public class DeleteTest
    {
        private readonly DataContext _mockDataContext;

        public DeleteTest()
        {
            _mockDataContext = GetDatabaseContext();
        }

        private DataContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
            var databaseContext = new DataContext(options);
            return databaseContext;
        }

        [Fact]
        public async void On_Success_DeleteCustomer()
        {
            //Arrange
            var customer = Customer.CreateCustomer(400, "Hadi", "Hadi", DateTime.Now, 3133333335, "Hadi@ardebili.com", "123123");
            _mockDataContext.Customers.Add(customer);
            _mockDataContext.SaveChanges();
            _mockDataContext.Entry<Customer>(customer).State = EntityState.Detached;
            DeleteCustomerCommand request = new DeleteCustomerCommand { Id = 400};
            var service = new DeleteCustomerCommandHandler(_mockDataContext);

            //Act
            var result = await service.Handle(request, CancellationToken.None);
     
            //Assert
            Assert.Equal(0, _mockDataContext.Customers.Where(c => c.Id == 400).Count());
        }

        [Fact]
        public async void On_CustomerIdDoesNotExist()
        {
            //Arrange
            var customer = Customer.CreateCustomer(400, "Hadi", "Hadi", DateTime.Now, 3133333335, "Hadi@ardebili.com", "123123");
            _mockDataContext.Customers.Add(customer);
            _mockDataContext.SaveChanges();

            DeleteCustomerCommand request = new DeleteCustomerCommand { Id = 500 };
            var service = new DeleteCustomerCommandHandler(_mockDataContext);

            //Act
            var result = await service.Handle(request, CancellationToken.None);

            //Assert
            Assert.Equal(new Unit(), result);
        }
    }
}