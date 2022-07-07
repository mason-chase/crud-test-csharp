using Mc2.CrudTest.SpamDetector_LbfgsLogisticRegression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Customers.Validators
{
    public class EmailSpamDetectorValidatorTest
    {
        [Theory]
        [InlineData("Ok lar... Joking wif u oni...", "ham")]
        [InlineData("England v Macedonia - dont miss the goals/team news. Txt ur national team to 87077 eg ENGLAND to 87077 Try:WALES, SCOTLAND 4txt/ÃŒÂ¼1.20 POBOXox36504W45WQ 16+", "spam")]
        [InlineData("Thanks for your subscription to Ringtone UK your mobile will be charged Ã¥Â£5/month Please confirm by replying YES or NO. If you reply NO you will not be charged", "spam")]
        public void EmailSpamDetectorValidatorTest_ExpectedResult(string emailWord, string expectedResult)
        {
            string testResult = EmailSpamDetectorClass.EmailSpamDetectorValidator(emailWord);

            Assert.Equal(expectedResult, testResult);
        }
    }
}
