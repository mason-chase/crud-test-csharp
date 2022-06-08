using System.Text.RegularExpressions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PhoneNumbers;

namespace CleanArchitecture.Domain.Common;

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
    ///  Validate Phone Number
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <returns></returns>
    public static bool PhoneIsValid(this string phoneNumber)
    {

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
        for (int i = 0; i < splited.Length; i++)
        {
            if (splited[i].Length != 4) return false;
            for (int j = 0; j < 4; j++)
                if (splited[i][j] > 57 || splited[i][j] < 48) return false;
        }
        return true;
    }
}
