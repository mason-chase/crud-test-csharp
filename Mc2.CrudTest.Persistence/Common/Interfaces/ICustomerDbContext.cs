using Mc2.CrudTest.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Persistence.Common.Interfaces
{
    public interface ICustomerDbContext
    {
        DbSet<CustomerEntity> Customers { get; set; }
        Task<int> SaveChangesAsync();
    }
}
