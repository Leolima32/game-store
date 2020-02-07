using Microsoft.AspNetCore.Hosting;
using GameStore.Infra.Data.Context;
using Microsoft.Extensions.Hosting;

namespace GameStore.UI.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build()
                .MigrateDatabase()
                .SeedDbContext<GameStoreContext>()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
