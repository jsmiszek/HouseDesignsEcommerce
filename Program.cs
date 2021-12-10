using HouseDesignsEcommerce.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseDesignsEcommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*var host = CreateHostBuilder(args).Build();

            if(args.Length == 1 && args[0].ToLower() == "/seed")
            {
                var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
                using (var scope = scopeFactory.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService<ApplicatioanDbSeeder>();
                    seeder.Seed();
                }
            }*/
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
