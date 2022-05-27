using Mc2.CrudTest.Dtos;
using System;

namespace Mc2.CrudTest.Customers.Dtos
{
    public class UpsertCustomerInput
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
