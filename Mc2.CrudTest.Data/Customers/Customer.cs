using Mc2.CrudTest.Common;
using System;

namespace Mc2.CrudTest.Customers
{
    public class Customer : BaseEntity
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }
    }
}
