using MediatR;

namespace Mc2.CrudTest.Application.Commands.Customer.Edit
{
    public class EditCustomerCommand:IRequest<EditCustomerCommand>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirthDay { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
        public string RegionOfPhoneNumber { get; set; }
    }
}
