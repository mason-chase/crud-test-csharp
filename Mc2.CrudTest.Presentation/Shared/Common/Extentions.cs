using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Shared.Common
{
    public static class Extentions
    {
        /// <summary>
        ///  Email Validation that Works With Regex 
        /// </summary>
        /// <param name="email"> string of Email </param>
        /// <returns></returns>
        public static bool IsValidEmailAddress(this string email)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(email);
        }
        /// <summary>
        ///  TODO
        ///  Phone Number Validator 
        /// </summary>
        /// <param name="number"> string of Phone Number </param>
        /// <returns></returns>
        public static bool IsPhoneNumber(this string number)
        {
            return Regex.Match(number, @"^(\+[0-9]{9})$").Success;
        }
        /// <summary>
        ///  Validate Bank Account
        /// </summary>
        /// <param name="input">Bank Account Number</param>
        /// <returns></returns>
        public static bool IsValidBankAccount(this string input)
        {
            string[] splited = input.Split('-');
            if (splited.Length != 4) splited = input.Split(' ');
            for(int i=0; i< splited.Length; i++)
            {
                if(splited[i].Length!=4) return false;
                for(int j=0; j<4; j++)
                    if(splited[i][j]>57 || splited[i][j]<48) return false;
            }
            return true;
        }
    }
}
