using Mc2.CrudTest.Domain.Validators;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Customers.Validators
{
    public class EmailValidatorTest
    {
        [Theory]
        [InlineData("taher.l", false)]
        [InlineData("th@", false)]
        [InlineData("taherfattahi11@gmail.com", true)]
        public void EmailValidatorTest_ExpectedResult(string email, bool Expectation)
        {
            var result = EmailValidator.Validate(email);
            Assert.Equal(result, Expectation);
        }
    }
}
