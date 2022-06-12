using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Api.Contracts.Customers.Requests;
using Mc2.CrudTest.Api.Contracts.Customers.Responses;
using Mc2.CrudTest.Api.Controllers;
using Microsoft.AspNetCore.Http;

namespace Mc2.CrudTest.Api.Test
{
    public class CustomersControllerTests
    {
        private readonly DbContextOptions _DBContextOption;

        public CustomersControllerTests()
        {
            var option = new DbContextOptionsBuilder();
            option.UseSqlServer("Server=(localdb)\\projectModels;Database=Mc2CrudTest;Trusted_Connection=True;MultipleActiveResultSets=true");
            _DBContextOption = option.Options;
        }

        [Fact]
        public async void On_Success_ReturnStatus200()
        {
            //Arrange
            var controller = new CustomerController(_DBContextOption);

            //Act
            var result = (OkObjectResult)await controller.GetAll();

            //Assert
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        public void GetById_returns_correctResult()
        {
            //arrange
            var controller = new CustomerController(_DBContextOption);

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
            var controller = new CustomerController(_DBContextOption);

            //act
            var result = controller.GetById(0).Result;


            //assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Post_addsItemToDbContext()
        {
            //arrange
            var controller = new CustomerController(_DBContextOption);
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
            var controller = new CustomerController(_DBContextOption);
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
            var controller = new CustomerController(_DBContextOption);
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
            var controller = new CustomerController(_DBContextOption);
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
            var controller = new CustomerController(_DBContextOption);
            long id = 4;

            //act
            var result = controller.DeleteCustomer(id).Result;

            //assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}