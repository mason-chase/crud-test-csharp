using Mc2.CrudTest.Data.EF.DatabaseContext;
using Mc2.CrudTest.Data.EF.Repositories.Concretes;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using PhoneNumbers;

namespace Mc2.CrudTest.Services.Concretes
{
    public class CustomerService : EFRepository<Customer>, ICustomerService
    {
        public CustomerService(AppDbContext context) : base(context)
        {
        }

        public async ValueTask<string?> GetPhoneNumberAsync(string phoneNumberRaw, string countryCodeSelected)
        {
            try
            {
                var phoneNumberUtil = PhoneNumberUtil.GetInstance();

                //var regCode = phoneNumberUtil.GetRegionCodeForCountryCode(44);

                PhoneNumber queryPhoneNumber = phoneNumberUtil.Parse(phoneNumberRaw, countryCodeSelected);

                if (phoneNumberUtil.IsValidNumber(queryPhoneNumber))
                {
                    var resultPhoneNumber = queryPhoneNumber.NationalNumber.ToString();

                    return await Task.FromResult(resultPhoneNumber);
                }

                return default;
            }
            catch (NumberParseException npex)
            {
                throw new NumberParseException(npex.ErrorType, npex.Message);
            }
        }

        public async ValueTask<Customer[]> GetCustomersAsync(CancellationToken cancellationToken = default)
        {
            var Customers1 = await GetAllAsync(cancellationToken);

            var Customers2 = await Context.Customers.ToListAsync(cancellationToken);

            var customers3 = await Entities
                .AsNoTrackingWithIdentityResolution()
                .ToArrayAsync(cancellationToken)
            ;

            return customers3;
        }
    }
}
