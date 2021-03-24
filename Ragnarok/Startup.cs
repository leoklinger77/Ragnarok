using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ragnarok.Data;
using Ragnarok.Repository;
using Ragnarok.Repository.Interfaces;
using Ragnarok.Services.Login;
using Ragnarok.Services.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ragnarok
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddHttpContextAccessor();

            //Session
            services.AddMemoryCache();
            services.AddSession(option =>
            {
                option.Cookie.Name = ".Session";
                option.IdleTimeout = TimeSpan.FromSeconds(3600);
                option.Cookie.HttpOnly = true;
                option.Cookie.IsEssential = true;
            });

            services.AddDbContext<RagnarokContext>(options => options.UseSqlServer(Configuration.GetConnectionString("RagnarokContext")));

            services.AddScoped<SeedingService>();
            services.AddScoped<Session>();
            services.AddScoped<EmployeeLogin>();

            services.AddScoped<IBusinessRepository, BusinessRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeedingService seeding)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                seeding.Seed();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
