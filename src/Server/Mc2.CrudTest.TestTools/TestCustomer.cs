using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Domain.Model;
using Mc2.CrudTest.Domain.Model.ValueObject;
using System;

namespace Mc2.CrudTest.TestTools
{
    public class TestCustomer
    {
        public static Customer Create()
        {
            var customer = Customer.Create(Guid.NewGuid(),
             Name.Create("parisa", "hadadinia"),
             new DateTime(1992, 01, 01),
             PhoneNumber.Create("PK", "03336323900"),
             Email.Create("parisa.hadadinia@gmail.com"),
             BankAccountNumber.Create("123"));

            return customer;
        }

        public static CustomerDto Dto()
        {
            return new CustomerDto
            {
                BankAccountNumber = "123",
                CountryCode = "PK",
                DateOfBirth = new DateTime(1992, 02, 01),
                Email = "sara.ahmadi@gmail.com",
                FirstName = "sara",
                LastName = "ahmadi",
                PhoneNumber = "03336323900"         
            };
        }
    }
}
