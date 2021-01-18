using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WiProTest.App;
using WiProTest.App.Interfaces;
using WiProTest.Domain.Interfaces.Repositories;
using WiProTest.Domain.Interfaces.Services;
using WiProTest.Infra.Data.Context;
using WiProTest.Infra.Data.Repositories;

namespace WiProTest.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.AddDbContext<WiProTestContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API WiPro",
                    Version = "v1"
                });
            });

            services.AddControllers().AddNewtonsoftJson();

            //Apps
            services.AddScoped<IMoedaApp, MoedaApp>();

            //Services
            services.AddScoped<IMoedaService, MoedaService>();

            //Repositories
            services.AddScoped<IRepositoryMoeda, RepositoryMoeda>();
            services.AddScoped<IRepositoryLote, RepositoryLote>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => options.AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API WiPro - v1");
                c.RoutePrefix = string.Empty;
            });

        }
    }
}
