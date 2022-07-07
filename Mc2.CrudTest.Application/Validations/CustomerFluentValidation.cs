using FluentValidation;
using Mc2.CrudTest.Domain.Models.Entities;
using Mc2.CrudTest.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c2.CrudTest.Application.Validators
{
    public class CustomerFluentValidation : AbstractValidator<CustomerEntity>
    {
        public CustomerFluentValidation(CustomerDbContext context)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is Null or Empty!");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is Null or Empty!");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is Null or Empty!");
            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Date Of Birth is Null or Empty!");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone Number is Null or Empty!");
            RuleFor(x => x.Email).NotNull().WithMessage("Email is Null or Empty!")
                .EmailAddress().WithMessage("Invalid email address format!");
            RuleFor(x => x.BankAccountNumber).Matches("^\\d{16}$").WithMessage("Incorrect Bank Account Number!");
        }
    }
}
