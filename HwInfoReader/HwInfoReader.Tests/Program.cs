using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace HwInfoReader.Tests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel();
                    webBuilder.ConfigureKestrel((context, options) =>
                    {
                        options.AddServerHeader = false;
                        options.AllowSynchronousIO = true;
                    });
                });
    }
}
