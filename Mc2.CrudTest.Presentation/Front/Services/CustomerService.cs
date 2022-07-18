using Mc2.CrudTest.Presentation.Front.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Front.Services
{
    public class CustomerService : ICustomerService
    {
        private const string URL = "/api/customers";
        private readonly HttpClient _client;
        public CustomerService(HttpClient client)
        {
            _client = client;
        }

        public async Task Create(CustomerViewModel customer)
        {
            var response = await _client.PostAsJsonAsync(URL, customer);
            response.EnsureSuccessStatusCode();

         }

        public async Task Delete(int id)
        {
            var response = await _client.DeleteAsync($"URL/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<CustomerViewModel>> GetALL()
        {
            var response = await _client.GetFromJsonAsync<List<CustomerViewModel>>(URL);
            return response;
        }

        public async Task Update(CustomerViewModel customer)
        {
            var response = await _client.PutAsJsonAsync(URL, customer);
            response.EnsureSuccessStatusCode();
        }
    }
}
