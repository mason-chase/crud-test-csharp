using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using MediatR;
using c2.CrudTest.Application.CommandHandler;
using c2.CrudTest.Application.Commands;
using Mc2.CrudTest.Infrastructure;
using c2.CrudTest.Application.QueriesHandler;
using c2.CrudTest.Application.Queries;
using System.Collections.Generic;
using Mc2.CrudTest.Domain.Models.Entities;
using c2.CrudTest.Application.Validators;
using FluentValidation;

namespace Mc2.CrudTest.Presentation.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors(option => option.AddPolicy("MyCrudPolicy", builder => {
            //    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            //}));

            services.AddControllers();
            services.AddRazorPages();

            services.AddPersistence(Configuration);

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IRequestHandler<CreateCustomerCommand, bool>, CreateCustomerCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteCustomerByIdCommand, int>, DeleteCustomerByIdCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateCustomerCommand, CustomerEntity>, UpdateCustomerCommandHandler>();
            services.AddTransient<IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerEntity>>, GetAllCustomersQueryHandler>();
            services.AddTransient<IRequestHandler<GetCustomerByIdQuery, CustomerEntity>, GetCustomerByIdQueryHandler>();

            services.AddTransient<IValidator<CustomerEntity>, CustomerFluentValidation>();

            services.AddSwaggerGen(c =>
            {
                //c.IncludeXmlComments(string.Format(@"{0}\CQRS.WebApi.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mc2.CrudTest.Presentation.Server", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mc2.CrudTest.Presentation.Server v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
