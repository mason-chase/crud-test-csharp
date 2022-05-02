using FluentAssertions;
using Mc2.CrudTest.Domain.Model.Exceptions;
using Mc2.CrudTest.Domain.Model.ValueObject;
using Mc2.CrudTest.TestTools;
using Xunit;

namespace Mc2.CrudTest.Domain.Model.Tests
{
    [Trait("(Domain) Customer", "")]
    public class BankAccountNumberTests
    {
        [Theory]
        [InlineData("123456")]
        [InlineData("741236988")]
        [InlineData("1023658")]
        void Create_BankAccountNumberCreated(string accountNumber)
        {
            var bankAccountNumber = BankAccountNumber.Create(accountNumber);

            bankAccountNumber.Value.Should().Be(accountNumber);
        }

        [Theory]
        [AutoMoqData]
        void Create_InvalidBankAccountNumberException(string accountNumber)
        {

            var thrownException = Try.CatchOrNull(() => BankAccountNumber.Create(accountNumber));

            thrownException.Should().NotBeNull();
            thrownException.Should()
                .BeOfType<InvalidBankAccountNumberException>();

        }
    }
}
