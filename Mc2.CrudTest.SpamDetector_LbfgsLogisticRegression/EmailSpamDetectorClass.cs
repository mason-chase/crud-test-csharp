using Mc2_CrudTest_SpamDetector_LbfgsLogisticRegression;

namespace Mc2.CrudTest.SpamDetector_LbfgsLogisticRegression
{
    public class EmailSpamDetectorClass
    {
        public static string EmailSpamDetectorValidator(string emailWord)
        {
            //Load sample data
            var sampleData = new MLModel1.ModelInput()
            {
                Col1 = @emailWord,
            };

            //Load model and predict output
            var result = MLModel1.Predict(sampleData);
            
            return result.PredictedLabel;
        }
       
    }
}