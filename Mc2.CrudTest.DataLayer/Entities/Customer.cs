using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.DataLayer.Entities
{
    public class Customer
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public int BankAccountNumber { get; set; }



    }
}
