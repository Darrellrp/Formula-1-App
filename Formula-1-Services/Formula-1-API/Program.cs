﻿using Formula_1_API;
using Formula_1_API.Configurations;
using Formula_1_API.Context;
using Formula_1_API.Controllers;
using Formula_1_API.Factories;
using Formula_1_API.Hubs;
using Formula_1_API.Repositories;
using Formula_1_API.Datasources;
using Formula_1_API.Services;
using Formula_1_API.Subjects;
using Microsoft.EntityFrameworkCore;
using Formula_1_API.Caching;
using StackExchange.Redis;
using Formula_1_API.Seeders;

var builder = WebApplication.CreateBuilder(args);
var solutionPath = Directory.GetParent(Environment.CurrentDirectory)?.FullName;
var clientAppPath = Path.Combine(solutionPath!, "Formula-1-Web", "dist");
var forceDisableHttps = Boolean.Parse(Environment.GetEnvironmentVariable("FORCE_DISABLE_HTTPS") ?? "false");

if (builder.Environment.IsDevelopment())
{
    var env = Path.Combine(solutionPath!, ".env.dev");
    DotNetEnv.Env.Load(env);
}

// Add services to the container
builder.Services.AddTransient<DbContextOptions<Formula1DbContext>, DbContextOptions<Formula1DbContext>>();
builder.Services.AddTransient(typeof(IDatasourceAdapter<>), typeof(EntityFrameworkAdapter<>));
builder.Services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IDistributedCachingService, RedisDistributedCachingService>();
builder.Services.AddScoped(typeof(IService<>), typeof(BaseService<>));
builder.Services.AddScoped(typeof(ISubject<>), typeof(BaseSubject<>));
builder.Services.AddScoped(typeof(IApiController<>), typeof(BaseController<>));
builder.Services.AddTransient(typeof(EntityFrameworkAdapter<>), typeof(EntityFrameworkAdapter<>));
builder.Services.AddTransient(typeof(MongoAdapter<>), typeof(MongoAdapter<>));
builder.Services.AddTransient<IDatabaseMigrator, EFDatabaseMigrator>();
builder.Services.AddTransient<IDatabaseSeeder, EFDatabaseSeeder>();
builder.Services.AddScoped<MainEndpointFactory, MainEndpointFactory>();
builder.Services.AddScoped<EndpointFactory, EndpointFactory>();
builder.Services.AddScoped<EntityCollectionLabelFactory, EntityCollectionLabelFactory>();
builder.Services.AddTransient<DbContext, Formula1DbContext>();
builder.Services.AddSingleton<IConnectionMultiplexer>(
    sp => ConnectionMultiplexer.Connect(Environment.GetEnvironmentVariable("REDIS_CONNECTIONSTRING") ?? throw new Exception("Redis connectionstring has not been provided"))
);
builder.Services.AddScoped<IMultiplexerCachingService, RedisMultiplexerCachingService>();

builder.Services.AddDbContext<Formula1DbContext>();

builder.Services.Configure<ApiConfiguration>(builder.Configuration.GetSection("ApiConfiguration"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = clientAppPath;
});

builder.Services.AddRazorPages();

builder.Services.AddSignalR();

builder.Services.AddCors();

var app = builder.Build();

// Seed database
if (args.Any())
{
    // Invoke Commands
    var commandHandler = new CommandHandler(app, args);
    await commandHandler.InvokeCommands();
    Environment.Exit(1);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment() && !forceDisableHttps)
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (!forceDisableHttps)
{
    app.UseHttpsRedirection();
}

if (app.Environment.IsDevelopment())
{
    app.UseSpaStaticFiles();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors(policy => policy.AllowAnyOrigin());

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapHub<EntityHub>("/signalr");

app.MapRazorPages();

app.Run();
