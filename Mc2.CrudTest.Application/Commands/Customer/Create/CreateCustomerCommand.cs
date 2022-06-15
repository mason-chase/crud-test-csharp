using MediatR;

namespace Mc2.CrudTest.Application.Commands.Customer.Create
{
    public class CreateCustomerCommand:IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirthDay { get; set; }
        public string PhoneNumber { get; set; }
        public string RegionOfPhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }

    }
}
