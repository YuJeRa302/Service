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
using Microsoft.Extensions.Logging;
using IngredientServer.Models;
using IngredientServer.Repositories;
using IngredientServer.Services;

namespace IngredientServer
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
            services.AddControllers(mvcOtions =>
            {
                mvcOtions.EnableEndpointRouting = false;
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddCors();

            services.AddDbContext<IngredientServerContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("IngredientServerContext")));

            services.AddScoped(typeof(IIngredientRepository), typeof(IngredientRepository));

            services.AddScoped(typeof(IIngredientService), typeof(IngredientService));

            services.AddScoped(typeof(ICartItemRepository), typeof(CartItemRepository));

            services.AddScoped(typeof(ICartItemService), typeof(CartItemService));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
