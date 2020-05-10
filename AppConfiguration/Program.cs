using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AppConfiguration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                          .WithParsed<Options>(opts => CreateHostBuilder(opts).Build().Run());
        }

        public static IHostBuilder CreateHostBuilder(Options options) =>
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((context, config) =>
                    {
                        var connectionString = options.ConnectionString;

                        config.AddAzureAppConfiguration(connectionString);

                    });

                    webBuilder.UseStartup<Startup>();
                });
    }
}
