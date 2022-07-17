using Domain;
using MediatR;
using System.Runtime.Serialization;

namespace Application.Api.Commands
{
public class CreateUserCommand : IRequest<bool>
    {

        [DataMember]
        public Customer Customer;
        public CreateUserCommand()
        {

        }
        public CreateUserCommand(Customer customer)
        {
            Customer = customer;
        }
    }
}