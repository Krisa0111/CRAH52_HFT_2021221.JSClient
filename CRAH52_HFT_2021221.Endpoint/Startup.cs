using CRAH52_HFT_2021221.Data;
using CRAH52_HFT_2021221.Endpoint.Services;
using CRAH52_HFT_2021221.Logic;
using CRAH52_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRAH52_HFT_2021221.Endpoint
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRAH52_HFT_2021221.Endpoint", Version = "v1" });
            });
            services.AddControllers();

            services.AddTransient<IClubsLogic, ClubsLogic>();
            services.AddTransient<IEventsLogic, EventsLogic>();
            services.AddTransient<IGuestsLogic, GuestsLogic>();

            services.AddTransient<IClubsRepository, ClubsRepository>();
            services.AddTransient<IEventsRepository, EventsRepository>();
            services.AddTransient<IGuestsRepository, GuestsRepository>();

            services.AddTransient<ClubsDbContext, ClubsDbContext>();
            services.AddSignalR();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRAH52_HFT_2021221.Endpoint v1"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
