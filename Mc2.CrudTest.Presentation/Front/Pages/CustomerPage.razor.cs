using Mc2.CrudTest.Domain.Models.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Front.Pages
{
    public class CustomerPageBase : ComponentBase
    {
        [Inject]
        HttpClient Http { get; set; }

        protected List<CustomerEntity> customerList = new();
        protected List<CustomerEntity> searchEmpData = new();
        protected CustomerEntity customer = new();
        protected string SearchString { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await GetCustomers();
        }

        protected async Task GetCustomers()
        {
            customerList = await Http.GetFromJsonAsync<List<CustomerEntity>>("/api/customer/getcustomers");
            searchEmpData = customerList;
        }

        protected void FilterCustomer()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                customerList = customerList
                    .Where(x => x.FirstName.ToLower().IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1)
                    .ToList();
            }
            else
            {
                customerList = searchEmpData;
            }
        }

        protected void DeleteConfirm(int customerId)
        {
            customer = customerList.FirstOrDefault(x => x.Id == customerId);
        }

        protected async Task DeleteCustomer(int customerId)
        {
            await Http.DeleteAsync("api/Customer/DeleteCustomer?customerId=" + customerId);
            await GetCustomers();
        }

        public void ResetSearch()
        {
            SearchString = string.Empty;
            customerList = searchEmpData;
        }
    }
}
