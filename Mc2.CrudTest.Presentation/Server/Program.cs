using Mc2.CrudTest.Bootstrapper.Startup;

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

await app.RunAsync();