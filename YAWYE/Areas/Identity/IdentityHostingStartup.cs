using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApplication.Data;
using YAWYE.Data;

[assembly: HostingStartup(typeof(YAWYE.Areas.Identity.IdentityHostingStartup))]
namespace YAWYE.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ApplicationDbContextConnection")));
                services.AddDbContextPool<YAWYEDbContext>(options =>
                {
                    options.UseSqlServer(context.Configuration.GetConnectionString("YAWYEDb"));
                });
                services.AddScoped<IProductData, SQLProductData>();
                services.AddScoped<IMealData, SQLMealData>();
                services.AddScoped<IMealProductData, SQLMealProductData>();

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ApplicationDbContext>();
            });
        }
    }
}
