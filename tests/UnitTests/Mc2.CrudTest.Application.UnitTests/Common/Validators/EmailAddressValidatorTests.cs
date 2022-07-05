using Xunit;
using FluentValidation;
using FluentValidation.Validators;
using Mc2.CrudTest.Application.Common.Validators;

namespace Mc2.CrudTest.Application.UnitTests.Common.Validators
{
    public class EmailAddressValidatorTests
    {
        private IPropertyValidator<string, string> validator;

        public EmailAddressValidatorTests()
        {
            validator = new EmailAddressValidator<string>();
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
        [InlineData("     ")]
        [InlineData("json200 @tomas.com")]
        public void Should_Be_InValid_If_Contains_WhiteSpace(string value)
        {
            Assert.False(Validate(value));
        }

        [Theory]
        [InlineData("@domain.com")]
        public void Should_Be_InValid_Without_Username(string value)
        {
            Assert.False(Validate(value));
        }

        [Theory]
        [InlineData("json.tomas")]
        [InlineData("json.tomas@")]
        public void Should_Be_InValid_Without_Domain_Name(string value)
        {
            Assert.False(Validate(value));
        }

        [Theory]
        [InlineData("json.tomas")]
        [InlineData("json.tomas.com")]
        public void Should_Be_InValid_Without_Atsig_Symbol(string value)
        {
            Assert.False(Validate(value));
        }

        [Theory]
        [InlineData("json.tomas@gmail.com")]
        [InlineData("json2omas@domain.com")]
        [InlineData("json_tomas@domain.com")]
        public void Should_Be_Valid_With_Username_Domain_Name_And_Atsig_Symbol(string phoneNumber)
        {
            Assert.True(Validate(phoneNumber));
        }

        private bool Validate(string emailAddress)
        {
            return validator.IsValid(new ValidationContext<string>(emailAddress), emailAddress);
        }
    }
}
