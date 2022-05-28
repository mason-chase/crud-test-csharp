using Mc2.CrudTest.Domain.DTO;
using RestSharp;
using System.Net;

namespace Mc2.CrudTest.SpecFlow.Specs.API;

public class CustomersApi
{
    private readonly RestClient _client;

    public CustomersApi()
    {
        _client = new RestClient("https://localhost:5001");

        ServicePointManager.ServerCertificateValidationCallback +=
            (sender, cert, chain, sslPolicyErrors) => true;
    }

    public async Task<int?> AddAsync()
    {
        var request = new RestRequest("/customers/create").AddObject(NewCustomer());

        var response = await _client.GetAsync<CustomerResponse>(request);

        return response?.Result;
    }

    public static CreateCustomerDTO NewCustomer() => new()
    {
        FirstName = "Sinjul13",
        LastName = "MSBH13",
        DateOfBirth = DateTimeOffset.UtcNow,
        Email = "sinjul.msbh13@yahoo.com",
        PhoneNumber = "+44 123 456 904",
        CountryCodeSelected = "US",
        BankAccountNumber = "130",
    };
}

internal sealed class CustomerResponse
{
    public int Result { get; set; }
}
