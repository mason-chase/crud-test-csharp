using PhoneNumbers;

namespace Mc2.CrudTest.Domain.Validators
{
    public static class MobileValidator
    {
        public static bool Validate(string phoneNumber)
        {
            if (!phoneNumber[0].Equals("+"))
                phoneNumber = ("+" + phoneNumber);

            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            return phoneNumberUtil.GetNumberType(phoneNumberUtil.Parse(phoneNumber.Trim(), null)) == PhoneNumberType.MOBILE;
        }
    }
}