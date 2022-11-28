using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using QBU9QL_HFT_2022231.Logic.Classes;
using QBU9QL_HFT_2022231.Logic.Interfaces;
using QBU9QL_HFT_2022231.Models;
using QBU9QL_HFT_2022231.Repository.Data;
using QBU9QL_HFT_2022231.Repository.Interfaces;
using QBU9QL_HFT_2022231.Repository.Repositories;

namespace QBU9QL_HFT_2022231.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<MotoDbContext>();

            services.AddTransient<IRepository<Motorcycle>, MotorcycleRepository>();
            services.AddTransient<IRepository<Riders>, RiderRepository>();
            services.AddTransient<IRepository<Brands>, BrandRepository>();

            services.AddTransient<IMotoLogic, MotoLogic>();
            services.AddTransient<IRiderLogic, RiderLogic>();
            services.AddTransient<IBrandLogic, BrandLogic>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "QBU9QL_HFT_2022231.Endpoint" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
