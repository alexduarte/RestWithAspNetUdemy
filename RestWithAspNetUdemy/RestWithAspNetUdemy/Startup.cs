using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RestWithAspNetUdemy.DataComunication.Mapping;
using RestWithAspNetUdemy.Infra.Context;
using RestWithAspNetUdemy.Repository;
using RestWithAspNetUdemy.Services;
using RestWithAspNetUdemy.Services.Interfaces;
using System;

namespace RestWithAspNetUdemy
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;
        private readonly ILogger _logger;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.ClearProviders();
                builder.AddConsole();
            });
            _logger = loggerFactory.CreateLogger<Startup>();           
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["ConnectionStrings:db_rest_with_azure"];
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestWithAspNetUdemy", Version = "v1" });
            });

            if (_env.IsDevelopment())
            {
                MigrateDataBase(connectionString);
            }

            services.AddApiVersioning();
            services.AddInfra();
            services.AddServices();
            
            services.AddDbContext<SQLContext>(opts => opts.UseSqlServer(connectionString));
            
            services.AddAutoMapper(typeof(PersonDtoToPerson));
        }

        private void MigrateDataBase(string connectionString)
        {
            try
            {
                var con = new SqlConnection(connectionString);
                var evolve = new Evolve.Evolve(con, msg => _logger.LogInformation($"Evolve: {msg}"))
                {
                    Locations = new[] { "db/dataset", "db/migrations" },
                    IsEraseDisabled = true
                };

                evolve.Migrate();
            }
            catch (Exception ex)
            {

                _logger.LogCritical($"Error while migrating database: {ex}");
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestWithAspNetUdemy v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
