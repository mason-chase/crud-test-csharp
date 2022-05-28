using Mc2.CrudTest.Data.EF.Repositories.Interfaces;
using Mc2.CrudTest.Domain.Entities;
using PhoneNumbers;

namespace Mc2.CrudTest.Services.Interfaces;

public interface ICustomerService : IEFRepository<Customer>
{
    ValueTask<Customer[]> GetCustomersAsync(CancellationToken cancellationToken = default);

    ValueTask<string?> GetPhoneNumberAsync(string phoneNumberRaw, string countryCodeSelected);
}