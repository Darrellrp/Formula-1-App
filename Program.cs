using Formula_1_App.Configurations;
using Formula_1_App.Seeders;
using Microsoft.Extensions.FileProviders;

if (args.Length != 0 && (args[0].Equals("-s") || args[0].Equals("--seed")))
{
    Console.WriteLine("Seeding Database...");
    EFDatabaseSeeder.SeedAll();
    System.Environment.Exit(1);
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ApiConfiguration>(builder.Configuration.GetSection("ApiConfiguration"));

builder.Services.AddControllers();

builder.Services.AddRazorPages();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "ClientApp", "dist")),
    RequestPath = "/client-assets"
});
app.UseRouting();

app.UseCors();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

//app.MapFallbackToFile("index.html");
app.MapRazorPages();

app.Run();
