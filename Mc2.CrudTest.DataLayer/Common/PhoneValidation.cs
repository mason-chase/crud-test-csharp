using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneNumbers;

namespace Mc2.CrudTest.DataLayer.Common
{
    public class PhoneValidation
    {
        public bool PhoneIsValid(string phoneNumber)
        {
            #region Phone Validation

            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            try
            {
                PhoneNumber numberProto = phoneUtil.Parse(phoneNumber, "US");
                var validate = phoneUtil.IsValidNumber(numberProto);
                if (!validate)
                {
                    return false;
                }
                return true;
            }
            catch (NumberParseException e)
            {
                return false;
            }

            #endregion
        }
    }
}
