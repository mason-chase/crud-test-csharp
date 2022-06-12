using c2.CrudTest.Application.CommandHandler;
using c2.CrudTest.Application.Commands;
using Mc2.CrudTest.AcceptanceTests.Common;
using Mc2.CrudTest.Domain.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Customers.Commands
{
    public class CreateCustomerCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateCustomerCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateCustomerCommandHandler(_context);
            
            var firstName = "Taher123";
            var lastName = "Fattahi123";
            var dateOfBirth = new DateTime(2018, 1, 22, 6, 0, 0);
            ulong phoneNumber = 989115461885;
            var email = "taherfa@gmail.com";
            var bankAccountNumber = "6137-9917-0000-0000";

            // Act

            // unique Check
            var allCustomers = await _context.Customers.ToListAsync();
            for (int i = 0; i < allCustomers.Count; i++)
            {
                if (firstName.Equals(allCustomers[i].FirstName) || lastName.Equals(allCustomers[i].LastName) || email.Equals(allCustomers[i].Email) || dateOfBirth.Equals(allCustomers[i].DateOfBirth))
                {
                    Assert.Throws<Exception>(() => new Exception("FirstName-LastName-Email-DateOfBirth must be unique"));
                }
            }

            bool testMobileValidatorResult = MobileValidator.Validate(phoneNumber.ToString());
            bool testBankAccountValidatorResult = BankAccountNumberValidator.Validate(bankAccountNumber);
            bool testEmailValidatorResult = EmailValidator.Validate(email);

            var customerId = await handler.Handle(
                new CreateCustomerCommand
                {
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = dateOfBirth,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    BankAccountNumber = bankAccountNumber,
                }, CancellationToken.None);

            // Assert
            Assert.True(testMobileValidatorResult);
            Assert.True(testBankAccountValidatorResult);
            Assert.True(testEmailValidatorResult);
            Assert.True(customerId);
        }
    }
}
