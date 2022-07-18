using Domain;
using MediatR;
using System.Runtime.Serialization;

namespace Application.Api.Commands
{
    public class CreateCustomerCommand : IRequest<bool>
    {

        [DataMember]
        public Customer Customer;
        public CreateCustomerCommand()
        {

        }
        public CreateCustomerCommand(Customer customer)
        {
            Customer = customer;
        }
    }
}