using Domain;
using Domain.AggregatesModel.CustomerAggregate;
using Domain.Seedwork;
using Infrastructure;
using Mc2.CrudTest.Presentation.Server.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Services
{
    public class CustomerService:ICustomerService
    {
        private ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Customer AddCustomer(Customer model)
        {
            return _repository.Add(model);
        }

        public List<Customer> GetAllCustomers()
        {
            var query = from b in _repository.GetAll()
                        orderby b.Lastname
                        select b;

            return query.ToList();
        }


        public void DeleteCustomer(int id)
        {
            _repository.Delete(id);
        }
    }
}
