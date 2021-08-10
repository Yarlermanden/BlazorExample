
using System;
using System.Net.Http;
using System.Security.Authentication.ExtendedProtection;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RegexGenerator.Helpers;
using RegexGenerator.Services;
using Serilog;
using Serilog.Events;
using Topshelf;

namespace RegexGeneratorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = RegisterServices();
            
            AddLogging();
            
            var rc = HostFactory.Run(x =>
            {
                x.Service<StartService>(sc =>
                {
                    var service = services.GetRequiredService<IService>();
                    var memoryCacheService = services.GetRequiredService<IMemoryCache>();

                    sc.ConstructUsing(name => new StartService(service, memoryCacheService));
                    sc.WhenStarted((service, control) => service.Start(control));
                    sc.WhenStopped((service, control) => service.Stop(control));
                });
            });
        }

        private static IServiceProvider RegisterServices()
        {
            var serviceCollection = new ServiceCollection();

            IConfiguration configuration = SetupConfiguration();

            serviceCollection.AddTransient<IHelper, Helper>();
            serviceCollection.AddTransient<IService, Service>();
            serviceCollection.AddMemoryCache();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }

        private static void AddLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Error)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
        }
        
        private static IConfiguration SetupConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            return builder;
        }
    }
}