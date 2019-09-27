using DataAPIDocker.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DataAPIDocker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().MigrateDatabase<MagContext>().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
