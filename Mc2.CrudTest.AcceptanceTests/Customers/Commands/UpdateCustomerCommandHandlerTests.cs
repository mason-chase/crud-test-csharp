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
    public class UpdateCustomerCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateCustomerCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateCustomerCommandHandler(_context);

            var id = 1;
            var firstName = "Taher 12";
            var lastName = "Fattahi 12";
            var dateOfBirth = new DateTime(2019, 1, 22, 6, 0, 0);
            ulong phoneNumber = 989115467885;
            var email = "taherfatta114@gmail.com";
            var bankAccountNumber = "6037-9917-0000-0000";

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

            var customer = await handler.Handle(new UpdateCustomerCommand
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                PhoneNumber = phoneNumber,
                Email = email,
                BankAccountNumber = bankAccountNumber
            }, CancellationToken.None);

            // Assert
            Assert.True(testMobileValidatorResult);
            Assert.True(testBankAccountValidatorResult);
            Assert.True(testEmailValidatorResult);
            Assert.NotNull(await _context.Customers.SingleOrDefaultAsync(customer =>
                customer.Id == id && customer.FirstName == firstName));
        }

        //[Fact]
        //public async Task UpdateNoteCommandHandler_FailOnWrongId()
        //{
        //    // Arrange
        //    var handler = new UpdateNoteCommandHandler(Context);

        //    // Act
        //    // Assert
        //    await Assert.ThrowsAsync<NotFoundException>(async () =>
        //        await handler.Handle(
        //            new UpdateNoteCommand
        //            {
        //                Id = Guid.NewGuid(),
        //                UserId = NotesContextFactory.UserAId
        //            }, CancellationToken.None));
        //}

        //[Fact]
        //public async Task UpdateNoteCommandHandler_FailOnWrongUserId()
        //{
        //    // Arrange
        //    var handler = new UpdateNoteCommandHandler(Context);

        //    // Act
        //    // Assert
        //    await Assert.ThrowsAsync<NotFoundException>(async () =>
        //    {
        //        await handler.Handle(
        //            new UpdateNoteCommand
        //            {
        //                Id = NotesContextFactory.NoteIdForUpdate,
        //                UserId = NotesContextFactory.UserAId
        //            }, CancellationToken.None);
        //    });
        //}
    }
}
