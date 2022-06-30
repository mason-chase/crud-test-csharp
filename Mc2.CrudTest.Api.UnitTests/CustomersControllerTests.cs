using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Api.Contracts.Customers.Requests;
using Mc2.CrudTest.Api.Contracts.Customers.Responses;
using Mc2.CrudTest.Api.Controllers;
using Microsoft.AspNetCore.Http;
using MediatR;
using Mc2.CrudTest.Application.Customers.QueryHandlers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Mc2.CrudTest.DataAccess;
using Mc2.CrudTest.Domain.Queries;

namespace Mc2.CrudTest.Api.Test
{
    public class CustomersControllerTests
    {
        private readonly DbContextOptions _DBContextOption;
        private readonly DataContext _mockDataContext;
        private readonly Mediator _mediator;
        public CustomersControllerTests()
        {
            //    var option = new DbContextOptionsBuilder();
            //    option.UseSqlServer("Server=(localdb)\\projectModels;Database=Mc2CrudTest;Trusted_Connection=True;MultipleActiveResultSets=true");
            //    _DBContextOption = option.Options;

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
        public async void Test()
        {
            var customer = Customer.CreateCustomer(1, "Hadi", "Hadi", DateTime.Now, 9812, "Hadi@ardebili.com", "123");
            _mockDataContext.Customers.Add(customer);
            await _mockDataContext.SaveChangesAsync();
            GetAllCustomersQuery request = new GetAllCustomersQuery();
            var service = new GetAllCustomersQueryHandler(_mockDataContext);
            var result = await service.Handle(request, CancellationToken.None);

            Assert.Equal(1, result.Count());
        }

        [Fact]
        public async void On_Success_ReturnStatus200()
        {
            //Arrange
            var controller = new CustomerController(_mediator, _DBContextOption);

            //Act
            var result = (OkObjectResult)await controller.GetAll();

            //Assert
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        public void GetById_returns_correctResult()
        {
            //arrange
            var controller = new CustomerController(_mediator, _DBContextOption);

            //act
            var result = controller.GetById(1).Result;

            //assert
            Assert.IsType<Customer>(result);
            //Assert.Equal(1, result);
        }

        [Fact]
        public void Get_by_id_returns_NotFound_for_invalid_Id()
        {
            //arrange
            var controller = new CustomerController(_mediator, _DBContextOption);

            //act
            var result = controller.GetById(0).Result;


            //assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Post_addsItemToDbContext()
        {
            //arrange
            var controller = new CustomerController(_mediator, _DBContextOption);
            var customer = new CustomerCreate
            {
                Firstname = "Hadi",
                Lastname = "Ardebili",
                DateOfBirth = DateTime.Now,
                PhoneNumber = 123456,
                Email = "h@b.com",
                BankAccountNumber = "111111"
            };
            //act
            var result = await controller.CreateCustomer(customer);

            //assert
            //To Do: Check the CustomerResponse With CustomerRequest.
            //Assert.Equal(customer, result);
        }

        [Fact]
        public async void Post_Returns_CreatedAtActionResult_type()
        {
            //arrange
            var controller = new CustomerController(_mediator, _DBContextOption);
            var customer = new CustomerCreate
            {
                Id = 1,
                Firstname = "Hadi",
                Lastname = "Ardebili",
                DateOfBirth = DateTime.Now,
                PhoneNumber = 123456,
                Email = "h@b.com",
                BankAccountNumber = "111111"
            };
            //act
            var result = await controller.CreateCustomer(customer);

            //assert
            var actionResult = Assert.IsType<ActionResult<CustomerResponse>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var returnValue = Assert.IsType<CustomerResponse>(createdAtActionResult.Value);
        }

        [Fact]
        public void Patch_updatesContext()
        {
            //arrange
            var controller = new CustomerController(_mediator, _DBContextOption);
            //long id = 3;


            //act
            //To Do: Create a UpdateCustomer and pass to the method.
            //var result = controller.UpdateCustomer(id, );

            //assert
            //Assert.Equal(tobeUpdated, updatedItem);

        }

        [Fact]
        public void Delete_removesEntryFromContext()
        {
            //arrange
            var controller = new CustomerController(_mediator, _DBContextOption);
            long id = 3;

            //act
            var result = controller.DeleteCustomer(id).Result;

            //assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void Delete_returns_NotFound_InvalidId()
        {
            //arrange
            var controller = new CustomerController(_mediator, _DBContextOption);
            long id = 4;

            //act
            var result = controller.DeleteCustomer(id).Result;

            //assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}