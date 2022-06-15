

using Mc2.CrudTest.Infrastructure.persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region AddSqlServer
            services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("SqlServer")));
            #endregion
            #region AddServices Life Time
            services.AddScoped<IApplicationDbContext, AppDbContext>();
            #endregion
            return services;
        }

    }
}
