using FluentValidation;
using Mc2.CrudTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Validators.CustomerValidators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Firstname).NotNull().WithMessage("FirstName is required !")
                .MinimumLength(3).WithMessage("FirstName must be at least 3 characters !")
                .MaximumLength(50).WithMessage("FirstName could not be more than 50 charactrs !");


            RuleFor(customer => customer.Lastname).NotNull().WithMessage("Lastname is required !")
                .MinimumLength(3).WithMessage("Lastname must be at least 3 characters !")
                .MaximumLength(50).WithMessage("Lastname could not be more than 50 charactrs !");


            RuleFor(customer => customer.Email).NotNull().WithMessage("Email is required !")
                .MaximumLength(50).WithMessage("Email could not be more than 50 charactrs !")
                .EmailAddress().WithMessage("Provided Email is not formated corrrectly !");




        }
    }
}
