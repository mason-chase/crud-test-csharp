namespace Mc2.CrudTest.Presentation.Server.Queries
{
    using Dapper;
    using global::Domain;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class CustomerQueries
        : ICustomerQueries
    {
        private string _connectionString = string.Empty;

        public CustomerQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }


        public async Task<Customer> GetCustomerAsync(int id)
        {
            using var connection = new Microsoft.Data.SqlClient.SqlConnection(_connectionString);
            connection.Open();

            var result = await connection.QueryAsync<dynamic>(
               @"select c.[Id] as Id,c.FirstName as FirstName, c.LastName as LastName,c.Birthdate as BirthDate,
                        c.Email as Email, c.PhoneNumber as PhoneNumber, c.BankAccountNumber as BankAccountNumber,
                        WHERE c.Id=@id"
                    , new { id }
                );

            if (result.AsList().Count == 0)
                throw new KeyNotFoundException();

            return MapCustomer(result);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            using (var connection = new Microsoft.Data.SqlClient.SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                   @"select c.[Id] as Id,o.FirstName as FirstName, c.LastName as LastName,c.Birthdate as BirthDate,
                        c.Email as Email, c.PhoneNumber as PhoneNumber, c.BankAccountNumber as BankAccountNumber");

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapCustomersList(result);
            }
        }

        private Customer MapCustomer(dynamic result)
        {
            var customer = new Customer(null, result[0].FirstName, result[0].LastName, result[0].BirthDate, result[0].PhoneNumber, result[0].Email, result[0].BankAccountNumber);

            return customer;
        }
        private IEnumerable<Customer> MapCustomersList(dynamic result)
        {

            var customers = new List<Customer>();
            foreach (var item in result)
            {
                var customer = new Customer(null, item.FirstName, item.LastName, item.BirthDate, item.PhoneNumber, item.Email, item.BankAccountNumber);
                customers.Add(customer);
            }
            return customers;
        }
    }
}
