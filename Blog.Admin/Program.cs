using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Blog.Admin
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    await CreateRolesAsync(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        private static async Task CreateRolesAsync(IServiceProvider services)
        {

            using (var context = services.GetRequiredService<ApplicationDbContext>())
            {
                context.Database.Migrate();
                var configuration = services.GetRequiredService<IConfiguration>();
                var RoleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                if (RoleManager.Roles.Count()==0)
                {
                    await RoleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
                }
                var UserManager = services.GetRequiredService<UserManager<IdentityUser>>();
                var email = Environment.GetEnvironmentVariable("adminEmail") ?? configuration.GetValue<string>("adminEmail");
                var user =await UserManager.FindByEmailAsync(email);
                if (user != null)
                {
                    await UserManager.AddToRoleAsync(user, "Admin");
                }
                context.SaveChanges();
            }

        }
    }
}
