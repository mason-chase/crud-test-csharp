using Xunit;
using FluentValidation;
using FluentValidation.Validators;
using Mc2.CrudTest.Application.Common.Validators;

namespace Mc2.CrudTest.Application.UnitTests.Common.Validators
{
    public class BankAccountNumberValidatorTests
    {
        private IPropertyValidator<string, string> validator;

        public BankAccountNumberValidatorTests()
        {
            validator = new BankAccountNumberValidator<string>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_Be_InValid_For_Null_And_Empty_Strings(string bankAccountNumber)
        {
            Assert.False(Validate(bankAccountNumber));
        }

        [Theory]
        [InlineData("1")]
        [InlineData("1234567")]
        public void Should_Be_InValid_With_Less_Than_9_Digits(string bankAccountNumber)
        {
            Assert.False(Validate(bankAccountNumber));
        }

        [Theory]
        [InlineData("012345679101213141516")]
        public void Should_Be_InValid_With_More_Than_18_Digits(string bankAccountNumber)
        {
            Assert.False(Validate(bankAccountNumber));
        }

        [Theory]
        [InlineData("abcdefghijk")]
        public void Should_Be_InValid_For_Alphabets(string bankAccountNumber)
        {
            Assert.False(Validate(bankAccountNumber));
        }

        [Theory]
        [InlineData("a1b2c3d4e5")]
        public void Should_Be_InValid_For_AlphaNumerics(string bankAccountNumber)
        {
            Assert.False(Validate(bankAccountNumber));
        }

        [Theory]
        [InlineData("123456789")]
        [InlineData("0123456789")]
        [InlineData("012345678998765432")]
        public void Should_Be_Valid_With_9_To_18_Digits(string bankAccountNumber)
        {
            Assert.True(Validate(bankAccountNumber));
        }

        private bool Validate(string bankAccountNumber)
        {
            return validator.IsValid(new ValidationContext<string>(bankAccountNumber), bankAccountNumber);
        }
    }
}
