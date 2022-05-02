using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Repositories;
using System;

namespace Mc2.CrudTest.Domain.Commands
{
    public class DeleteCustomerCommand : IDeleteCustomerCommand
    {
        private readonly ICustomerRepository _repository;
        public DeleteCustomerCommand(ICustomerRepository repository)
        {
            _repository = repository;
        }


        public void Execute(Guid dto)
        {
            var customer = _repository.GetById(dto);

            _repository.Delete(customer);
        }

        public void Execute(Guid id, Guid dto)
        {
            throw new NotImplementedException();
        }
    }
}
