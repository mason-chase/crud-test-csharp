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
        [InlineData(null)]
        public void Should_Be_InValid_For_Null(string value)
        {
            Assert.False(Validate(value));
        }

        [Theory]
        [InlineData("")]
        public void Should_Be_InValid_For_Empty_String(string value)
        {
            Assert.False(Validate(value));
        }

        [Theory]
        [InlineData("+35122040914 5")]
        public void Should_Be_InValid_If_Contains_Space(string value)
        {
            Assert.False(Validate(value));
        }

        [Theory]
        [InlineData("     ")]
        public void Should_Be_InValid_If_Contains_WhiteSpace(string value)
        {
            Assert.False(Validate(value));
        }

        [Theory]
        [InlineData("abcdefghijk")]
        public void Should_Be_InValid_For_Alphabets(string value)
        {
            Assert.False(Validate(value));
        }

        [Theory]
        [InlineData("a1b2c3d4e5")]
        public void Should_Be_InValid_For_AlphaNumerics(string value)
        {
            Assert.False(Validate(value));
        }

        [Theory]
        [InlineData("1220409145")]
        [InlineData("00351220409145")]
        public void Should_Be_InValid_Without_Plus_And_Country_Code_At_First(string value)
        {
            Assert.False(Validate(value));
        }

        [Theory]
        [InlineData("+33634556677")]
        [InlineData("+989109635899")]
        [InlineData("+351220409145")]
        public void Should_Be_Valid_With_Plus_And_Country_Code(string phoneNumber)
        {
            Assert.True(Validate(phoneNumber));
        }

        private bool Validate(string phoneNumber)
        {
            return validator.IsValid(new ValidationContext<string>(phoneNumber), phoneNumber);
        }
    }
}
