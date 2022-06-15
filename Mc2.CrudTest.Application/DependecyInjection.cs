using Mc2.CrudTest.Application.Common.Behaviours;
using Mc2.CrudTest.Application.Common.Interfaces.EventStoreDbContext;
using Mc2.CrudTest.Application.Common.Interfaces.Repository;
using Mc2.CrudTest.Application.Common.Service;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mc2.CrudTest.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IEventStoreDbContext, EventStoreDbContext>();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(EventLoggerBehavior<,>));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            return services;
        }

    }
}
