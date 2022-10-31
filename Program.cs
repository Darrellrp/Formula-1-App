using Formula_1_App.Configurations;
using Formula_1_App.Context;
using Formula_1_App.Controllers;
using Formula_1_App.Factories;
using Formula_1_App.Factories.Interfaces;
using Formula_1_App.Hubs;
using Formula_1_App.Models;
using Formula_1_App.Repositories;
using Formula_1_App.Datasources;
using Formula_1_App.Seeders;
using Formula_1_App.Services;
using Formula_1_App.Subjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Formula_1_App.Caching;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment.IsProduction() ? ".env" : ".env.dev";
DotNetEnv.Env.Load(env);

builder.Services.AddTransient<DbContextOptions<Formula1DbContext>, DbContextOptions<Formula1DbContext>>();
builder.Services.AddTransient(typeof(IDatasourceAdapter<>), typeof(EntityFrameworkAdapter<>));
builder.Services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IDistributedCachingService, RedisDistributedCachingService>();
builder.Services.AddScoped(typeof(IService<>), typeof(BaseService<>));
builder.Services.AddScoped(typeof(ISubject<>), typeof(BaseSubject<>));
builder.Services.AddScoped(typeof(IApiController<>), typeof(BaseController<>));
builder.Services.AddTransient(typeof(EntityFrameworkAdapter<>), typeof(EntityFrameworkAdapter<>));
builder.Services.AddTransient(typeof(MongoAdapter<>), typeof(MongoAdapter<>));
builder.Services.AddScoped<MainEndpointFactory, MainEndpointFactory>();
builder.Services.AddScoped<EndpointFactory, EndpointFactory>();
builder.Services.AddTransient<DbContext, Formula1DbContext>();
builder.Services.AddSingleton<IConnectionMultiplexer>(
    sp => ConnectionMultiplexer.Connect(Environment.GetEnvironmentVariable("REDIS_CONNECTIONSTRING") ?? String.Empty)
);
builder.Services.AddScoped<IMultiplexerCachingService, RedisMultiplexerCachingService>();

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTIONSTRING");

builder.Services.AddDbContext<Formula1DbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add services to the container.
builder.Services.Configure<ApiConfiguration>(builder.Configuration.GetSection("ApiConfiguration"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRazorPages();

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin();
        });
});

var app = builder.Build();

if (args.Length != 0 && (args[0].Equals("-s") || args[0].Equals("--seed")))
{
    var seeder = new EFDatabaseSeeder(app.Services);
    int limit;

    try
    {
        if (args.Length > 1 && args[1] != null)
        {
            if (!int.TryParse(args[1], out limit))
            {
                Console.WriteLine("Invalid second parameter: seeding limit must be an integer");
                Environment.Exit(1);
                return;
            }

            await seeder.SeedAll(limit);
        }
        else
        {
            await seeder.SeedAll();
        }        
    }
    catch (Exception exception)
    {
        Console.WriteLine();
        Console.WriteLine($"An error occured during database seeding: {exception}");
    }

    Environment.Exit(1);
    return;
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

if(app.Environment.IsDevelopment())
{
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
               Path.Combine(builder.Environment.ContentRootPath, "ClientApp", "dist")),
        RequestPath = "/client-assets"
    });

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapHub<EntityHub>("/signalr");

app.MapRazorPages();

app.Run();
