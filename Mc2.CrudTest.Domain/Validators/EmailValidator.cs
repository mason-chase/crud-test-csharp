using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Validators
{
    public static class EmailValidator
    {
        public static bool Validate(string email)
        {
            var emailValidator = new EmailAddressAttribute();
            if (emailValidator.IsValid(email))
                return true;
            return false;
        }
    }
}
