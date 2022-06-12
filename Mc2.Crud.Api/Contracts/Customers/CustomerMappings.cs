using Mc2.CrudTest.Api.Contracts.Customers.Requests;
using Mc2.CrudTest.Api.Contracts.Customers.Responses;
using Mc2.CrudTest.Domain.Commands;
using Mc2.CrudTest.Domain.Entities;

namespace Mc2.CrudTest.Api.Contracts.Customers
{
    /// <summary>
    /// This mapper mapps the objects received in api to Application and domain objects and vise versa.
    /// </summary>
    public class CustomerMappings
    {
        /// <summary>
        /// Map Api Create object to Application Command object
        /// </summary>
        /// <param name="customerCreate"></param>
        /// <returns></returns>
        public static CreateCustomerCommand MapToCommand(CustomerCreate customerCreate)
        {
            return new CreateCustomerCommand
            {
                Firstname = customerCreate.Firstname,
                Lastname = customerCreate.Lastname,
                DateOfBirth = customerCreate.DateOfBirth,
                PhoneNumber = customerCreate.PhoneNumber,
                Email = customerCreate.Email,
                BankAccountNumber = customerCreate.BankAccountNumber
            };
        }
        /// <summary>
        /// Map Domain Object to API response object
        /// </summary>
        /// <param name="customerCreate"></param>
        /// <returns></returns>
        public static CustomerResponse MapToResponse(Customer customer)
        {
            return new CustomerResponse
            {
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                DateOfBirth = customer.DateOfBirth,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                BankAccountNumber = customer.BankAccountNumber
            };
        }

        public static UpdateCustomerCommand MapToUpdateCommand(CustomerCreate customerUpdate)
        {
            return new UpdateCustomerCommand
            {
                Id = customerUpdate.Id,
                Firstname = customerUpdate.Firstname.ToLower(),
                Lastname = customerUpdate.Lastname.ToLower(),
                DateOfBirth = customerUpdate.DateOfBirth,
                PhoneNumber = customerUpdate.PhoneNumber,
                Email = customerUpdate.Email,
                BankAccountNumber = customerUpdate.BankAccountNumber
            };
        }
    }
}
