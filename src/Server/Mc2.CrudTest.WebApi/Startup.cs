using Mc2.CrudTest.Application.Repositories;
using Mc2.CrudTest.Domain.Commands.Repositories;
using Mc2.CrudTest.Queries.Contracts;
using Mc2.CrudTest.Queries.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Mc2.CrudTest.WebApi
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<IGetCustomerListQuery, GetCustomerListQuery>();
            services.AddTransient<IGetCustomerQuery, GetCustomerQuery>();


            services.AddCors();

            services.AddControllers(options =>
            {
                options.AllowEmptyInputInBodyModelBinding = true;

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
