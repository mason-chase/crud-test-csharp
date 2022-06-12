using Mc2.CrudTest.Domain.Models.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Front.Pages
{
    public class AddEditCustomerBase : ComponentBase
    {
        [Inject]
        HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int customerID { get; set; }

        protected string Title = "Add";
        public string PhoneNumber { get; set; }
        public CustomerEntity customer = new();
        protected List<CustomerEntity> cityList = new();

        protected string Error { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
        }

        protected override async Task OnParametersSetAsync()
        {
            if (customerID != 0)
            {
                Title = "Edit";
                customer = await Http.GetFromJsonAsync<CustomerEntity>("/api/Customer/GetCustomer?customerId=" + customerID);
            }
            else
            {
                customer.DateOfBirth = DateTime.Now;
            }
        }

        protected async Task SaveCustomer()
        {
            HttpResponseMessage response;
            
            if (customer.Id != 0)
                response = await Http.PutAsJsonAsync("api/Customer/UpdateCustomer?customerId=" + customer.Id, customer);
            else
            {
                response = await Http.PostAsJsonAsync("api/customer/addcustomer", customer);
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Error = "";
                Cancel();
            }
            else
                Error = "Bad Request Problem!!!!";
        }

        public void Cancel()
        {
            NavigationManager.NavigateTo("/");
        }
    }

}
