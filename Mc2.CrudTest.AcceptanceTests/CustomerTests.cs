using FluentValidation.TestHelper;
using Mc2.CrudTest.Application.Customers;
using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Domain.Interfaces;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests
{
    public class CustomerTests
    {
        Mock<ICustomerRepository> repo;

        public CustomerTests()
        {
            repo = new Mock<ICustomerRepository>();
            repo.Setup(i => i.GetAllAsync().Result).Returns(new System.Collections.Generic.List<Customer>());
            repo.Setup(i => i.AddAsync(It.IsAny<Customer>()).Result).Returns(true);
            repo.Setup(cr => cr.Remove(It.IsAny<Customer>()).Result).Returns(true);
            repo.Setup(cr => cr.UpdateAsync(It.IsAny<Customer>()).Result).Returns(true);
        }

        async Task<Customer> ReturnNull()
        {
            return null;
        }

        [Fact]
        public void GetCustomersList_WhenCalled_ReturnsListOfCustomers()
        {
            var q = new List.Handler(repo.Object);

            var res = q.Handle(new List.Query(), new CancellationTokenSource().Token);

            Assert.NotNull(res);
        }

        [Fact]
        public void Create_NotValidCustomer_Throws___()
        {
            var q = new Create.Handler(repo.Object);

            var c = new Customer();

            var request = new Create.Command { Customer = c };

            var validationErrors = new Create.CommandValidaor().TestValidate(request);

            Assert.True(validationErrors.ShouldHaveValidationErrorFor("Customer.Id").Any());
        }

        [Fact]
        public async void Create_ValidCustomer_ReturnsUnit()
        {
            var q = new Create.Handler(repo.Object);

            var c = new Customer
            {
                Id = Guid.NewGuid(),
                BanckAccountNumber = "1234567890123456",
                DateOfBirth = DateTime.Now,
                Email = "user@site.com",
                FirstName = "a",
                LastName = "b",
                PhoneNumber = "1234567890123"
            };

            var request = new Create.Command { Customer = c };

            var result = await q.Handle(request, new CancellationTokenSource().Token);

            Assert.NotNull(result);
        }

        [Fact]
        public async void Delete_NotExistingCustomer_ReturnsNull()
        {
            repo.Setup(cr => cr.FirstOrDefaultAsync(It.IsAny<Expression<Func<Customer, bool>>>())).Returns(ReturnNull());

            var q = new Delete.Handler(repo.Object);

            var request = new Delete.Command { Id = Guid.NewGuid() };

            var result = await q.Handle(request, new CancellationTokenSource().Token);

            Assert.Null(result);
        }

        [Fact]
        public async void Delete_ExistingCustomer_ReturnsUnit()
        {
            repo.Setup(cr => cr.FirstOrDefaultAsync(It.IsAny<Expression<Func<Customer, bool>>>()).Result).Returns(new Customer());

            var q = new Delete.Handler(repo.Object);

            var request = new Delete.Command { Id = Guid.NewGuid() };

            var result = await q.Handle(request, new CancellationTokenSource().Token);

            Assert.NotNull(result);
        }

        [Fact]
        public async void Detail_NotExistingCustomer_ReturnsNull()
        {
            repo.Setup(cr => cr.FirstOrDefaultAsync(It.IsAny<Expression<Func<Customer, bool>>>())).Returns(ReturnNull());

            var q = new Detail.Handler(repo.Object);

            var request = new Detail.Query { Id = Guid.NewGuid() };

            var result = await q.Handle(request, new CancellationTokenSource().Token);

            Assert.Null(result);
        }

        [Fact]
        public async void Detail_ExistingCustomer_ReturnsUnit()
        {
            repo.Setup(cr => cr.FirstOrDefaultAsync(It.IsAny<Expression<Func<Customer, bool>>>()).Result).Returns(new Customer());

            var q = new Detail.Handler(repo.Object);

            var request = new Detail.Query { Id = Guid.NewGuid() };

            var result = await q.Handle(request, new CancellationTokenSource().Token);

            Assert.NotNull(result);
        }

        [Fact]
        public async void Update_ExistingCustomer_ReturnsUnit()
        {
            repo.Setup(cr => cr.AnyAsync(It.IsAny<Expression<Func<Customer, bool>>>()).Result).Returns(true);

            var q = new Update.Handler(repo.Object);

            var request = new Update.Command { Customer = new Customer() };

            var result = await q.Handle(request, new CancellationTokenSource().Token);

            Assert.IsType(typeof(Unit), result.Value);
        }

        [Fact]
        public async void Update_NotExistingCustomer_ReturnsNull()
        {
            repo.Setup(cr => cr.AnyAsync(It.IsAny<Expression<Func<Customer, bool>>>()).Result).Returns(false);

            var q = new Update.Handler(repo.Object);

            var request = new Update.Command { Customer = new Customer() };

            var result = await q.Handle(request, new CancellationTokenSource().Token);

            Assert.Null(result);
        }
    }
}
