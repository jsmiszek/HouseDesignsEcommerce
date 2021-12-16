using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

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
                    var seeder = scope.ServiceProvider.GetService<ApplicationDbSeeder>();
                    seeder.Seed();
                }
            }*/
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                /* .ConfigureLogging(logBuilder =>
                 {
                     logBuilder.ClearProviders(); // removes all providers from LoggerFactory
                     logBuilder.AddConsole();
                     logBuilder.AddTraceSource("Information, ActivityTracing"); // Add Trace listener provider
                 })*/
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
