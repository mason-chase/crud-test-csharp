using Xunit;
using FluentValidation;
using FluentValidation.Validators;
using Mc2.CrudTest.Application.Common.Validators;

namespace Mc2.CrudTest.Application.UnitTests.Common.Validators
{
    public class PhoneNumberValidatorTests
    {
        private IPropertyValidator<string,string> validator;

        public PhoneNumberValidatorTests()
        {
            validator = new PhoneNumberValidator<string>();
        }

        [Theory]
        [InlineData("+33634556677")]
        [InlineData("+989109635899")]
        [InlineData("+351220409145")]
        public void Should_Be_Valid_PhoneNumber(string phoneNumber)
        {
            Assert.True(Validate(phoneNumber));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("a1b2c3d4f5")]
        [InlineData("0351220409145")]
        [InlineData("00351220409145")]
        public void Should_Be_InValid_PhoneNumber(string phoneNumber)
        {
            Assert.False(Validate(phoneNumber));
        }

        private bool Validate(string phoneNumber)
        {
            return validator.IsValid(new ValidationContext<string>(phoneNumber), phoneNumber);
        }
    }
}
