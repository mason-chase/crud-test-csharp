using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Validators.Common
{
    public class EmailValidator : AbstractValidator<string>
    {
        public EmailValidator() 
        {
            RuleFor(email => email).NotNull().WithMessage("Email is required !")
                    .MaximumLength(50).WithMessage("Email could not be more than 50 charactrs !")
                    .EmailAddress().WithMessage("Provided Email is not formated corrrectly !");
        }
    }
}
