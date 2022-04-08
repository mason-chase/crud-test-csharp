using DotNetCore.AspNetCore;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.IoC;
using DotNetCore.Logging;
using DotNetCore.Security;
using Mc2.CrudTest.Application;
using Mc2.CrudTest.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

var builder = WebApplication.CreateBuilder();

builder.Host.UseSerilog();

builder.Services.AddAuthenticationJwtBearer(new JwtSettings(Guid.NewGuid().ToString(), TimeSpan.FromHours(12)));

builder.Services.AddResponseCompression();

builder.Services.AddControllers().AddJsonOptions().AddAuthorizationPolicy();

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddContext<Context>(options => options.UseSqlServer(builder.Services.GetConnectionString(nameof(Context))));

builder.Services.AddClassesMatchingInterfaces(typeof(ICustomerService).Assembly, typeof(ICustomerRepository).Assembly);

builder.Services.AddClassesMatchingInterfaces(typeof(ICustomerService).Assembly, typeof(ICustomerService).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();

app.UseStaticFiles();

app.UseHttps();

app.UseRouting();

app.UseResponseCompression();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers().WithMetadata(new AllowAnonymousAttribute()); 
    endpoints.MapFallbackToFile("index.html");
});


app.UseEndpointsMapControllers();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer Crud Api V1");
});

app.Run();


