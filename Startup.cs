using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatunashviliAPI.Data;
using DatunashviliAPI.Errors;
using DatunashviliAPI.Exstensions;
using DatunashviliAPI.Helpers;
using DatunashviliAPI.Interfaces;
using DatunashviliAPI.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DatunashviliAPI
{
    public class Startup
    {

        //appsettings dan modis es configuracia
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<StoreContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            
            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddApplicationServices();

            //add swagger
            services.AddSwaggerDocumentation();
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*
             *  use ExceptionMiddleware instead
               if (env.IsDevelopment())
              {
                  app.UseDeveloperExceptionPage();
              }
             */

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseSwaggerDocumentation();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
