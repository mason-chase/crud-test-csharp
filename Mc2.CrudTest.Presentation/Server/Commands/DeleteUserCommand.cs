using MediatR;
using System.Runtime.Serialization;

namespace Application.Api.Commands
{
public class DeleteUserCommand : IRequest<bool>
    {

        [DataMember]
        public int Id { get; set; }
        public DeleteUserCommand()
        {

        }
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}