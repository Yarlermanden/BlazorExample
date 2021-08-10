using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace RegexGeneratorFrontend
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var isDevelopment = environment == Environments.Development;

            if (isDevelopment)
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                    .Enrich.FromLogContext().WriteTo.Console()
                    .CreateLogger();

            }
            else
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Error)
                    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Error)
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    /*
                    .WriteTo.Elasticsearch(
                    new ElasticsearchSinkOptions(
                            new Uri("InsetURIHere"))
                        {
                            ModifyConnectionSettings =
                                x => x.BasicAuthentication("elastic", "xxx"),
                            AutoRegisterTemplate = true,
                            CustomFormatter = new ExceptionAsObjectJsonFormatter(renderMessage: true),
                            IndexFormat = $"xxx"
                        })
                    */
                    .CreateLogger();
            }

            using (var scope = host.Services.CreateScope())
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                //var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                try
                {
                    //context.Database.Migrate();
                }
                catch (Exception exception)
                {
                    logger.LogCritical(exception, "Failed to ensure the database was created");
                    return 1;
                }
            }

            try
            {
                Log.Information("Starting up");
                host.Run();
            }
            catch (Exception e)
            {
                Log.Fatal(e, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }

            return 0;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
