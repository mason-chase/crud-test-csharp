using Mc2.CrudTest.Domain.Validators.Common;

namespace Mc2.CrudTest.Api.Test;

public class MobileValidatorTests
{
    [Theory]
    [InlineData("+989121234567", true)]
    [InlineData("+31651234567", true)]
    public void MobileValidatorTest_WithExpectedResult(string phoneNumber, bool expectedResult)
    {
        bool testResult = MobileValidator.Validate(phoneNumber);
        
        Assert.Equal(expectedResult, testResult);
    }
}