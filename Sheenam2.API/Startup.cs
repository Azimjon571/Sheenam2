//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sheenam2.API.Brokers.Loggings;
using Sheenam2.API.Brokers.Storages;
using Sheenam2.API.Models.Foundations.Guests;
using Sheenam2.API.Services.Foundations.Guests;
using Sheenam2.API.Services.Foundations.Hosts;

namespace Sheenam2.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;


        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var apiInfo = new OpenApiInfo
            {
                Title = "Sheenam2.API",
                Version = "v1"
            };

            services.AddDbContext<StorageBroker>();
            services.AddControllers();
            AddBrokers(services);
            AddFoundationServices(services);

            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc(
                    name: "v1",
                    info: apiInfo);
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint(
                      url: "/swagger/v1/swagger.json",
                      name: "Sheenam2.API v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                endpoints.MapControllers());

        }
        private static void AddBrokers(IServiceCollection services)
        {
            services.AddTransient<IStorageBroker, StorageBroker>();
            services.AddTransient<ILoggingBroker, LoggingBroker>();
        }
        private static void AddFoundationServices(IServiceCollection services)
        {
            services.AddTransient<IGuestService, GuestService>();
            services.AddTransient<IHostService, HostService>();
        }

    }
}
