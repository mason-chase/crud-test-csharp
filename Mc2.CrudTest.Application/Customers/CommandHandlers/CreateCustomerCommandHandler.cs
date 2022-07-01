using Mc2.CrudTest.DataAccess;
using Mc2.CrudTest.Domain.Commands;
using Mc2.CrudTest.Domain.Entities;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.CommandHandlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand,Customer>
    {
        private readonly DataContext _dataContext;
        public CreateCustomerCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.CreateCustomer(request.Id, request.Firstname, request.Lastname, request.DateOfBirth, request.PhoneNumber, request.Email, request.BankAccountNumber);
            _dataContext.Add(customer);
            await _dataContext.SaveChangesAsync();
            return customer;
        }
    }
}
