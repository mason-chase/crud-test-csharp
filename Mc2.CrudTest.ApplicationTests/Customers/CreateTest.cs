using Mc2.CrudTest.Application.Customers.CommandHandlers;
using Mc2.CrudTest.DataAccess;
using Mc2.CrudTest.Domain.Commands;
using Mc2.CrudTest.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.ApplicationTests.Customers
{
    public class CreateTest
    {
        private readonly DataContext _mockDataContext;

        public CreateTest()
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
        public async void On_Success_CreatCustomer()
        {
            //Arrange
            CreateCustomerCommand request = new CreateCustomerCommand { Id = 300, 
                Firstname = "Hadi", Lastname = "Hadi", DateOfBirth = DateTime.Now, 
                PhoneNumber = 3133333335, BankAccountNumber = "123123", Email = "Hadi@Ardebili.com" };
            var service = new CreateCustomerCommandHandler(_mockDataContext);

            //Act
            var result = await service.Handle(request, CancellationToken.None);

            //Assert
            Assert.Equal(1, _mockDataContext.Customers.Count());
        }

        [Fact]
        public void On_Customer_FirstName_NotProvided()
        {
            //Arrange
            CreateCustomerCommand request = new CreateCustomerCommand { Id = 300, 
                Lastname = "Hadi", DateOfBirth = DateTime.Now, 
                PhoneNumber = 3133333335, BankAccountNumber = "123123", Email = "Hadi@Ardebili.com" };
            var service = new CreateCustomerCommandHandler(_mockDataContext);

            //Act
            Action action = () => service.Handle(request, CancellationToken.None).Wait();

            //Assert
            var caughtException = Assert.Throws<AggregateException>(action);
            Assert.Equal("One or more errors occurred. (Customer is not valid !)", caughtException.Message);
        }
        
        [Fact]
        public void On_Customer_LastName_NotProvided()
        {
            //Arrange
            CreateCustomerCommand request = new CreateCustomerCommand { Id = 300, 
                Firstname = "Hadi", DateOfBirth = DateTime.Now, 
                PhoneNumber = 3133333335, BankAccountNumber = "123123", Email = "Hadi@Ardebili.com" };
            var service = new CreateCustomerCommandHandler(_mockDataContext);

            //Act
            Action action = () => service.Handle(request, CancellationToken.None).Wait();

            //Assert
            var caughtException = Assert.Throws<AggregateException>(action);
            Assert.Equal("One or more errors occurred. (Customer is not valid !)", caughtException.Message);
        }
        
        [Fact]
        public void On_Customer_DateOfBirth_NotProvided()
        {
            //Arrange
            CreateCustomerCommand request = new CreateCustomerCommand { Id = 300, 
                Firstname = "Hadi", 
                PhoneNumber = 3133333335, BankAccountNumber = "123123", Email = "Hadi@Ardebili.com" };
            var service = new CreateCustomerCommandHandler(_mockDataContext);

            //Act
            Action action = () => service.Handle(request, CancellationToken.None).Wait();

            //Assert
            var caughtException = Assert.Throws<AggregateException>(action);
            Assert.Equal("One or more errors occurred. (Customer is not valid !)", caughtException.Message);
        }

        [Fact]
        public void On_Customer_PhoneNumber_NotValid()
        {
            //Arrange
            CreateCustomerCommand request = new CreateCustomerCommand { Id = 300, 
                Firstname = "Hadi", Lastname = "Hadi", DateOfBirth = DateTime.Now, 
                PhoneNumber = 313, BankAccountNumber = "123123", Email = "Hadi@Ardebili.com" };
            var service = new CreateCustomerCommandHandler(_mockDataContext);

            //Act
            Action action = () => service.Handle(request, CancellationToken.None).Wait();

            //Assert
            var caughtException = Assert.Throws<AggregateException>(action);
            Assert.Equal("One or more errors occurred. (Customer is not valid !)", caughtException.Message);
        }

        [Fact]
        public void On_Customer_BankAccountNumber_NotValid()
        {
            //Arrange
            CreateCustomerCommand request = new CreateCustomerCommand { Id = 300, 
                Firstname = "Hadi", Lastname = "Hadi", DateOfBirth = DateTime.Now, 
                PhoneNumber = 3133333335, Email = "Hadi@Ardebili.com" };
            var service = new CreateCustomerCommandHandler(_mockDataContext);

            //Act
            Action action = () => service.Handle(request, CancellationToken.None).Wait();

            //Assert
            var caughtException = Assert.Throws<AggregateException>(action);
            Assert.Equal("One or more errors occurred. (Customer is not valid !)", caughtException.Message);
        }
        
        [Fact]
        public void On_Customer_Email_NotValid()
        {
            //Arrange
            CreateCustomerCommand request = new CreateCustomerCommand { Id = 300, 
                Firstname = "Hadi", Lastname = "Hadi", DateOfBirth = DateTime.Now, 
                PhoneNumber = 31, BankAccountNumber = "123123", Email = "Hadi@Ardebili" };
            var service = new CreateCustomerCommandHandler(_mockDataContext);

            //Act
            Action action = () => service.Handle(request, CancellationToken.None).Wait();

            //Assert
            var caughtException = Assert.Throws<AggregateException>(action);
            Assert.Equal("One or more errors occurred. (Customer is not valid !)", caughtException.Message);
        }
    }
}