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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<Formula1DbContext>(options => options.UseMySql(Configuration.GetConnectionString("Formula1DB")));

            services.AddScoped<IRepository<Circuit>, EFCircuitRepository>();
            services.AddScoped<IService<Circuit>, CircuitService>();

            services.AddScoped<IRepository<Constructor>, EFConstructorRepository>();
            services.AddScoped<IService<Constructor>, ConstructorService>();

            services.AddScoped<IRepository<ConstructorResult>, EFConstructorResultRepository>();
            services.AddScoped<IService<ConstructorResult>, ConstructorResultService>();

            services.AddScoped<IRepository<ConstructorStanding>, EFConstructorStandingRepository>();
            services.AddScoped<IService<ConstructorStanding>, ConstructorStandingService>();

            services.AddScoped<IRepository<Driver>, EFDriverRepository>();
            services.AddScoped<IService<Driver>, DriverService>();

            services.AddScoped<IRepository<DriverStanding>, EFDriverStandingRepository>();
            services.AddScoped<IService<DriverStanding>, DriverStandingService>();

            services.AddScoped<IRepository<LapTime>, EFLapTimeRepository>();
            services.AddScoped<IService<LapTime>, LapTimeService>();

            services.AddScoped<IRepository<PitStop>, EFPitStopRepository>();
            services.AddScoped<IService<PitStop>, PitStopService>();

            services.AddScoped<IRepository<Qualification>, EFQualificationRepository>();
            services.AddScoped<IService<Qualification>, QualificationService>();

            services.AddScoped<IRepository<Race>, EFRaceRepository>();
            services.AddScoped<IService<Race>, RaceService>();

            services.AddScoped<IRepository<RaceResult>, EFRaceResultRepository>();
            services.AddScoped<IService<RaceResult>, RaceResultService>();

            services.AddScoped<IRepository<ResultStatus>, EFResultStatusRepository>();
            services.AddScoped<IService<ResultStatus>, ResultStatusService>();

            services.AddScoped<IRepository<Season>, EFSeasonRepository>();
            services.AddScoped<IService<Season>, SeasonService>();

            services.AddScoped<BaseControllerFactory, BaseControllerFactory>();

            services.AddScoped<DbContext, Formula1DbContext>();
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
