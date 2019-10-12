using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Formula_1_API.Context;
using Formula_1_API.Repositories;
using Formula_1_API.Models;
using Formula_1_API.Services;
using Microsoft.EntityFrameworkCore;
using Formula_1_API.Factories;
using Formula_1_API.Subjects;
using Microsoft.AspNetCore.SignalR;
using Formula_1_API.Hubs;
using Formula_1_API.Controllers;
using Formula_1_API.Repositories.Interfaces;
using Formula_1_API.Repositories.Adapters;
using Formula_1_API.Services.Interfaces;
using Formula_1_API.Subjects.Interfaces;

namespace Formula_1_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddSignalR();

            services.AddScoped(typeof(IDatasourceAdapter<>), typeof(EntityFrameworkAdapter<>));
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IService<>), typeof(BaseService<>));
            services.AddScoped(typeof(ISubject<>), typeof(BaseSubject<>));
            services.AddScoped(typeof(BaseController<>), typeof(BaseController<>));
            services.AddScoped(typeof(EntityFrameworkAdapter<>), typeof(EntityFrameworkAdapter<>));
            services.AddScoped(typeof(MongoAdapter<>), typeof(MongoAdapter<>));                   


            services.AddScoped<DbContext, Formula1DbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<Formula1DbContext>(options => options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTIONSTRING")));                      
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }            

            //app.UseCors(config => config.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:8080")
                    .AllowAnyHeader()
                    .WithMethods("GET", "POST")
                    .AllowCredentials();
            });

            app.UseSignalR(routes =>
            {
                routes.MapHub<EntityHub>("/signalr");
            });

            app.UseHttpsRedirection();            
            app.UseMvc();            
        }
    }
}
