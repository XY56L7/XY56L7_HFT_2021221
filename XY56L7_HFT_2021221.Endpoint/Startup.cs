using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XY56L7_HFT_2021221.Data;
using XY56L7_HFT_2021221.Logic;
using XY56L7_HFT_2021221.Repository;

namespace XY56L7_HFT_2021221.EndPoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IPhoneLogic, PhoneLogic>();
            services.AddTransient<IBrandLogic, BrandLogic>();
            services.AddTransient<IOSYSTEMLogic, OSYSTEMLogic>();

            services.AddTransient<IPhoneRepository, PhoneRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IOSYSTEMRepository, OSYSTEMRepository>();

            services.AddTransient<PhoneDbContext, PhoneDbContext>();





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
                endpoints.MapControllers();
            });
        }
    }
}
