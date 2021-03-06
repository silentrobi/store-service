using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StoreService.Database.Contexts;
using StoreService.Repositories;
using StoreService.Repositories.Category;
using StoreService.Services.Category;

namespace StoreService
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "store_service", Version = "v1" });
            });

            services.AddDbContext<StoreDbContext>(options =>
           {
               options.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionStrings"),
                      npSqlOptions =>
                      {
                          npSqlOptions.CommandTimeout(3300);
                      });
           });

            // auto mapper
            services.AddAutoMapper(cfg =>
             {
                 cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
             });

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "store_service v1"));
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
