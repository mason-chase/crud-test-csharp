using Mc2.CrudTest.Application.Common.Interfaces.Repository;
using Mc2.CrudTest.Domain.DomainService.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Commands.Customer.Edit
{
    public class EditCustomerHandler : IRequestHandler<EditCustomerCommand, EditCustomerCommand>
    {
        private readonly IBaseRepository<Mc2.CrudTest.Domain.Entities.Customer> _baseRepository;
        private CustomerDomainService _customerDomainService;

        public EditCustomerHandler(IBaseRepository<Domain.Entities.Customer> baseRepository)
        {
            _baseRepository = baseRepository;
            _customerDomainService = new CustomerDomainService();


        }
        public async Task<EditCustomerCommand> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
        {
            #region CheckValidators
            var resutlOfValidatingPhoneNumber = _customerDomainService.CheckPhoneNumberValidation(request.PhoneNumber
                 , request.RegionOfPhoneNumber);
            var resultOfCheckingUniquUserName = _baseRepository.UserFirstNameIsExist(request.FirstName);
            var resultOfCheckingUniqueEmail = _baseRepository.EmailIsExist(request.Email);
            var resultOfCheckingDateOfBirth = _baseRepository.DateOfBirthIsExist(request.DateOfBirthDay);
            var resultOfCheckingDateOfLastName = _baseRepository.LastNameIsExist(request.LastName);
            var checkValidators = resultOfCheckingUniqueEmail == true && resutlOfValidatingPhoneNumber == true && resultOfCheckingUniquUserName == true &&
               resultOfCheckingUniqueEmail == true && resultOfCheckingDateOfBirth == true && resultOfCheckingDateOfLastName == true;
            #endregion
            if (checkValidators is true)
            {
                var customer = new Mc2.CrudTest.Domain.Entities.Customer(request.FirstName, request.LastName,
                    request.DateOfBirthDay, request.PhoneNumber, request.Email, request.BankAccountNumber);
                customer.Id = new Guid(request.Id);
                var result = _baseRepository.Update(customer);
                return await Task.FromResult(request);
            }
            return await Task.FromResult(request);
        }
    }
}
