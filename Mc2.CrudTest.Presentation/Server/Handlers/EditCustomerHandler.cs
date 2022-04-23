using Mc2.CrudTest.DataLayer.Entities;
using Mc2.CrudTest.DataLayer.Repository;
using Mc2.CrudTest.Presentation.Server.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Handlers
{
    public class EditCustomerHandler : IRequestHandler<EditCustomerRequest, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public EditCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Customer> Handle(EditCustomerRequest request, CancellationToken cancellationToken)
        {
            string input = request.BankAccountNumber;
            string[] splited = input.Split('-');
            if (splited.Length != 4) splited = input.Split(' ');
            bool isValid = splited.All(a => a.Length == 4) && !splited.Any(a => a.Any(b => b < 48 || b > 57));
            if (!isValid) return null;
            if (!IsValidEmail(request.Email)) return null;
            Customer customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                BankAccountNumber = request.BankAccountNumber
            };
            try
            {
                _customerRepository.EditEntity(customer);
                await _customerRepository.SaveChanges();
            }
            catch
            {
                return null;
            }
            return customer;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
