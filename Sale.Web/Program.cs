
using Microsoft.EntityFrameworkCore;
using Sale.Infrastructure.Context;
using Sale.loc.Dependencies;

namespace Sale.Web

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddUsuarioDependency();
            //builder.Services.AddDbContext<SaleContext>(option => options.UseSqlServer)
            builder.Services.AddDbContext<SaleContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SaleContext")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}