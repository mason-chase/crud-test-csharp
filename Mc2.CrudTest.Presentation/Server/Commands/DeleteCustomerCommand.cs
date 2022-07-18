using MediatR;
using System.Runtime.Serialization;

namespace Application.Api.Commands
{
public class DeleteCustomerCommand : IRequest<bool>
    {

        [DataMember]
        public int Id { get; set; }
        public DeleteCustomerCommand()
        {

        }
        public DeleteCustomerCommand(int id)
        {
            Id = id;
        }
    }
}