var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRazorPages();

builder.Services.AddConfigureServices(builder.Host, builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseConfigure(builder.Environment, builder.Configuration);

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.MapControllers();
app.MapRazorPages();
app.MapFallbackToFile("index.html");

//using var scope = app.Services.CreateScope();
//var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//if (db.Database.GetPendingMigrations().Any()) await db.Database.MigrateAsync();

app.MapGet("/weatherforecast", (HttpContext httpContext) =>
{
    List<WeatherForecast> response = WeatherForecastGenerator.GenerateWeatherForecast();

    IPAddress? userIp = httpContext?.Connection?.RemoteIpAddress;

    app.Logger.LogInformation($"[Request from {userIp}: Serving Get() response: {string.Join("\n", response.ToList())}");

    return response;
})
.WithName("GetWeatherForecast")
;

app.MapGet("/getcustomers", async (ICustomerService customerService) =>
{
    var customers = await customerService.GetCustomersAsync();

    return Results.Ok(customers);
})
.WithName("GetCustomers")
;

app.MapGet("/customers/getall", async (IMediator mediator) =>
{
    var customers = await mediator.Send(new GetAllCustomerQuery());

    return Results.Ok(customers);
})
.WithName("GetAllCustomer")
;

app.MapGet("/customers/get/{id}", async (Guid id, IMediator mediator) =>
{
    var customer = await mediator.Send(new GetCustomerByIdQuery(id));

    return Results.Ok(customer);
})
.WithName("GetCustomer")
;

app.MapPost("/customers/create", async ([FromBody] CreateCustomerDTO model, IMediator mediator) =>
{
    try
    {
        var command = new CreateCustomerCommand(model);

        var responseCustomerId = await mediator.Send(command);

        //return Results.StatusCode((int)HttpStatusCode.Created);

        return Results.Created(string.Empty, responseCustomerId);
    }
    catch (InvalidRequestBodyException ex)
    {
        return Results.BadRequest(new BaseResponseDTO(false, ex.Errors));
    }
})
.WithName("CreateCustomer")
;


await app.RunAsync();