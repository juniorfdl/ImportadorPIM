using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Hosting;

namespace WorkerImportadorPIM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program.CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureServices((Action<HostBuilderContext, IServiceCollection>) 
                ((hostContext, services) =>
                {
                    services.AddHttpClient();
                    services.AddHostedService<Worker>();
                }));
        }
    }
}