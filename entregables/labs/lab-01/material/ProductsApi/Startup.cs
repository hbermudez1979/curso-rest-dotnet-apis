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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace ProductsApi
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
            // Middleware
            services.AddControllers();// Middleware

            //services.AddSingleton<object[]>(new[] { new Models.Product { Id=1, Name="Pants" }, new Models.Product { Id = 2, Name = "Socks" } });
            services.AddSingleton<Repositories.ProducRepository>();
            //services.AddScoped<Repositories.ProducRepository>();
            //services.AddTransient<Repositories.ProducRepository>();
            services.AddCors(options =>
            {
                options.AddPolicy(name: "CORS",
                                  builder =>
                                  {
                                      builder.WithOrigins("https://localhost:80/")//pueden ser varios
                                                          .AllowAnyHeader()
                                                          .AllowAnyMethod()// GET, POST, PUT
                                                          .AllowCredentials();
                                  });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProductsApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductsApi v1"));

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
