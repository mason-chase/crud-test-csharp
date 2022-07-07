using Mc2.CrudTest.Domain.Validators;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Customers.Validators
{
    public class MobileValidatorTest
    {
        [Theory]
        [InlineData("+989123456789", true)]
        [InlineData("+31612345678", true)]
        [InlineData("+982188776655", false)]
        public void MobileValidatorTest_ExpectedResult(string phoneNumber, bool expectedResult)
        {
            bool testResult = MobileValidator.Validate(phoneNumber);

            Assert.Equal(expectedResult, testResult);
        }
    }
}