using Mc2.CrudTest.DataLayer.Repository;
using Mc2.CrudTest.Presentation.Server.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Handlers
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerRequest , bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _customerRepository.DeletePermanent(request.FirstName, request.LastName, request.DateOfBirth);
                await _customerRepository.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
