﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Presentation.Server.CQRS.Commands;
using Mc2.CrudTest.Presentation.Server.Models;
using Mc2.CrudTest.Shared.Common;
using MediatR;
using PhoneNumbers;

namespace Mc2.CrudTest.Presentation.Server.Queries
{
    public class AddCustomerHandler: IRequestHandler<AddCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _repository;
        private static PhoneNumberUtil _phoneUtil;
        public AddCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
            _phoneUtil = PhoneNumberUtil.GetInstance();
        }
        public async Task<Customer> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customerModel = new Customer()
            {
                Email = request.CustomerDto.Email, 
                Firstname = request.CustomerDto.Firstname,
                Lastname = request.CustomerDto.Lastname,
                PhoneNumber = request.CustomerDto.PhoneNumber,
                BankAccountNumber = request.CustomerDto.BankAccountNumber,
                DateOfBirth = request.CustomerDto.DateOfBirth
            };
            if (!customerModel.Email.IsValidEmailAddress())
                throw new NotValidEmail();
            // international Numbers 
            // Test Needed TODO
            if (!customerModel.PhoneNumber.IsPhoneNumber())
                throw new NotValidNumber();
            if (!customerModel.BankAccountNumber.IsValidBankAccount())
                throw new NotValidBankAccountNumber();
                
            try
            {
                await _repository.AddAsync(customerModel);
                await _repository.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
           
            return customerModel;
        }
    }
    public class NotValidNumber: Exception {}
    public class NotValidEmail: Exception {}
    public class NotValidBankAccountNumber : Exception {}
}
