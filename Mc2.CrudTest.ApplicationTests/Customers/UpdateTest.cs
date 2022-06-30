using Mc2.CrudTest.Application.Customers.CommandHandlers;
using Mc2.CrudTest.DataAccess;
using Mc2.CrudTest.Domain.Commands;
using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.ApplicationTests.Customers
{
    public class UpdateTest
    {
        private readonly DataContext _mockDataContext;

        public UpdateTest()
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
        public async void On_Success_UpdateCustomer()
        {
            //Arrange
            var customer = Customer.CreateCustomer(200, "Hadi", "Hadi", DateTime.Now, 3133333335, "Hadi@ardebili.com", "123123");
            _mockDataContext.Customers.Add(customer);
            _mockDataContext.SaveChanges();
            _mockDataContext.Entry<Customer>(customer).State = EntityState.Detached;

            UpdateCustomerCommand request = new UpdateCustomerCommand { Id = 200, 
                Firstname = "Mason",
                Lastname= "Mason",
                DateOfBirth = DateTime.Now.AddYears(-20),
                PhoneNumber = 3133333339,
                Email = "Some@Mail.com",
                BankAccountNumber = "123123"
            };
            var service = new UpdateCustomerCommandHandler(_mockDataContext);

            //Act
            var result = await service.Handle(request, CancellationToken.None);
     
            //Assert
            Assert.Equal(request.Firstname, _mockDataContext.Customers.FirstOrDefault(c => c.Id == request.Id).Firstname);
            Assert.Equal(request.Lastname, _mockDataContext.Customers.FirstOrDefault(c => c.Id == request.Id).Lastname);
            Assert.Equal(request.DateOfBirth, _mockDataContext.Customers.FirstOrDefault(c => c.Id == request.Id).DateOfBirth);
            Assert.Equal(request.PhoneNumber, _mockDataContext.Customers.FirstOrDefault(c => c.Id == request.Id).PhoneNumber);
            Assert.Equal(request.Email, _mockDataContext.Customers.FirstOrDefault(c => c.Id == request.Id).Email);
            Assert.Equal(request.BankAccountNumber, _mockDataContext.Customers.FirstOrDefault(c => c.Id == request.Id).BankAccountNumber);
        }

        [Fact]
        public async void On_CustomerDoesNotExist()
        {
            //Arrange
            var customer = Customer.CreateCustomer(201, "Hadi", "Hadi", DateTime.Now, 3133333335, "Hadi@ardebili.com", "123123");
            _mockDataContext.Customers.Add(customer);
            await _mockDataContext.SaveChangesAsync();
            UpdateCustomerCommand request = new UpdateCustomerCommand
            {
                Id = 203,
                Firstname = "Mason",
                Lastname = "Hadi",
                DateOfBirth = DateTime.Now,
                PhoneNumber = 3133333335,
                Email = "Some@Mail.com",
                BankAccountNumber = "123123"
            };
            var service = new UpdateCustomerCommandHandler(_mockDataContext);

            //Act
            var result = await service.Handle(request, CancellationToken.None);

            //Assert
            Assert.Equal( null, result);
        }

        [Fact]
        public async void On_Customer_PhoneNumber_NotValid()
        {
            //Arrange
            var customer = Customer.CreateCustomer(201, "Hadi", "Hadi", DateTime.Now, 3133333335, "Hadi@ardebili.com", "123123");
            _mockDataContext.Customers.Add(customer);
            await _mockDataContext.SaveChangesAsync();
            UpdateCustomerCommand request = new UpdateCustomerCommand
            {
                Id = 201,
                Firstname = "Mason",
                Lastname = "Hadi",
                DateOfBirth = DateTime.Now,
                PhoneNumber = 31,
                Email = "Some@Mail.com",
                BankAccountNumber = "123123"
            };
            var service = new UpdateCustomerCommandHandler(_mockDataContext);

            //Act
            Action action = () => service.Handle(request, CancellationToken.None).Wait();

            //Assert
            var caughtException = Assert.Throws<AggregateException>(action);
            Assert.Equal("One or more errors occurred. (Customer is not valid !)", caughtException.Message);
        }

        [Fact]
        public async void On_Customer_Email_NotValid()
        {
            //Arrange
            var customer = Customer.CreateCustomer(201, "Hadi", "Hadi", DateTime.Now, 3133333335, "Hadi@ardebili.com", "123123");
            _mockDataContext.Customers.Add(customer);
            await _mockDataContext.SaveChangesAsync();
            UpdateCustomerCommand request = new UpdateCustomerCommand
            {
                Id = 201,
                Firstname = "Hadi",
                Lastname = "Hadi",
                DateOfBirth = DateTime.Now,
                PhoneNumber = 3133333335,
                Email = "MyMail",
                BankAccountNumber = "123123"
            };
            var service = new UpdateCustomerCommandHandler(_mockDataContext);

            //Act
            Action action = () => service.Handle(request, CancellationToken.None).Wait();

            //Assert
            var caughtException = Assert.Throws<AggregateException>(action);
            Assert.Equal("One or more errors occurred. (Customer is not valid !)", caughtException.Message);
        }

    }
}