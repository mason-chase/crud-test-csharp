using PhoneNumbers;

namespace Mc2.CrudTest.Domain.DomainService.Customer
{
    public class CustomerDomainService
    {
        public bool CheckPhoneNumberValidation(string phoneNumber,string region)
        {
            string resultPhoneNumber;
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            try

            {
                PhoneNumber queryPhoneNumber = phoneUtil.Parse(phoneNumber, region);

                if (phoneUtil.IsValidNumber(queryPhoneNumber))
                {
                    resultPhoneNumber = queryPhoneNumber.NationalNumber.ToString();
                    return true;
                }
                return false;
            }

            catch

            {
                return false;
            }
        }
    }
}
