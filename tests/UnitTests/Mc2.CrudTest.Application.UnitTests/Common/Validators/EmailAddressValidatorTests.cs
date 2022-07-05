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
        [InlineData("json.tomas@gmail.com")]
        [InlineData("json2omas@domain.com")]
        [InlineData("json_tomas@domain.com")]
        public void Should_Be_Valid_EmailAddress(string phoneNumber)
        {
            Assert.True(Validate(phoneNumber));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("a1b2c3d4")]
        [InlineData("jsontomasgmail.com")]
        [InlineData("jsontomas@gmailcom")]
        [InlineData("json tomas@gmail.com")]
        public void Should_Be_InValid_EmailAddress(string phoneNumber)
        {
            Assert.False(Validate(phoneNumber));
        }

        private bool Validate(string emailAddress)
        {
            return validator.IsValid(new ValidationContext<string>(emailAddress), emailAddress);
        }
    }
}
