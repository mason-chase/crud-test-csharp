using Mc2.CrudTest.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Customers.Validators
{
    public class BankAccountNumberValidatorTest
    {
        [Theory]
        [InlineData("6037-9917-0000-0000", true)]
        [InlineData("6037-9917-0123-0000", true)]
        [InlineData("6037-9917-0000-0000-000", false)]
        public void BankAccountNumberValidatorTest_ExpectedResult(string bankNumber, bool expectedResult)
        {
            bool testResult = BankAccountNumberValidator.Validate(bankNumber);

            Assert.Equal(expectedResult, testResult);
        }
    }
}
