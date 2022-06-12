using Mc2.CrudTest.Persistence;
using Mc2.CrudTest.Persistence.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<CustomerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"),
                b => b.MigrationsAssembly(typeof(CustomerDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<ICustomerDbContext>(provider => provider.GetService<CustomerDbContext>());
            return services;
        }
    }
}
