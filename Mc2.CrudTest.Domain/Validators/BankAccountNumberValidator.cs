using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Validators
{
    public static class BankAccountNumberValidator
    {
        public static bool Validate(string bankNumber)
        {
            //string input = "0000-0000-0000-0000";
            string[] splited = bankNumber.Split('-');
            if (splited.Length != 4) return false;
            for (int i = 0; i < splited.Length; i++)
                if (splited[i].Length != 4) return false;
            return true;
        }
    }
}
