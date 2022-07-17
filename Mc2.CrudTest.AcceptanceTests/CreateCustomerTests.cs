using Domain;
using Domain.AggregatesModel.CustomerAggregate;
using Domain.Seedwork;
using Infrastructure;
using Infrastructure.Repositories;
using Mc2.CrudTest.Presentation.Server.Queries;
using Mc2.CrudTest.Presentation.Server.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests
{
    [TestClass]
    public class BddTddTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ICustomerQueries> _customerQueriesMock;

        public BddTddTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _customerQueriesMock = new Mock<ICustomerQueries>();
        }

        [Fact]
        public async Task Get_customer_success()
        {
            //Arrange
            var fakeCustomerId = 123;
            var fakeDynamicResult = new Customer();
            _customerQueriesMock.Setup(x => x.GetOrderAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(fakeDynamicResult));

            //Act
            var orderController = new OrdersController(_mediatorMock.Object, _orderQueriesMock.Object, _identityServiceMock.Object, _loggerMock.Object);
            var actionResult = await orderController.GetOrderAsync(fakeOrderId) as OkObjectResult;

            //Assert
            Assert.Equal(actionResult.StatusCode, (int)System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public void CreateCustomerValid_ReturnsSuccess()
        {
            //Arrange
            var identity = new Guid().ToString();
            var firstName = "fakeCustomer";
            var lastName = "fakeCustomerFamily";
            var email = "a@a.com";
            var phoneNumber = "+3197010265373";
            var dateOfBirth = new DateTime(1985, 2, 1);
            string bankAccountNumber = "0123-4567-8912-3456";
            //Act
            var customer = new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);

            //Assert
            Assert.IsNotNull(customer);
        }

        [TestMethod]
        public void Create_CustomerInvalidPhone_ReturnFail()
        {
            //Arrange
            var identity = new Guid().ToString();
            var firstName = "fakeCustomer";
            var lastName = "fakeCustomerFamily";
            var email = "a@a.com";
            var phoneNumber = "+31654";
            var dateOfBirth = new DateTime(1985, 2, 1);
            string bankAccountNumber = "0123-4567-8912-3456"; ;

            //Act - Assert
            Action a = () => new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);
            Assert.ThrowsException<ArgumentException>(a);

        }
        [TestMethod]
        public void Create_CustomerBadBankAccount_ReturnFail()
        {
            //Arrange
            var identity = new Guid().ToString();
            var firstName = "fakeCustomer";
            var lastName = "fakeCustomerFamily";
            var email = "a@a.com";
            var phoneNumber = "+3197010265373";
            var dateOfBirth = new DateTime(1985, 2, 1);
            var bankAccountNumber = "757";

            //Act - Assert
            Assert.ThrowsException<ArgumentException>(() => new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber));

        }

        [TestMethod]
        public void Create_CustomerBadEmail_ReturnFail()
        {
            //Arrange
            var identity = new Guid().ToString();
            var firstName = "fakeCustomer";
            var lastName = "fakeCustomerFamily";
            var email = "aa.com";
            var phoneNumber = "+3197010265373";
            var dateOfBirth = new DateTime(1985, 2, 1);
            string bankAccountNumber = "0123-4567-8912-3456";

            //Act - Assert
            Assert.ThrowsException<ArgumentException>(() => new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber));

        }


        [TestMethod]
        public void Create_CustomerNotUnique_ReturnFail()
        {
            //Arrange
            var identity = new Guid().ToString();
            var firstName = "fakeCustomer";
            var lastName = "fakeCustomerFamily";
            var email = "a@a.com";
            var phoneNumber = "+3197010265373";
            var dateOfBirth = new DateTime(1985, 2, 1);
            string bankAccountNumber = "0123-4567-8912-3456";

            var customer1 = new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, "a@d.com", bankAccountNumber);
            var customer2 = new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, "b@b.com",bankAccountNumber);
            var data = new List<Customer> {
                new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, "a@d.com", bankAccountNumber),
                new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, "b@b.com",bankAccountNumber)

            }.AsQueryable();

            var mock = Mock<ICustomerService>();


            var _context = new Mock<CustomerContext>();

            //Set the context of mock object to  the data we created.
            _context.Setup(c => c.Customers).Returns(mockSet.Object);

            //Create instance of WorldRepository by injecting mock DbContext we created
            var  _repo = new CustomerRepository(_context.Object);

            _repo.Add(customer1);
            _repo.Add(customer2);

            var customers = _repo.GetAll();

            bool allUnique = customers
                .GroupBy(p => new { firstName, lastName, dateOfBirth})
                .All(g => g.Count() == 1);

            Assert.IsTrue(allUnique);
        }

        [TestMethod]
        public void Create_CustomerEMailNotUnique_ReturnFail()
        {
            //Arrange
            var identity = new Guid().ToString();
            var firstName = "fakeCustomer";
            var lastName = "fakeCustomerFamily";
            var email = "a@a.com";
            var phoneNumber = "+3197010265373";
            var dateOfBirth = new DateTime(1985, 2, 1);
            string bankAccountNumber = "0123-4567-8912-3456";

            //Act - Assert
            Assert.ThrowsException<Exception>(() => new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber));

        }


        // Please create more tests based on project requirements as per in readme.md
    }
}
